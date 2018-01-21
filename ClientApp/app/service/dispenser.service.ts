﻿import { Injectable } from '@angular/core';

import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';

import { Coin } from '../model/coin';
import { DrinkCan } from '../model/drinkCan';


const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class DispenserService {


    private drinkCansUrl = 'api/drink';  // URL to web api

    constructor(private http: HttpClient) { }

    getDrinks(): Observable<DrinkCan[]>{
        return this.http.get<DrinkCan[]>(this.drinkCansUrl);
    }

    orderDrink(selectedDrinkCan: DrinkCan, coinInserted: Coin[]): Observable<boolean>{

        var headers = new HttpHeaders();
headers.append('Content-Type', 'application/json');
        /*let body = new HttpParams();
        body.set('coinInserted', coinInserted.toString());
        //body.set('selectedDrinkCan', selectedDrinkCan.toString());


        coinInserted.forEach(id => {
          body = body.append('id[]', id);
        });*/

        let body = JSON.stringify({ coinInserted, selectedDrinkCan} );
        //body = body + ", " + JSON.stringify(selectedDrinkCan);

        debugger;
        return this.http.post<boolean>(this.drinkCansUrl, body, httpOptions );

    }

}