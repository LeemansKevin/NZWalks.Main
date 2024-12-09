import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GetWalkDTO } from '../models/getWalkDTO';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WalkService {
 
  apiUrl:string = 'https://localhost:7207/Walk'

  constructor(private httpClient:HttpClient) { }
  
  getWalk(id:number):Observable<GetWalkDTO>{

    return this.httpClient.get<GetWalkDTO>(`${this.apiUrl}/?Id=${id}`)
  }

}
