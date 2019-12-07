import { Component, OnInit } from '@angular/core';
import { PhoneBookService } from '../services/phoneBook.service';
import { PhoneBooks } from '../models/responses/phoneBooks';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-phoneBook-view',
  templateUrl: './phoneBook-view.component.html',
  styleUrls: ['./phoneBook-view.component.css']
})
export class PhoneBookViewComponent implements OnInit {
  phoneBooks: any;
  show = false;
  constructor(private phoneBookService: PhoneBookService) { }

  ngOnInit() {
    this.getPhoneBooks();
  }

  getPhoneBooks() {
    this.phoneBookService.getPhoneBooks()
      .subscribe(data => {
        this.phoneBooks = data.phoneBooks;
        console.log(this.phoneBooks);
      }, error => {
        Swal.fire({
          icon: 'error',
          title: 'Server error',
          text: 'Something went wrong!',
          footer: 'Please contact your administrator'
        });
      });
  }

  showAddPhoneBook() {
    this.show = true;
  }

  hideForm(showForm){
    this.show = showForm;
  }

}
