import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-phoneBookEntry-view',
  templateUrl: './phoneBookEntry-view.component.html',
  styleUrls: ['./phoneBookEntry-view.component.css']
})
export class PhoneBookEntryComponent implements OnInit {
  @Input() data: any;
  constructor() { }

  ngOnInit() {
  }

}
