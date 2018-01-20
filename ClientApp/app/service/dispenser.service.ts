import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';

import { DrinkCan } from '../model/drinkCan';

export const DRINKCANS: DrinkCan[] = [
  { ID: 11, code: 'COKE', description: "Coca Cola", price: 1.20 },
  { ID: 12, code: 'FANT', description: "Fanta", price: 1.60 },
  { ID: 13, code: 'WATE', description: "Water", price: 1.00 }
];


@Injectable()
export class DispenserService {

    constructor() { }

    getDrinks(): Observable<DrinkCan[]>{

        return of(DRINKCANS);
    }

}