import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Event } from '../_models/Event';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  baseURL = 'http://DESKTOP-2:5002/api/event'

  constructor(private http: HttpClient) { }

  getEventAll(): Observable<Event[]>{
    return this.http.get<Event[]>(this.baseURL);
  }

  getEventById(id: number): Observable<Event>{
    return this.http.get<Event>(`${this.baseURL}/${id}`); 
  }
  
  getEventByName(name: string): Observable<Event[]>{
    return this.http.get<Event[]>(`${this.baseURL}/${name}`);
  }

  postEvent(event: Event){
    return this.http.post(this.baseURL, event);
  }

  putEvent(event: Event){
    return this.http.put(`${this.baseURL}/${event.eventId}`, event);
  }

  deleteEvent(id: number){
    return this.http.delete(`${this.baseURL}/delete/${id}`);
  }
}
