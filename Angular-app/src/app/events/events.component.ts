import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})

export class EventsComponent implements OnInit {

  constructor(private http: HttpClient) {}

  filteredEvents: any = [];
  events: any = [];
  imageWidth = 50;
  imageMargin = 2;
  imageOnOff = true;  

  _filterList = '';
  get filterList(): string{
    return this._filterList;
  }
  set filterList(value: string){
    this._filterList = value;
    this.filteredEvents = this.filterList ? this.filterEvents(this.filterList) : this.events;
  }  

  ngOnInit() {
    this.getEvents();
  }

  filterEvents(filterBy: string): any {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      event => event.name.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  showImage(){
    this.imageOnOff = !this.imageOnOff;    
  }

  getEvents(){
    this.http.get('http://DESKTOP-2:5002/api/values').subscribe(response => {
      this.events = response;
      console.log(response);      
    }), error => {
      console.log(error);
    }
  }
}
