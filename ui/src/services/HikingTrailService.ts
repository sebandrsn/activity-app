import http from "../http-common";
import { HikingTrailData } from "../types/HikingTrail"

const getAll = () => {
    return http.get<HikingTrailData[]>('v1/HikingTrail')
}

const HikingTrailService = {
    getAll
}

export { HikingTrailService }