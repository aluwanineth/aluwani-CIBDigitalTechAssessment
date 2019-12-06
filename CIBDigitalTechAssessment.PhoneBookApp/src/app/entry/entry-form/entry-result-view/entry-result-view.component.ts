import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-entry-result-view',
  templateUrl: './entry-result-view.component.html',
  styleUrls: ['./entry-result-view.component.css']
})
export class EntryResultViewComponent implements OnInit {
@Input() searchResults: any;
entriesData: any = [];
entries: any;
  constructor() { }

  ngOnInit() {
    this.getEntries();
    this.entries = this.entriesData[0];
  }

  getEntries(){
    this.searchResults.phoneBooks.forEach(element => {
      this.entriesData.push(element.entry);
    });
    console.log(this.entriesData);
  }

}
