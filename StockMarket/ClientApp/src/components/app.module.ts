import { salModalComponent } from './Common/modal/modal.component';
import { TwitterService } from './../services/TwitterService';
import { guppyService } from './../services/guppy.service';
import { Chart } from 'chart.js';
import { CacheService } from '../services/CacheService.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import {ChartsModule} from 'ng2-charts/ng2-charts';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MACDComponent } from './charts/MACD/MACD.component';
import { WeatherService } from '../services/Weather.service';
import { MACDService } from '../services/MACD.service';
import { ApiService } from '../services/ApiService.service';
import { Ng5SliderModule } from 'ng5-slider';
import { SideMenuComponent } from './sidebar-menu/sidebar.menu.component';
import { HeaderComponent } from './header-menu/header.component';
import { PageHeaderComponent } from './page-header/page-header.component';
import 'chartjs-plugin-zoom';
import { RSIService } from '../services/RSI.service';
import { RSIComponent } from './charts/RSI/RSI.component';
import { ChartsLayoutComponent } from './Layot/Charts-Layout/charts.layout.component';
import { csvConvertorService } from '../services/csv.convertor.service';
import { SOComponent } from './charts/stochastic-oscillator/stochastic.oscillator.component';
import { stochasticOscillatorService } from '../services/stochasticOscillator.service';
import { guppyComponent } from './charts/guppy/guppy.component';
import { DateRangeComponent } from './Common/Date-Range/date-range.component';
import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';
import { PageNotFoundComponent } from './Layot/PageNotFoundComponent/page.not.found.component';
import { DashboardComponent } from './Layot/dashboard/dashboard.component';
import { DataTablesModule } from 'angular-datatables';
import { TwitterComponent } from './Layot/Twitter/twitter.component';
import { SearchTweetsComponent } from './search-tweets/search.tweets.component';
import { sweetAlertService } from '../services/sweetAlertService.service';


@NgModule({
  declarations: [
    AppComponent,
    SideMenuComponent,
    HeaderComponent,
    NavMenuComponent,
    MACDComponent,
    RSIComponent,
    PageHeaderComponent,
    ChartsLayoutComponent,
    SOComponent,
    guppyComponent,
    DateRangeComponent,
    PageNotFoundComponent,
    DashboardComponent,
    TwitterComponent,
    SearchTweetsComponent,
    salModalComponent
    

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ChartsModule,
    NgbModule,  
    Ng5SliderModule,
    RouterModule.forRoot([
      { path: '', component: DashboardComponent, pathMatch: 'full' },
      { path: 'charts', component: ChartsLayoutComponent, pathMatch: 'full' },
      { path: 'tweets', component: TwitterComponent },
      { path: '**', component: PageNotFoundComponent },
    ]),
    SweetAlert2Module.forRoot({
      buttonsStyling: false,
      customClass: 'modal-content',
      confirmButtonClass: 'btn btn-primary',
      cancelButtonClass: 'btn'
  })
  , DataTablesModule


  ],
  providers: [WeatherService
    , MACDService
    , RSIService
    , ApiService
    , csvConvertorService
    , stochasticOscillatorService
    , guppyService
    , CacheService
    ,TwitterService
    ,sweetAlertService
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
