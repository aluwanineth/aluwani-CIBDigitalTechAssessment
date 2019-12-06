/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EntryViewComponent } from './entry-view.component';

describe('EntryViewComponent', () => {
  let component: EntryViewComponent;
  let fixture: ComponentFixture<EntryViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EntryViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EntryViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
