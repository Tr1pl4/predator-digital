import { Card } from "./Card";
import { ESkill, ETeam } from "./EnumToClass";

export class Enemy extends Card {
  health: number;
  team: ETeam;
  skills: Array<ESkill>;
  faceDown: boolean;
}
