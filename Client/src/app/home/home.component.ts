import { Component, OnInit } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {

  constructor() { }

  customOptions: OwlOptions  = {
    loop: true,
    items: 1,
    autoplay: true,
    smartSpeed: 1500,
    nav: false,
    dots: false,
    autoplayHoverPause: true,
  };

  ngOnInit(): void {
  }

}
