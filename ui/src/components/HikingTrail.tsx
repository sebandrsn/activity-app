import React from 'react'
import { HikingTrailData } from '../types/HikingTrail'
import { Card } from '@mui/material'

interface Props {
  hikingTrail: HikingTrailData
}

const HikingTrail: React.FC<Props> = ({ hikingTrail }: Props) => {
  return (
    <Card>
      <div>{hikingTrail.id}</div>
      <div>{hikingTrail.name}</div>
    </Card>
  )
}

export default HikingTrail