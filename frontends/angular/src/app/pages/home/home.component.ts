import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  gamesToPlay = [
    {
      name: 'Predator Game (Cooperative mode)',
      description: 'A Deck building game for 1-5 players. Players cooperate as humans.'
    },
  ];
  gamesToDevelop = [
    {
      name: 'Predator Game (Competitive mode)',
      description: 'A Deck building game for 1-5 players. Players compete as predators.'
    },
    {
      name: 'Alien Game',
      description: 'A Deck building cooperative/competitive game for 1-5 players. "Sibling" of Predator game, can be combined.'
    },
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
