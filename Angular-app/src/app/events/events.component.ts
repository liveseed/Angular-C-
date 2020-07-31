import { Component, OnInit } from '@angular/core';
import { EventService } from '../_services/Event.service';
import { Event } from '../_models/Event';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { defineLocale, ptBrLocale } from 'ngx-bootstrap/chronos';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';


defineLocale('pt-br', ptBrLocale)

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})

export class EventsComponent implements OnInit {
  
  imageWidth = 50;
  imageMargin = 2;
  imageOnOff = true;  
  
  title = 'Events';
  saveOption = 'post';
  bodyDeleteEvent = '';
  _filterList: string = '';  

  filteredEvents: Event[];
  events: Event[];
  event: Event;
  
  modalRef: BsModalRef;  
  registerForm: FormGroup;
  
  get filterList(): string{
    return this._filterList;
  }
  set filterList(value: string){
    this._filterList = value;
    this.filteredEvents = this.filterList ? this.filterEvents(this.filterList) : this.events;
  }    

  constructor(
    private eventService: EventService,
    private modalService: BsModalService,
    private formBuilder: FormBuilder,
    private localService: BsLocaleService,
    private toastr: ToastrService
  ) {
      this.localService.use('pt-br')
  }

  ngOnInit() {
    this.validation();
    this.getEvents();
  }

  openModal(templateModal: any){
    this.registerForm.reset();
    templateModal.show();
  }

  filterEvents(filterBy: string): Event[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      event => event.name.toLocaleLowerCase().indexOf(filterBy) !== -1
      
    );
  }

  showImage(){
    this.imageOnOff = !this.imageOnOff;    
  }

  getEvents(){
    this.eventService.getEventAll().subscribe(
      (_events: Event[]) => {
      this.events = _events;
      this.filteredEvents = this.events;      
      
    }, error => {
      this.toastr.error(`Error loading the events: ${error}`);    
    });
  }

  newEvent(templateModal: any){
    this.saveOption = 'post';
    this.openModal(templateModal);
  }

  editEvent(event: Event, template: any){
    this.saveOption = 'put';
    this.openModal(template);
    this.event = event;
    this.registerForm.patchValue(event);
  }

  deleteEvent(event: Event, template: any){
    this.openModal(template);
    this.event = event;
    this.bodyDeleteEvent = `Confirm delete Event: ${event.name}, Cod: ${event.eventId}`; 
  }  

  confirmDeleteEvent(template: any){
    this.eventService.deleteEvent(this.event.eventId).subscribe(
      () => {
        template.hide();
        this.getEvents();    
        this.toastr.success('Deleted Successfully');    
      }, error => {
        this.toastr.error(`Error Deleting: ${error}`);    
        console.log(error);
      }
    );
  }

  cofirmSaveEvent(templateModal: any)  {
    if (this.registerForm.valid) {
      if (this.saveOption === 'post'){
        this.event = Object.assign({}, this.registerForm.value);
        this.eventService.postEvent(this.event).subscribe(
          (newEvent: Event) => {            
            templateModal.hide();
            this.getEvents();          
            this.toastr.success('Created Successfully');    
          }, error => {
            this.toastr.error(`Error Creating: ${error}`);    
            console.log(error)
          }
        )
      } else {
        this.event = Object.assign({eventId: this.event.eventId}, this.registerForm.value);
        this.eventService.putEvent(this.event).subscribe(
          () => {          
            templateModal.hide();
            this.getEvents();          
            this.toastr.success('Edited Successfully');    
          }, error => {
            this.toastr.error(`Error Editing: ${error}`);    
            console.log(error)
          }
        )
      }     
    } 
  }

  validation()  {
    this.registerForm = this.formBuilder.group ({
      type: ['',[Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      name: ['',[Validators.required]],
      location: ['',[Validators.required ]],
      eventDate: ['',[Validators.required ]],
      imageURL: ['',[Validators.required ]],
      capacity: ['',[Validators.required, Validators.max(10000)]],
      phone: ['',[Validators.required , Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]],
      email: ['',[Validators.required, Validators.email]]
    });
  }
  
  myDateParser(dateStr : string) : string {
    // 2018-01-01T12:12:12.123456; - converting valid date format like this

    let date = dateStr.substring(0, 10);
    let time = dateStr.substring(11, 19);
    let millisecond = dateStr.substring(20)

    let validDate = date + 'T' + time + '.' + millisecond;
    console.log(validDate)
    return validDate
  }
}
