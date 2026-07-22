import { DamageSkill, EnemySkill, EnemyTeam, PlayableCharacter, PlayableClass, PlayableSkill, PlayableTeam } from "./Enums";

export class DSkill {
  id: number;
  skill: DamageSkill;
}

export class ESkill {
  id: number;
  skill: EnemySkill;
}

export class ETeam {
  id: number;
  team: EnemyTeam;
}

export class PSkill {
  id: number;
  skill: PlayableSkill;
}

export class PChar {
  id: number;
  character: PlayableCharacter;
}

export class PTeam {
  id: number;
  team: PlayableTeam;
}

export class PClass {
  id: number;
  class: PlayableClass;
}
