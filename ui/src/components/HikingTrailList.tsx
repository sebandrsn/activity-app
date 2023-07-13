import React, { useEffect, useState } from 'react'
import { HikingTrailService } from '../services/HikingTrailService'
import { HikingTrailData } from '../types/HikingTrail'
import HikingTrail from './HikingTrail'

const HikingTrailList: React.FC = () => {

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
        <div>
            {hikingTrails.map(hikingTrail => (
                <HikingTrail key={hikingTrail.id} hikingTrail={hikingTrail} />
            ))}
        </div>
    )
}

export default HikingTrailList