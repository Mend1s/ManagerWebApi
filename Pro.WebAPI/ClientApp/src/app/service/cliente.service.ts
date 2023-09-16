import { Client } from 'src/app/features/cliente/models/client';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private http: HttpClient) { }

  private baseUrl = 'https://localhost:5100/api/'

  getListClients(): Observable<Client[]> {
    return this.http.get<Client[]>(`${this.baseUrl}cliente`)
  }

  getClientById(id: string): Observable<Client> {
    return this.http.get<Client>(`${this.baseUrl}cliente/${id}`)
  }

  putClient(client: Client): Observable<any> {
    return this.http.put(`${this.baseUrl}cliente/${client.id}`, client);
  }

  postClient(client: Client): Observable<any> {
    return this.http.post(`${this.baseUrl}cliente/`, client);
  }

  deleteClient(id: string): Observable<any> {
    return this.http.delete<Client>(`${this.baseUrl}cliente/${id}`)
  }
}

