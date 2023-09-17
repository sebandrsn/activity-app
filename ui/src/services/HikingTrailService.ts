import http from "../http-common";
import { HikingTrailDto } from "../types/HikingTrailDto"
import { HikingTrailDetailVm } from "../types/HikingTrailDetailVm";

const getHikingTrailList = async () => {
    const hikingTrail = http.get<HikingTrailDto[]>('v1/HikingTrail').then(res => res.data)
    return http.get<HikingTrailDto[]>('v1/HikingTrail')
}

const getHikingTrailDetail = async (id: string) => {
    return http.get<HikingTrailDetailVm>(`v1/HikingTrail/${id}`)
}

const HikingTrailService = {
    getHikingTrailList,
    getHikingTrailDetail
}

export { HikingTrailService }