import { Component, OnInit } from '@angular/core';
import { PhoneBookService } from '../services/phoneBook.service';
import { PhoneBooks } from '../models/responses/phoneBooks';

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
      });
  }

  showAddPhoneBook() {
    this.show = true;
  }

  hideForm(showForm){
    this.show = showForm;
  }

}
