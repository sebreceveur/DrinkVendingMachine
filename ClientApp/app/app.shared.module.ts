import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { DispenserComponent } from './components/dispenser/dispenser.component';
import { CoinStoreComponent } from './components/coinstore/coinstore.component';
import { DrinkCanComponent } from './components/drinkcan/drinkcan.component';
import { CoinDrawerComponent } from './components/coindrawer/coindrawer.component';

import { DispenserService } from './service/dispenser.service';

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
        CoinDrawerComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'dispenser', component: DispenserComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [ DispenserService ]
})
export class AppModuleShared {
}
