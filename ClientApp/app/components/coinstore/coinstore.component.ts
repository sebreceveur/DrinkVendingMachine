import { Component, OnInit } from '@angular/core';

import { CoinService } from '../../service/coin.service';

import { Coin } from '../../model/coin';



@Component({
    selector: 'app-coinstore',
    templateUrl: './coinstore.component.html',
    styleUrls: ['./coinstore.component.css']
})
export class CoinStoreComponent {


    fiveCoin: Coin;
    twoCoin: Coin;
    oneCoin: Coin;
    fiftyCCoin: Coin;
    twentyCCoin: Coin;
    tenCCoin: Coin;
    fiveCCoin: Coin;


    // used for convience: *ngFor only takes collection and not numbers
    fiveCoins: Coin[];
    twoCoins: Coin[];
    oneCoins: Coin[];
    fiftyCCoins: Coin[];
    twentyCCoins: Coin[];
    tenCCoins: Coin[];
    fiveCCoins: Coin[];


    counter = Array;

    coins: Coin[];


    /*InitTestData(): void{
       let c :  Coin = <Coin>({
                name: '2CHF',
                value: 2,
                cssStyle: 'coin-two'});
        this.twoCoins.push(c);
    }*/


    constructor(private coinService: CoinService) {

    }

    getStorage(): void{
        this.coinService.currentStorage()
           .subscribe((coins: Coin[]) => {

            coins.forEach( function(this: any, element){

                switch(element.value){
                    case 5.0 :
                    this.fiveCoins = element;
                    this.fiveCoins = new Array<number>(element.quantity);
                    break; 

                    case 2.0 :
                    this.twoCoin = element;
                    this.twoCoins = new Array<number>(element.quantity);
                    break;

                    case 1.0 :
                    this.oneCoin = element;
                    this.oneCoins = new Array<number>(element.quantity);
                    break;

                    case 0.50 :
                    this.fiftyCCoin = element;
                    this.fiftyCCoins = new Array<number>(element.quantity);
                    break;

                    case 0.20 :
                    this.twentyCCoin = element;
                    this.twentyCCoins = new Array<number>(element.quantity);
                    break;

                    case 0.10 :
                    this.tenCCoin = element;
                    this.tenCCoins = new Array<number>(element.quantity);
                    break;

                    case 0.05 :
                    this.fiveCCoin = element;
                    this.fiveCCoins = new Array<number>(element.quantity);
                    break;

                }
               
            }, this);

            this.coins = coins;
        })
    }

   

      ngOnInit() {

        this.getStorage();
    }

}
