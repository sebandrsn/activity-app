import { Card, Typography } from '@mui/material'
import { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import { HikingTrailService } from '../services/HikingTrailService'
import { HikingTrailDto } from '../types/HikingTrailDto'

const HikingTrail = () => {
  const { id } = useParams()

  const [hikingTrail, setHikingTrail] = useState<HikingTrailDto>()

  useEffect(() => {
    retrieveHikingTrail()
  }, [])

  const retrieveHikingTrail = async () => {
    if (id === undefined) {
      throw new Error('Missing Id')
    }
    await HikingTrailService.getHikingTrailDetail(id)
    .then((response) => {
      setHikingTrail(response.data)
    })
    .catch()
  }

  return (
    <Card>
      <Typography color="text.secondary">{hikingTrail?.id}</Typography>
      <Typography color="text.secondary">{hikingTrail?.name}</Typography>
      <Typography color="text.secondary">{hikingTrail?.description}</Typography>
      <Typography color="text.secondary">{hikingTrail?.coordinates.id}</Typography>
      <Typography color="text.secondary">{hikingTrail?.coordinates.latitude}</Typography>
      <Typography color="text.secondary">{hikingTrail?.coordinates.longitude}</Typography>
    </Card>
  )
}

export default HikingTrail