import { Card } from './card';
import { Damage } from './damage';
import { Enemy } from './enemy';
import { Location } from './location';
import { Playable } from './playable';
import { Player } from './player';

export class Game {
  id = 0;
  freeRound = 0;
  active = false;
  phase = 0;
  players: Player[] = [];
  activePlayer = 0;
  result = 0;
  enemyDeck: Enemy[] = [];
  combatEnemies: Enemy[] = [];
  operations: Enemy[] = [];
  specialValue = 0;
  specialMissed = 0;
  hills: Enemy | null = null;
  ruins: Enemy | null = null;
  river: Enemy | null = null;
  graveyard: Enemy | null = null;
  underground: Enemy | null = null;
  deadEnemies: Enemy[] = [];
  damageDeck: Damage[] = [];
  usedDamageDeck: Damage[] = [];
  hqDeck: Playable[] = [];
  barrack: Playable[] = [];
  commanderDeck: Playable[] = [];
  objectiveDeck: Card[] = [];
  location = new Location();
}
