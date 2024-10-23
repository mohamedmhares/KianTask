import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  slides = [
    { image: 'assets/images/1.png',
       title: 'First Slide',
       description: 'Description for the first slide.' },
    { image: 'assets/images/2.png',
       title: 'Second Slide',
       description: 'Description for the second slide.' },
    { image: 'assets/images/3.png',
        title: 'Third Slide',
        description: 'Description for the third slide.' }
  ];
}
