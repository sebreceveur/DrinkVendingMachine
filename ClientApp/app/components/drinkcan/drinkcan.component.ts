import { Component, Input } from '@angular/core';

import { DrinkCan } from '../../model/drinkCan';

@Component({
    selector: 'app-drinkcan',
    templateUrl: './drinkcan.component.html',
    styleUrls: ['./drinkcan.component.css']
})

/** 
 * Simple component with a template and style
 * that print a Drink can
 */
export class DrinkCanComponent {

  @Input() drinkCan: DrinkCan;
  @Input() color: string;


}
