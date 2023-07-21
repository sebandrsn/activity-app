import { Card, Typography } from '@mui/material'
import React from 'react'
import { useParams } from 'react-router-dom'

const HikingTrail = () => {
  let { id } = useParams()

  return (
    <Card>
      <Typography color="text.secondary">{id}</Typography>
    </Card>
  )
}

export default HikingTrail