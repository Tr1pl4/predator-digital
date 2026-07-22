import { Card } from "./Card";
import { DSkill } from "./EnumToClass";

export class Damage extends Card {
  dmg: number;
  skills: Array<DSkill>;
}
