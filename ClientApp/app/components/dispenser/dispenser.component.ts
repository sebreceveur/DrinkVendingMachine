import { Component , OnInit } from '@angular/core';

import { DrinkCan } from '../../model/drinkCan';

@Component({
    selector: 'app-dispenser',
    templateUrl: './dispenser.component.html',
    styleUrls: ['./dispenser.component.css']
})
export class DispenserComponent {

    viewModel: DrinkCan;

    drinkCans: DrinkCan[] = [];

    constructor(private dispenserService: DispenserService) {}

    ngOnInit() {

    }

    getDrink(): void{
        this.drinkCans = dispenserService.getDrinks();
    }


    /*onDrinkSelected(drink: DrinkCan){
        debugger;
    }*/

}
