import { Card } from "./Card";
import { Damage } from "./Damage";
import { Enemy } from "./Enemy";
import { Location } from "./Location";
import { Playable } from "./Playable";
import { Player } from "./Player";

export class Game {
  id: number;
  freeRound: number;
  active: boolean;
  phase: number;
  players: Array<Player>;
  activePlayer: number;
  result: number;
  enemyDeck: Array<Enemy>;
  combatEnemies: Array<Enemy>;
  operations: Array<Enemy>;
  specialValue: number;
  specialMissed: number;
  hills: Enemy;
  ruins: Enemy;
  river: Enemy;
  graveyard: Enemy;
  underground: Enemy;
  deadEnemies: Array<Enemy>;
  damageDeck: Array<Damage>;
  usedDamageDeck: Array<Damage>;
  hqDeck: Array<Playable>;
  barrack: Array<Playable>;
  commanderDeck: Array<Playable>;
  objectiveDeck: Array<Card>;
  location: Location;
}
