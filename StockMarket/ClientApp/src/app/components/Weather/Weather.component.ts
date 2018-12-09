import { Component } from '@angular/core';
import { Chart } from 'chart.js';
import { WeatherService } from '../../services/Weather.service';

@Component({
    selector: 'Weather-Chart',
    templateUrl: './Weather.component.html',
    })


export class WeatherComponent {

    chart = []; // This will hold our chart info
  
    constructor(private _weather: WeatherService) {}
  
    ngOnInit() {
        this._weather.dailyForecast()
          .subscribe(res => {
            
            let temp_max = res['list'].map(res => res.main.temp_max)
            let temp_min = res['list'].map(res => res.main.temp_min)
            let alldates = res['list'].map(res => res.dt)
    
            let weatherDates = []
            alldates.forEach((res) => {
              let jsdate = new Date(res * 1000)
              weatherDates.push(jsdate.toLocaleTimeString('en', { year: 'numeric', month: 'short', day: 'numeric'}))
            })
    
            this.chart = new Chart('canvas', {
              type: 'line',
              data: {
                labels: weatherDates,
                datasets: [
                  {
                    data: temp_max,
                    borderColor: '#3cba9f',
                    fill: false
                  },
                  {
                    data: temp_min,
                    borderColor: '#ffcc00',
                    fill: false
                  },
                ]
              },
              options: {
                legend: {
                  display: false
                },
                scales: {
                  xAxes: [{
                    display: true
                  }],
                  yAxes: [{
                    display: true
                  }]
                }
              }
            })
    
          })
      }


  }
