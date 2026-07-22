import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-gamelist',
  templateUrl: './gamelist.component.html',
  styleUrls: ['./gamelist.component.css']
})
export class GamelistComponent implements OnInit {
  availableGames = [
    {
      name: 'Legendary Encounters A Predator...',
      imgUrl: '../../../assets/games-img/predator-preview.jpg',
      lobbyUrl: '../predator',
      description: `Legendary Encounters: A Predator Deck Building Game (COOPERATIVE VERSION)
      is based on the first two movies of the Predator series. Taking on the roles of the
      characters from the films, players take turns recruiting cards for their deck from a central
      selection in order to improve their deck and defeat Predator cards that are added to the central
      game board. In more detail, within the setting for each film you can play as the humans.
      As the humans, you play the game by: recruiting, scanning and attacking the while trying to
      achieve objectives, and staying alive.`,
      playerNum: '1-5',
      averageTime: '45 minutes'
    },
    {
      name: 'Legendary Encounters A Predator (COPY - 1)...',
      imgUrl: '../../../assets/games-img/predator-preview.jpg',
      lobbyUrl: '../predator',
      description: `Legendary Encounters: A Predator Deck Building Game (COOPERATIVE VERSION)
      is based on the first two movies of the Predator series. Taking on the roles of the
      characters from the films, players take turns recruiting cards for their deck from a central
      selection in order to improve their deck and defeat Predator cards that are added to the central
      game board. In more detail, within the setting for each film you can play as the humans.
      As the humans, you play the game by: recruiting, scanning and attacking the while trying to
      achieve objectives, and staying alive.`,
      playerNum: '1-5',
      averageTime: '45 minutes'
    },
    {
      name: 'Legendary Encounters A Predator (COPY - 2)...',
      imgUrl: '../../../assets/games-img/predator-preview.jpg',
      lobbyUrl: '../predator',
      description: `Legendary Encounters: A Predator Deck Building Game (COOPERATIVE VERSION)
      is based on the first two movies of the Predator series. Taking on the roles of the
      characters from the films, players take turns recruiting cards for their deck from a central
      selection in order to improve their deck and defeat Predator cards that are added to the central
      game board. In more detail, within the setting for each film you can play as the humans.
      As the humans, you play the game by: recruiting, scanning and attacking the while trying to
      achieve objectives, and staying alive.`,
      playerNum: '1-5',
      averageTime: '45 minutes'
    },
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
