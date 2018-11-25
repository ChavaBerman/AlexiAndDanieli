import { Component, OnInit } from '@angular/core';
import { UserService } from './shared/imports';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ClientAngular';
  constructor(private userservice: UserService) {

  }

  ngOnInit() {

    this.userservice.getIp().subscribe((res) => {
      console.log(res);
      this.userservice.getCurrentUserByIp(res["ip"]).subscribe((user) => {
        if (user != null) {
          localStorage.setItem("user", JSON.stringify(user));
          this.userservice.navigate(JSON.parse(JSON.stringify(user)));
        }
        else this.userservice.navigateToLogin();
      })
    })
    //TODO

  }
}
