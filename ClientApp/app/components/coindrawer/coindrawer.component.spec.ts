import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By }              from '@angular/platform-browser';
import { DebugElement }    from '@angular/core';

import { CoinDrawerComponent } from './coindrawer.component';


describe('CoinDrawerComponent (inline template)', () => {

  let comp:    CoinDrawerComponent;
  let fixture: ComponentFixture<CoinDrawerComponent>;
  let de:      DebugElement;
  let el:      HTMLElement;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ CoinDrawerComponent ], // declare the test component
    });

    fixture = TestBed.createComponent(CoinDrawerComponent);

    comp = fixture.componentInstance; // CoinDrawerComponent test instance

    // query for the title <h1> by CSS element selector
    de = fixture.debugElement.query(By.css('h1'));
    el = de.nativeElement;
  });
});