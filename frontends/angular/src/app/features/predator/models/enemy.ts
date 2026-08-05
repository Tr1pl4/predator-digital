import { Card } from './card';
import { ESkill, ETeam } from './enum-to-class';

export class Enemy extends Card {
  health = 0;
  team = new ETeam();
  skills: ESkill[] = [];
  faceDown = true;
}
