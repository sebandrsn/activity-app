import React, { useEffect, useState } from 'react'
import { HikingTrailService } from '../services/HikingTrailService'
import { HikingTrailData } from '../types/HikingTrail'
import HikingTrailCard from '../components/HikingTrailCard'
import Grid from '@mui/material/Unstable_Grid2'
import { Box } from '@mui/material'

export const Home: React.FC = () => {
    const [hikingTrails, setHikingTrails] = useState<HikingTrailData[]>([])

    useEffect(() => {
        retrieveHikingTrails()
    }, [])

    const retrieveHikingTrails = () => {
        HikingTrailService.getAll()
            .then((response) => {
                setHikingTrails(response.data)
                console.log(response.data)
            })
            .catch((error) => {
                console.log(error)
            })
    }

    return (
        <Box sx={{ m: 2 }}>
            <Grid container spacing={3}>
                {hikingTrails.map(hikingTrail => (
                    <Grid lg={4} md={6} xs={12}>
                        <HikingTrailCard key={hikingTrail.id} hikingTrail={hikingTrail} />
                    </Grid>
                ))}
            </Grid>
        </Box>
    )
}

