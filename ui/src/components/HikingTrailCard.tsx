import React from 'react'
import { HikingTrailData } from '../types/HikingTrail'
import { Card, CardActionArea, CardContent, CardMedia, Container, Typography } from '@mui/material'
import './../stylesheets/main.css'
import fjord from './../static/fjord.jpg'
import { useNavigate } from 'react-router-dom'

interface Props {
    hikingTrail: HikingTrailData
}

const HikingTrailCard: React.FC<Props> = ({ hikingTrail }: Props) => {
    let navigate = useNavigate()

    return (
            <Card sx={{ bgcolor: 'darkgrey' }}>
                <CardActionArea onClick={() => navigate(`/HikingTrail/${hikingTrail.id}`)}>
                    <CardMedia
                        sx={{ height: 140 }}
                        image={fjord}
                    />
                    <CardContent>
                        <Typography gutterBottom variant="h5" component="div">
                            {hikingTrail.name}
                        </Typography>
                        <Typography variant="body2" color="text.secondary">
                            {hikingTrail.description}
                        </Typography>
                    </CardContent>
                </CardActionArea>
            </Card>
    )
}

export default HikingTrailCard