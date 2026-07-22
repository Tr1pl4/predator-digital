import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.css']
})
export class GalleryComponent implements OnInit {
  images = [
    {
      url: '../../../assets/games-img/predator-preview.jpg'
    },
    {
      url: '../../../assets/games-img/predator-game1.png'
    },
    {
      url: '../../../assets/games-img/predator-game2.png'
    },
    {
      url: '../../../assets/games-img/predator-game3.png'
    },
    {
      url: '../../../assets/games-img/predator-game4.png'
    },
    {
      url: '../../../assets/games-img/predator-game5.png'
    },
    {
      url: '../../../assets/games-img/predator-game6.png'
    },
    {
      url: '../../../assets/games-img/predator-game7.png'
    },
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
