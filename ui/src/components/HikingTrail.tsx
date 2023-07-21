import React from 'react'
import { HikingTrailData } from '../types/HikingTrail'
import './../stylesheets/main.css'

interface Props {
  hikingTrail: HikingTrailData | null
}

const HikingTrail: React.FC<Props> = ({ hikingTrail }: Props) => {
  return (
    <div>this is a hiking trail, cool huh?</div>
  )
}

export default HikingTrail