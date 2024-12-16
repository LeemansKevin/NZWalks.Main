import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GetWalkDTO } from '../models/getWalkDTO';
import { Observable } from 'rxjs';
import { AddWalkDTO } from '../models/addWalkDTO';

@Injectable({
  providedIn: 'root'
})
export class WalkService {
 
  apiUrl:string = 'https://localhost:7207/Walk'
  

  constructor(private httpClient:HttpClient) { }
  
  getWalk(id:number):Observable<GetWalkDTO>{

    return this.httpClient.get<GetWalkDTO>(`${this.apiUrl}?Id=${id}`)
  }

  getWalks():Observable<GetWalkDTO[]> {

    return this.httpClient.get<GetWalkDTO[]>(`${this.apiUrl}/GetAllWalks`)
  }

  addWalk(dto:AddWalkDTO){
    let token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6IndpbGxpYW1qZWFucmF5QGdtYWlsLmNvbSIsImZhbWlseV9uYW1lIjoiSmVhbnJheSIsIkhvYmJ5IjoiTG9wZW4iLCJyb2xlIjpbImFkbWluIiwicmVhZGVyIl0sIm5iZiI6MTczNDM2MDA2NCwiZXhwIjoxNzM0MzYzNjY0LCJpYXQiOjE3MzQzNjAwNjQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjcyMDcvIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIwNy8ifQ.eLcr5vzG_UgCjQaVUiynWDr6FcQx3cDA1Q2isxILwwc'
    let headers = new HttpHeaders().set('Authorization',`Bearer ${token}`)
    return this.httpClient.post(this.apiUrl,dto,{headers})
  }

}
