import React, { useEffect, useState } from 'react'
import { HikingTrailService } from '../services/HikingTrailService'
import { HikingTrailDto } from '../types/HikingTrailDto'
import HikingTrailCard from '../components/HikingTrailCard'
import Grid from '@mui/material/Unstable_Grid2'
import { Box } from '@mui/material'

export const Home: React.FC = () => {
    
    const [hikingTrails, setHikingTrails] = useState<HikingTrailDto[]>([])
    const retrieveHikingTrails = async () => {
        await HikingTrailService.getHikingTrailList()
            .then((response) => {
                setHikingTrails(response.data)
            })
            .catch((error) => {
                console.log(error)
            })
    }

    useEffect(() => {
        retrieveHikingTrails()
    }, [])

    return (
        <Box sx={{ m: 2 }}>
            <Grid container spacing={3}>
                {hikingTrails.map(hikingTrail => (
                    <Grid lg={4} md={6} xs={12} key={hikingTrail.id}>
                        <HikingTrailCard hikingTrail={hikingTrail} />
                    </Grid>
                ))}
            </Grid>
        </Box>
    )
}