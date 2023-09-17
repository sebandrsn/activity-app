import { CoordinatesDto } from "./CoordinatesDto"

export interface HikingTrailDetailVm {
    id: string
    name: string
    description: string
    coordinates: CoordinatesDto
    length: number
}