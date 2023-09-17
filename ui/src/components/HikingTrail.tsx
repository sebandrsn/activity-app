import React, { useEffect, useState } from 'react'
import { HikingTrailService } from '../services/HikingTrailService'
import { Card, Typography } from '@mui/material'
import { HikingTrailDto } from '../types/HikingTrailDto'

interface Props {
  id: string
}

const HikingTrail: React.FC<Props> = ({id}) => {

  const [hikingTrail, setHikingTrail] = useState<HikingTrailDto>()

  useEffect(() => {
    retrieveHikingTrail()
  }, [])

  const retrieveHikingTrail = () => {
    
    const hikingTrail = HikingTrailService.getHikingTrailList().then(res => res.data).catch(error => console.log(error))

    HikingTrailService.getHikingTrailDetail(id!)
    .then((response) => {
      setHikingTrail(response.data)
    })
    .catch(error => console.log(error))
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