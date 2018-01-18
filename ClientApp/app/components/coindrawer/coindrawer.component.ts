import { Component } from '@angular/core';

import 'rxjs/add/observable/range';
import 'rxjs/add/operator/toArray';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';

import { Coin } from '../../model/coin';

export const COINS: Coin[] = [
    { name: '5CHF', value: 5, cssStyle: 'coin-five' },
    { name: '2CHF', value: 2, cssStyle: 'coin-two' },
    { name: '1CHF', value: 1, cssStyle: 'coin-one' },
    { name: '1/2CHF', value: 0.5, cssStyle: 'coin-half' },
    { name: '20c', value: 0.20, cssStyle: 'coin-twenty-c' },
    { name: '10c', value: 0.10, cssStyle: 'coin-ten-c' },
    { name: '5c', value: 0.05, cssStyle: 'coin-five-c' }
    ];

@Component({
    selector: 'app-coindrawer',
    templateUrl: './coindrawer.component.html',
    styleUrls: ['./coindrawer.component.css']
})
export class CoinDrawerComponent {

    coins = COINS;
    selectedCoins: Coin[] = [];
    lastCoin: Coin;

  onUseCoin(coin: Coin): void {
    this.selectedCoins.push(coin);
    this.lastCoin = coin;
  }

}
