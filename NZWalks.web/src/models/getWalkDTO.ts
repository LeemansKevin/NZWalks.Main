import internal from "stream"

export interface GetWalkDTO {
    walkName:string
    description:string
    climate:string
    altitude:number
    pictureURL:string
    lengthInKm:number
    region:string
}