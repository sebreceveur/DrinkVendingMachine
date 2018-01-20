import { Component , OnInit } from '@angular/core';

import { DispenserService } from '../../service/dispenser.service';

import { DrinkCan } from '../../model/drinkCan';


@Component({
    selector: 'app-dispenser',
    templateUrl: './dispenser.component.html',
    styleUrls: ['./dispenser.component.css']
})
export class DispenserComponent {

    selectedDrinkCan: DrinkCan;

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
        this.selectedDrinkCan = drink;
    }

}
