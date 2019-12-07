import { Component, OnInit, Input } from '@angular/core';
import { PhoneBookService } from 'src/app/phoneBook/services/phoneBook.service';
import Swal from 'sweetalert2';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-entry-view',
  templateUrl: './entry-view.component.html',
  styleUrls: ['./entry-view.component.css']
})
export class EntryViewComponent implements OnInit {
@Input()entry: any;
@Input()phoneBookId: any;
entries: any;
searchResults: any;
name: any;
show = false;
showSearchResult = false;
  constructor(private phoneBookService: PhoneBookService) { }

  ngOnInit() {
    this.entries = this.entry;
  }

  searchPhoneEntry(searchForm: NgForm) {
    this.getPhoneBookByName(this.phoneBookId, this.name, searchForm);
  }
  getPhoneBookByName(phoneBookId, name, searchForm) {
    this.phoneBookService.getPhoneBookEntryByName(phoneBookId, name)
      .subscribe(data => {
        this.searchResults = data;
        this.searchResults.phoneBooks.forEach(element => {
          if (element.entry.length > 0) {
            this.showSearchResult = true;
          } else {
            Swal.fire({
              icon: 'info',
              title: 'Search',
              text: 'Oops no phone number found'
            });
          }
        });
      }, error => {
        Swal.fire({
          icon: 'error',
          title: 'Server error',
          text: 'Something went wrong!',
          footer: 'Please contact your administrator'
        });
      });
    searchForm.reset();
  }
  showErtryPhone() {
    this.show = true;
  }

  hideForm(showForm){
    this.show = showForm;
  }

  hideSearchResult(result) {
    this.showSearchResult = result;
  }



}
