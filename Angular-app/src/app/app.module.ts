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
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// SERVICES
import { EventService } from './_services/Event.service';
// COMPONENTS
import { AppComponent } from './app.component';
import { EventsComponent } from './events/events.component';
import { NavComponent } from './nav/nav.component';
// PIPES
import { DateTimeFormatPipePipe } from './_helps/DateTimeFormatPipe.pipe';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
   declarations: [
      AppComponent,
      EventsComponent,
      NavComponent,
      DateTimeFormatPipePipe
   ],
   imports: [
      BrowserModule,
      BsDropdownModule.forRoot(),
      BrowserAnimationsModule,
      BsDatepickerModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
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
