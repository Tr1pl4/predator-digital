import { Card } from './card';
import { DSkill } from './enum-to-class';

export class Damage extends Card {
  dmg = 0;
  skills: DSkill[] = [];
}
