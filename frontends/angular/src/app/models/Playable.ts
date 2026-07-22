import { Card } from "./Card";
import { PChar, PClass, PTeam, PSkill } from "./EnumToClass";

export class Playable extends Card {
  character: PChar;
  class: PClass;
  team: PTeam;
  attPoint: number;
  recPoint: number;
  activated: boolean;
  coordinatedBy: number;
  price: number;
  skills: Array<PSkill>;
}
