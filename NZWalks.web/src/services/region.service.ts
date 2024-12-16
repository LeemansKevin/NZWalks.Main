import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetRegionWithWalksDTO } from '../models/getRegionWithWalksDTO';

@Injectable({
  providedIn: 'root'
})
export class RegionService {
    apiUrl:string = `https://localhost:7207/Region`

    constructor(private httpClient:HttpClient) { }

    getRegionWithWalks(id:number):Observable<GetRegionWithWalksDTO>{

        return this.httpClient.get<GetRegionWithWalksDTO>(`${this.apiUrl}/GetRegion?Id=${id}&includeWalks=true`)
    }
}