import http from "../http-common";
import { HikingTrailDto } from "../types/HikingTrailDto"
import { HikingTrailDetailVm } from "../types/HikingTrailDetailVm";

const getHikingTrailList = async () => {
    return http.get<HikingTrailDto[]>('v1/HikingTrail')
}

const getHikingTrailDetail = async (id: string) => {
    return await http.get<HikingTrailDetailVm>(`v1/HikingTrail/${id}`)
}

const HikingTrailService = {
    getHikingTrailList,
    getHikingTrailDetail
}

export { HikingTrailService }