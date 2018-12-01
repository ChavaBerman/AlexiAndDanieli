import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-clock',
  templateUrl: './clock.component.html',
  styleUrls: ['./clock.component.css']
})
export class ClockComponent implements OnInit {

  hourHand: any=null;
  minuteHand: any=null;
  secondHand: any=null;
  constructor() { }

  ngOnInit() {
    this.raiseTimer();
  }

  raiseTimer(){
    setInterval(() => { this.setClockWithCurrentTime() }, 1000);
  }

  updateClock(hours, minutes, seconds) {
    var hourDegrees = hours * 30;
    var minuteDegrees = minutes * 6;
    var secondDegrees = seconds * 6;
    this.hourHand={
      'transform': `rotate(${hourDegrees}deg)`
    };
    this.minuteHand={
      'transform': `rotate(${minuteDegrees}deg)`
    };
    this.secondHand={
      'transform': `rotate(${secondDegrees}deg)`
    };

  }

  setClockWithCurrentTime();

  setClockWithCurrentTime() {
    var date = new Date();
    var hours = ((date.getHours() + 11) % 12 + 1);
    var minutes = date.getMinutes();
    var seconds = date.getSeconds();
    this.updateClock(hours, minutes, seconds);
    this.raiseTimer();
    
  }

}
