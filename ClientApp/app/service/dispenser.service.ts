﻿import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';

import { DrinkCan } from '../model/drinkCan';



@Injectable()
export class DispenserService {

    private drinkCansUrl = 'api/drink';  // URL to web api

    constructor(private http: HttpClient) { }

    getDrinks(): Observable<DrinkCan[]>{
        return this.http.get<DrinkCan[]>(this.drinkCansUrl);
    }

}