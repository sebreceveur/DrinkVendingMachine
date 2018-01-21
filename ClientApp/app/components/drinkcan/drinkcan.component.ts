import { Component, Input } from '@angular/core';

import { DrinkCan } from '../../model/drinkCan';

@Component({
    selector: 'app-drinkcan',
    templateUrl: './drinkcan.component.html',
    styleUrls: ['./drinkcan.component.css']
})
export class DrinkCanComponent {

  @Input() drinkCan: DrinkCan;
  @Input() color: string;


}
