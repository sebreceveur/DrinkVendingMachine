import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';

import { Coin } from '../model/coin';



@Injectable()
export class CoinService {

    private coinUrl = 'api/coin';  // URL to web api

    constructor(private http: HttpClient) { }

    currentStorage(): Observable<Coin[]>{
        return this.http.get<Coin[]>(this.coinUrl);
    }

}