import { Component, OnInit, EventEmitter,Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PhoneBook } from '../models/requests/phoneBook';
import Swal from 'sweetalert2';
import { PhoneBookService } from '../services/phoneBook.service';

@Component({
  selector: 'app-phoneBook-form',
  templateUrl: './phoneBook-form.component.html',
  styleUrls: ['./phoneBook-form.component.css']
})
export class PhoneBookFormComponent implements OnInit {
  @Output() public hiddenForm = new EventEmitter<boolean>();
  phoneBookForm: FormGroup;
  submitted = false;
  spresp: any;
  postdata: PhoneBook;

  constructor(private phoneBookService: PhoneBookService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.phoneBookForm = this.formBuilder.group({
      name: ['', Validators.required]
    });
  }

  get f() { return this.phoneBookForm.controls; }

  onSubmit() {
      this.submitted = true;
      if (this.phoneBookForm.invalid) {
          return;
      }
      this.addPhoneBook(this.phoneBookForm.value);
  }

  addPhoneBook(postdata: PhoneBook) {
    this.phoneBookService
      .createPhoneBook(postdata)
      .subscribe(resp => {
        Swal.fire({
          icon: 'success',
          title: 'Phone book Saved',
          text: 'Phone book saved successfully!'
        });
        this.hiddenForm.emit(false);
        location.reload();
      });
  }

  resetForm(){
    this.phoneBookForm.reset();
    this.hiddenForm.emit(false);
  }
}

