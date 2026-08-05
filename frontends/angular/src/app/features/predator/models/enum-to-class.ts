import {
  DamageSkill,
  EnemySkill,
  EnemyTeam,
  PlayableCharacter,
  PlayableClass,
  PlayableSkill,
  PlayableTeam
} from './enums';

export class DSkill {
  id = 0;
  skill: DamageSkill = DamageSkill.None;
}

export class ESkill {
  id = 0;
  skill: EnemySkill = EnemySkill.None;
}

export class ETeam {
  id = 0;
  team: EnemyTeam = EnemyTeam.Young_blood;
}

export class PSkill {
  id = 0;
  skill: PlayableSkill = PlayableSkill.None;
}

export class PChar {
  id = 0;
  character: PlayableCharacter = PlayableCharacter.None;
}

export class PTeam {
  id = 0;
  team: PlayableTeam = PlayableTeam.None;
}

export class PClass {
  id = 0;
  class: PlayableClass = PlayableClass.None;
}
