import { Card } from './card';
import { PChar, PClass, PSkill, PTeam } from './enum-to-class';

export class Playable extends Card {
  character = new PChar();
  class = new PClass();
  team = new PTeam();
  attPoint = 0;
  recPoint = 0;
  activated = false;
  coordinatedBy = 0;
  price = 0;
  skills: PSkill[] = [];
}
