import { Injectable } from '@angular/core';

import { DrinkCan } from '../../model/drinkCan';

@Injectable()
export class DispenserService {

    getDrinks(): DrinkCan[]{

        drinks: DrinkCan[] = [];

       let a:  DrinkCan = <DrinkCan>({
                code: "COKE",
                description: "Coca Cola",
                price: 1.20});

        let b :  DrinkCan = <DrinkCan>({
                code: "FANTA",
                description: "Fanta",
                price: 1.60});

        let c :  DrinkCan = <DrinkCan>({
                code: "WATER",
                description: "Water",
                price: 1.00});

        drinks.push(a);
        drinks.push(b);
        drinks.push(c);

        return drinks;
    }

}