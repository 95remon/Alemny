import { Component, OnInit, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit , AfterViewInit {
  s1: any = [];

  text:string = "";
  //s2: string[] = ['EOPLE', 'ASSION', 'ROFESSIONLISM'];

  counter1: number;
  counter2: number;

  constructor() {
    this.text = "Outreach";
    this.counter1 = 0;
    this.counter2 = 0;

    this.s1 = [
      'Outreach',
      'Human Capacity Building',
      'Leadership',
      'Youth Emerment',
      'Partship',
    ];
  }


  ngOnInit(): void {
    /*this.upatetText();*/
    
  }

  ngAfterViewInit(): void {
    //this.upatetText();
  }


  upatetText() {
    console.log('in')

    setInterval(function () {

        this.text = 
        this.s1[0];

        console.log('aaaaaa'+ this.s1[0].value)

      this.counter1 = (this.counter1 + 1) % this.s1.length;
    }, 2000);

    /*setInterval(function () {
      d2.innerHTML = this.s2[this.counter2];

      this.counter2 = (this.counter2 + 1) % this.s2.length;
    }, 2000);*/
  }
}
