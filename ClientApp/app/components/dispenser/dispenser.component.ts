import { Component , OnInit } from '@angular/core';

import { DispenserService } from '../../service/dispenser.service';

import { DrinkCan } from '../../model/drinkCan';



export const DRINKCANS: DrinkCan[] = [
  { ID: 11, code: 'COKE', description: "Coca Cola", price: 1.20 },
  { ID: 12, code: 'FANT', description: "Fanta", price: 1.60 },
  { ID: 13, code: 'WATE', description: "Water", price: 1.00 }
];

@Component({
    selector: 'app-dispenser',
    templateUrl: './dispenser.component.html',
    styleUrls: ['./dispenser.component.css']
})
export class DispenserComponent {

    viewModel: DrinkCan;

    drinkCans: DrinkCan[];

    constructor(private dispenserService: DispenserService) {}

    ngOnInit() {
        this.getDrink();
    }

    getDrink(): void{

        this.dispenserService.getDrinks()
            .subscribe(drinkcans => this.drinkCans = drinkcans);
    }


    onDrinkSelected(drink: DrinkCan){
        debugger;
    }

}
