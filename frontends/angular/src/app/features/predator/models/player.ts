import { Damage } from './damage';
import { Playable } from './playable';

export class Player {
  id = 0;
  health = 0;
  armor = 0;
  imagepath = '';
  curAtt = 0;
  curRec = 0;
  onTurn = false;
  avoid = 0;
  scan = 0;
  markNum = 0;
  heal = 0;
  healMin = 0;
  kill = 0;
  convert = 0;
  free = 0;
  coordinated = false;
  gotCoord = 0;
  drawDeck: Playable[] = [];
  disposeDeck: Playable[] = [];
  hand: Playable[] = [];
  activeCards: Playable[] = [];
  injuries: Damage[] = [];
}
