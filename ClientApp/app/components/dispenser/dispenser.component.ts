import { Component , OnInit } from '@angular/core';

import { DispenserService } from '../../service/dispenser.service';
import { MessageService } from '../../service/message.service';

import { Coin } from '../../model/coin';
import { Delivery } from '../../model/delivery';
import { DrinkCan } from '../../model/drinkCan';


@Component({
    selector: 'app-dispenser',
    templateUrl: './dispenser.component.html',
    styleUrls: ['./dispenser.component.css']
})

/** 
 * Main component which instantiate CoinDrawer, Coinstore, Drinkcan, Instructionscreen 
 */
export class DispenserComponent {

    selectedDrinkCan: DrinkCan;
    coinInserted: Coin[] = []; // coin the user inserts before choosing a drink

    drinkCans: DrinkCan[];

    refreshToggle: boolean;

    constructor(private dispenserService: DispenserService, private messageService: MessageService) {}

    ngOnInit() {
        this.getDrink();
    }

    /**
     * Load the drink by calling the dispenser.service.
     */
    getDrink(): void{

        this.dispenserService.getDrinks()
            .subscribe(drinkcans => this.drinkCans = drinkcans);
    }

     /**
     * Select a drink 
     * @param {DrinkCan} drink - The drink selected
     */
    onDrinkSelected(drink: DrinkCan){
        this.selectedDrinkCan = drink;
        this.messageService.add("You are choosing "+drink.description);
    }

     /**
     * Insert a coin in the dispenser
     * @param {Coin} coin - The coin to inserted
     */
    insertCoin(coin: Coin): void{
        this.coinInserted.push(coin);
    }

     /**
     * Method raised when a coin is pressed on the drawer
     * @param {Coin} coinToInsert - The coin to inser
     */
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

     /**
     * Call the dispenser.service with inserted 
     * coins and drink choice
     */
    onValidateOrder(){
        var self = this;

        if( this.coinInserted != null && this.coinInserted.length > 0 ){
                    this.dispenserService.orderDrink(this.selectedDrinkCan, this.coinInserted)
            .subscribe(function(delivery: Delivery){
                if(delivery != null && delivery.drink != null && delivery.errorMessage == null){
                    self.messageService.add(`Here is your ${delivery.drink.description}, enjoy!`);
                    if(delivery.coins.length > 0 ){
                        let tmp = "";
                        delivery.coins.forEach( function(e){
                            if(tmp ==""){
                                tmp += ' '+e;
                            }
                            else{
                                tmp += ', '+e;
                            }
                        });
                        self.messageService.add(`Here is your change ${tmp}`);
                    }

                    self.refreshToggle = self.refreshToggle ? false: true;

                    //remove custom choice, for the next client
                    self.selectedDrinkCan = new DrinkCan;
                    self.coinInserted = [];
                    self.getDrink();
                }
                else if(delivery != null && delivery.errorMessage != null ){
                    self.messageService.add(delivery.errorMessage);
                    //remove custom choice, for the next client
                    self.selectedDrinkCan = new DrinkCan;
                    self.coinInserted = [];
                    self.getDrink();
                }
                else{
                    self.messageService.add("Something went wrong during order");
                    //remove custom choice, for the next client
                    self.selectedDrinkCan = new DrinkCan;
                    self.coinInserted = [];
                    self.getDrink();
                }

            } );
        }
        else{
            self.messageService.add("You first need to insert coin(s) to order a drink!")
        }

    }

     /**
     * Remove the inserted coin and the drink choice
     */
    onCancelOrder(): void{
        this.coinInserted = [];
        this.selectedDrinkCan = new DrinkCan;
        this.messageService.add("Order cancelled, please take back you money");
    }

}
