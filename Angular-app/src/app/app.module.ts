// MODULES
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule as HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AppRoutingModule } from './app-routing.module';

import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

// SERVICES
import { EventService } from './_services/Event.service';

// COMPONENTS
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { EventsComponent } from './events/events.component';
import { HeadlinesComponent } from './headlines/headlines.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ContactsComponent } from './contacts/contacts.component';
import { TitleComponent } from './_shared/title/title.component'; 

// PIPES
import { DateTimeFormatPipePipe } from './_helps/DateTimeFormatPipe.pipe';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      EventsComponent,
      HeadlinesComponent,
      DashboardComponent,
      ContactsComponent,
      TitleComponent,
      DateTimeFormatPipePipe
   ],
   imports: [
      BrowserModule,
      BsDropdownModule.forRoot(),
      ToastrModule.forRoot(),
      BsDatepickerModule.forRoot(),
      ModalModule.forRoot(),
      BrowserAnimationsModule,
      TooltipModule.forRoot(),
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      NgbModule
   ],
   providers: [
      EventService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
