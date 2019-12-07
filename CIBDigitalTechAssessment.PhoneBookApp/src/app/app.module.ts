import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpErrorInterceptor } from './interceptors/errorHandle';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import {AccordionModule} from 'primeng/accordion';
import {PanelModule} from 'primeng/panel';
import {ButtonModule} from 'primeng/button';
import {TableModule} from 'primeng/table';
import { EntryViewComponent } from './entry/entry-view/entry-view.component';
import { EntryFormComponent } from './entry/entry-form/entry-form.component';
import { PhoneBookFormComponent } from './phoneBook/phoneBook-form/phoneBook-form.component';
import { PhoneBookEntryComponent } from './phoneBook/phoneBookEntry-view/phoneBookEntry-view.component';
import { PhoneBookViewComponent } from './phoneBook/phoneBook-view/phoneBook-view.component';
import { PhoneBookService } from './phoneBook/services/phoneBook.service';
import { EntryService } from './entry/services/entry.service';
import { EntryResultViewComponent } from './entry/entry-result-view/entry-result-view.component';

@NgModule({
  declarations: [
    AppComponent,
    EntryViewComponent,
    EntryFormComponent,
    PhoneBookFormComponent,
    PhoneBookEntryComponent,
    PhoneBookViewComponent,
    EntryResultViewComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    AccordionModule,
    PanelModule,
    ButtonModule,
    TableModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptor,
      multi: true,
    },
    PhoneBookService,
    EntryService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
