import { Component } from '@angular/core';

import 'rxjs/add/observable/range';
import 'rxjs/add/operator/toArray';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';

import { Coin } from '../../model/coin';

export const COINS: Coin[] = [
    { id: 1, value: 5, quantity: 10, capacity: 20, cssStyle: 'coin-five' },
    { id: 2, value: 2, quantity: 10, capacity: 20, cssStyle: 'coin-two' },
    { id: 3, value: 1, quantity: 10, capacity: 20, cssStyle: 'coin-one' },
    { id: 4, value: 0.5, quantity: 10, capacity: 20, cssStyle: 'coin-half' },
    { id: 5, value: 0.20, quantity: 10, capacity: 20, cssStyle: 'coin-twenty-c' },
    { id: 6, value: 0.10, quantity: 10, capacity: 20, cssStyle: 'coin-ten-c' },
    { id: 7, value: 0.05, quantity: 10, capacity: 20, cssStyle: 'coin-five-c' }
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
