import React, { useState } from 'react'
import { HikingTrailDto } from '../types/HikingTrailDto'
import { Box, Button, Card, CardActionArea, CardContent, CardMedia, Container, Modal, Typography } from '@mui/material'
import './../stylesheets/main.css'
import fjord from './../static/fjord.jpg'
import { useNavigate } from 'react-router-dom'
import HikingTrail from './HikingTrail'

interface Props {
    hikingTrail: HikingTrailDto
}

const HikingTrailCard: React.FC<Props> = ({ hikingTrail }: Props) => {
    let navigate = useNavigate()

    const [open, setOpen] = useState(false)
    const handleOpen = () => setOpen(true)
    const handleClose = () => setOpen(false)

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
            <Button onClick={handleOpen}>Open modal</Button>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                <Box>
                    <HikingTrail id={hikingTrail.id} />
                </Box>
            </Modal>
        </Card>
    )
}

export default HikingTrailCard