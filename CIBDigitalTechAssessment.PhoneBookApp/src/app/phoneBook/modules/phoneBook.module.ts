import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PhoneBookFormComponent } from '../phoneBook-form/phoneBook-form.component';
import { PhoneBookEntryComponent } from '../phoneBookEntry-view/phoneBookEntry-view.component';
import { PhoneBookViewComponent } from '../phoneBook-view/phoneBook-view.component';
import { PhoneBookService } from '../services/phoneBook.service';
import { EntryModule } from 'src/app/entry/modules/entry.module';
import {AccordionModule} from 'primeng/accordion';
import {PanelModule} from 'primeng/panel';
import {ButtonModule} from 'primeng/button';
import {TableModule} from 'primeng/table';

@NgModule({
    imports: [
      CommonModule,
      ReactiveFormsModule,
      FormsModule,
      CommonModule,
      EntryModule,
      AccordionModule,
      PanelModule,
      ButtonModule,
      TableModule
    ],
    declarations: [PhoneBookFormComponent,
                   PhoneBookEntryComponent,
                   PhoneBookViewComponent
                  ],
    providers: [PhoneBookService],
  })
  export class PhoneBookModule { }