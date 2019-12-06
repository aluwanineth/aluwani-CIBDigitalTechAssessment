import { Component, OnInit, Input } from '@angular/core';
import { PhoneBookService } from 'src/app/phoneBook/services/phoneBook.service';

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
  constructor(private phoneBookService: PhoneBookService) { }

  ngOnInit() {
    this.entries = this.entry;
  }

  searchPhoneEntry() {
    this.getPhoneBookByName(this.phoneBookId, this.name)
  }
  getPhoneBookByName(phoneBookId, name) {
    this.phoneBookService.getPhoneBookEntryByName(phoneBookId, name)
      .subscribe(data => {
        this.searchResults = data;
        console.log(this.searchResults);
        if(this.searchResults) {
          this.show = true;
        }
      });
  }
  showErtryPhone() {
    this.show = true;
  }

  hideForm(showForm){
    this.show = showForm;
  }



}
