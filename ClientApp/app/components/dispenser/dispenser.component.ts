import { Component , OnInit } from '@angular/core';

import { DispenserService } from '../../service/dispenser.service';
import { MessageService } from '../../service/message.service';

import { DrinkCan } from '../../model/drinkCan';
import { Coin } from '../../model/coin';


@Component({
    selector: 'app-dispenser',
    templateUrl: './dispenser.component.html',
    styleUrls: ['./dispenser.component.css']
})
export class DispenserComponent {

    selectedDrinkCan: DrinkCan;
    coinInserted: Coin[] = []; // coin the user inserts before choosing a drink

    drinkCans: DrinkCan[];

    refreshToggle: boolean;

    constructor(private dispenserService: DispenserService, private messageService: MessageService) {}

    ngOnInit() {
        this.getDrink();
    }

    getDrink(): void{

        this.dispenserService.getDrinks()
            .subscribe(drinkcans => this.drinkCans = drinkcans);
    }

    onDrinkSelected(drink: DrinkCan){
        this.selectedDrinkCan = drink;
        this.messageService.add("You are choosing "+drink.description);
    }

    insertCoin(coin: Coin): void{
        this.coinInserted.push(coin);
    }


    onCoinInserted(coinToInsert: Coin) {
        this.insertCoin(coinToInsert);
        let tmp = "";

        this.coinInserted.forEach( function(element ){
            if(tmp ==""){
                tmp += ' '+element.value;
            }
            else{
            tmp += ', '+element.value;
            }
        } );

        this.messageService.add("You inserted the following coins: "+tmp);
    }

    onValidateOrder(){
        var self = this;
        this.dispenserService.orderDrink(this.selectedDrinkCan, this.coinInserted)
            .subscribe(function(orderConfirmation: boolean){
                debugger;
                if(orderConfirmation){
                    self.messageService.add("Here is your drink, envoy!");
                    self.refreshToggle = self.refreshToggle ? false: true;

                    //remove custom choice, for the next client
                    self.selectedDrinkCan = new DrinkCan;
                    self.coinInserted = [];
                }
                else{
                    self.messageService.add("Something went wrong during order");
                }

            } );
    }

    onCancelOrder(): void{
        this.coinInserted = [];
        this.selectedDrinkCan = new DrinkCan;

        this.messageService.add("Order cancelled, please take back you money");
    }

}
