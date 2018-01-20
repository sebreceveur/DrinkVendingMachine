import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { DispenserComponent } from './components/dispenser/dispenser.component';
import { CoinStoreComponent } from './components/coinstore/coinstore.component';
import { DrinkCanComponent } from './components/drinkcan/drinkcan.component';
import { CoinDrawerComponent } from './components/coindrawer/coindrawer.component';
import { InstructionScreenComponent } from './components/instructionscreen/instructionscreen.component';

import { CoinService } from './service/coin.service';
import { DispenserService } from './service/dispenser.service';
import { MessageService } from './service/message.service';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        DispenserComponent,
        CoinStoreComponent,
        DrinkCanComponent,
        CoinDrawerComponent,
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
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'dispenser', component: DispenserComponent },
            { path: '**', redirectTo: 'dispenser' }
        ])
    ]

})
export class AppModuleShared {
}
