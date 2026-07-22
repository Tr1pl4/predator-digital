import { Damage } from "./Damage";
import { Playable } from "./Playable";

export class Player{
  id: number;
  health: number;
  armor: number;
  imagepath: string;
  curAtt: number;
  curRec: number;
  onTurn: boolean;
  avoid: number;
  scan: number;
  markNum: number;
  heal: number;
  healMin: number;
  kill: number;
  convert: number;
  free: number;
  coordinated: boolean;
  gotCoord: number;
  drawDeck: Array<Playable>;
  disposeDeck: Array<Playable>;
  hand: Array<Playable>;
  activeCards: Array<Playable>;
  injuries: Array<Damage>
}