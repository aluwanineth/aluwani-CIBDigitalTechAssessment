import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EntryService } from '../services/entry.service';
import { Entry } from '../Models/requests/entry';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-entry-form',
  templateUrl: './entry-form.component.html',
  styleUrls: ['./entry-form.component.css'],
  providers: []
})
export class EntryFormComponent implements OnInit  {
  @Input() phoneBookId: number;
  @Output() public hiddenForm = new EventEmitter<boolean>();
  spresp: any;
  postdata: Entry;
  entryForm: FormGroup;
  submitted = false;
  constructor(private entryService: EntryService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.entryForm = this.formBuilder.group({
      name: ['', Validators.required],
      phoneNumber: ['', Validators.required]
    });
  }

  get f() { return this.entryForm.controls; }

  onSubmit() {
      this.submitted = true;

      if (this.entryForm.invalid) {
          return;
      }
      const data = {
        name: this.entryForm.value.name,
        phoneNumber: this.entryForm.value.phoneNumber,
        phoneBookId: this.phoneBookId
      }
      this.addEntry(data);
  }

  addEntry(postdata: Entry) {
    this.entryService
      .createEntry(postdata)
      .subscribe(resp => {
        Swal.fire({
          icon: 'success',
          title: 'Entry Saved',
          text: 'Phone entry saved successfully!'
        });
        this.hiddenForm.emit(false);
        location.reload();
      });
  }

  resetForm(){
    this.entryForm.reset();
    this.hiddenForm.emit(false);
  }
}
