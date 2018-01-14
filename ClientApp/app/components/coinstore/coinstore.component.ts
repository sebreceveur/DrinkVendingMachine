import { Component } from '@angular/core';

import 'rxjs/add/observable/range';
import 'rxjs/add/operator/toArray';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';



let list: number[] = [1, 2, 3, 4, 5, 6];


@Component({
    selector: 'coinstore',
    templateUrl: './coinstore.component.html',
    styleUrls: ['./coinstore.component.css']
})
export class CoinStoreComponent {

    //users = list;
    fiveCoins: number;
    countObservable: Observable<number[]>;


    constructor() {
        this.fiveCoins = 5;
        this.countObservable = Observable.range(0, this.fiveCoins).toArray();

        this.fiveCoins = 10;
    }
}
