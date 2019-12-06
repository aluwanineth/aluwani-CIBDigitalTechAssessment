import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EntryViewComponent } from '../entry-view/entry-view.component';
import { EntryFormComponent } from '../entry-form/entry-form.component';
import { EntryService } from '../services/entry.service';
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
      AccordionModule,
      PanelModule,
      ButtonModule,
      TableModule
    ],
    declarations: [EntryViewComponent,
                   EntryFormComponent
                  ],
    providers: [EntryService],
  })
  export class EntryModule { }