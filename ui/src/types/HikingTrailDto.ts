import { CoordinatesDto } from "./CoordinatesDto"

export interface HikingTrailDto {
    id: string
    name: string
    description: string
    coordinates: CoordinatesDto
}