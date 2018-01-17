import { Component, OnInit } from '@angular/core';

import 'rxjs/add/observable/range';
import 'rxjs/add/operator/toArray';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';

import { Coin } from '../coin/coin';

let list: number[] = [1, 2, 3, 4, 5, 6];


@Component({
    selector: 'coinstore',
    templateUrl: './coinstore.component.html',
    styleUrls: ['./coinstore.component.css']
})
export class CoinStoreComponent {

    //users = list;
    //fiveCoins: number;
    countObservable: Observable<number[]>;


    fiveCoins: Coin[] = [];
    twoCoins: Coin[] = [];
    oneCoins: Coin[] = [];
    fiftyCCoins: Coin[] = [];
    twentyCCoins: Coin[] = [];
    twnCCoins: Coin[] = [];
    fiveCCoins: Coin[] = [];


    InitTestData(): void{
       let c :  Coin = <Coin>({
                name: '2CHF',
                value: 2,
                cssStyle: 'coin-two'});
        this.twoCoins.push(c);
    }

    AddTwoCoin(): void{
        let tmp = new Coin();
        tmp.name = '2CHF';
        tmp.value = 2;

        this.twoCoins.push(tmp);
    }

    constructor() {
       /* this.fiveCoins = 5;
        this.countObservable = Observable.range(0, this.fiveCoins).toArray();

        this.fiveCoins = 10;*/

        /*InitTestData();*/
    }


      ngOnInit() {
        this.InitTestData();
    }

}
