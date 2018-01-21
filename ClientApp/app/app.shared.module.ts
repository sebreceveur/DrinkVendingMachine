import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { CoinDrawerComponent } from './components/coindrawer/coindrawer.component';
import { CoinStoreComponent } from './components/coinstore/coinstore.component';
import { DispenserComponent } from './components/dispenser/dispenser.component';
import { DrinkCanComponent } from './components/drinkcan/drinkcan.component';
import { InstructionScreenComponent } from './components/instructionscreen/instructionscreen.component';

import { CoinService } from './service/coin.service';
import { DispenserService } from './service/dispenser.service';
import { MessageService } from './service/message.service';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CoinDrawerComponent,
        CoinStoreComponent,
        DispenserComponent,
        DrinkCanComponent,
        InstructionScreenComponent
    ],
    providers: [ CoinService, DispenserService, MessageService  ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        HttpClientModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'dispenser', pathMatch: 'full' },
            { path: 'dispenser', component: DispenserComponent },
            { path: '**', redirectTo: 'dispenser' }
        ])
    ]

})
export class AppModuleShared {
}
