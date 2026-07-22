using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.PredatorBG.Models.Enums;
using WebAPI.PredatorBG.Services;

namespace WebAPI.PredatorBG.Models
{
    public class PredatorGame
    {
        public Int32 Id { get; set; }

        public Int32 FreeRound { get; set; }

        public Boolean Active { get; set; }

        public Int32 Phase { get; set; }

        public virtual List<Player> Players { get; set; }

        public Int32 ActivePlayer { get; set; }

        public Int32 Result { get; set; }

        public virtual List<Enemy> EnemyDeck { get; set; }

        public virtual List<Enemy> CombatEnemies { get; set; }

        public virtual List<Enemy> Operations { get; set; }

        public Int32 SpecialValue { get; set; }

        public Int32 SpecialMissed { get; set; }

        public virtual Enemy Hills { get; set; }

        public virtual Enemy Ruins { get; set; }

        public virtual Enemy River { get; set; }

        public virtual Enemy Graveyard { get; set; }

        public virtual Enemy Underground { get; set; }

        public virtual List<Enemy> DeadEnemies { get; set; }

        public virtual List<Damage> DamageDeck { get; set; }

        public virtual List<Damage> UsedDamageDeck { get; set; }

        public virtual List<Playable> HQDeck { get; set; }

        public virtual List<Playable> Barrack { get; set; }

        public virtual List<Playable> CommanderDeck { get; set; }

        public virtual List<Card> ObjectiveDeck { get; set; }

        public virtual Location Location { get; set; }

        public void StepPlayer()
        {
            StepPhase();
            var coordinateds = Players[ActivePlayer].EndTurn();
            foreach (Playable card in coordinateds)
            {
                Players[card.CoordinateBy].DisposeDeck.Add(card);
            }
            foreach (Player player in Players)
            {
                player.Coordinated = false;
            }
            if (ActivePlayer == Players.Count - 1)
            {
                ActivePlayer = 0;
            }
            else
            {
                ActivePlayer += 1;
            }
            if (!Players[ActivePlayer].IsAlive())
            {
                if (Players.All(p => !p.IsAlive()))
                {
                    Result = -1;
                    Active = false;
                    return;
                }
                StepPlayer();
            }
            else
            {
                StepPhase();
                Players[ActivePlayer].StartTurn();
            }
        }

        public void StepPhase()
        {
            if (Phase == 0)
            {
                //Új ellenség behozatala
                NewEnemy();

                //Majd Akció Fázis
                Phase += 1;
            }
            else if (Phase == 1)
            {
                //Enemy támad fázis,
                Combat();

                Phase = 0;
            }
        }

        public void NewGame(List<Player> players, Location location, List<Playable> commanderDeck, List<Playable> hqDeck, List<Enemy> enemyDeck, List<Damage> damageDeck, List<Card> objectiveDeck)
        {
            Phase = 0;
            ActivePlayer = 0;
            Players = players;
            EnemyDeck = enemyDeck;
            Result = 0;
            SpecialValue = 0;
            CombatEnemies = new List<Enemy>();
            Operations = new List<Enemy>();
            Hills = null;
            Ruins = null;
            River = null;
            Graveyard = null;
            Underground = null;
            DeadEnemies = new List<Enemy>();
            DamageDeck = damageDeck;
            UsedDamageDeck = new List<Damage>();
            Barrack = hqDeck.Take(5).ToList();
            hqDeck.RemoveRange(0, 5);
            HQDeck = hqDeck;
            CommanderDeck = commanderDeck;
            ObjectiveDeck = objectiveDeck;
            Location = location;
        }

        public void NewEnemy()
        {
            // First check for Runner cards
            if (Hills != null)
            {
                if (Hills.Skills.Any(s => s.Skill == EnemySkill.Runner) && !Hills.FaceDown)
                {
                    Hills.FaceDown = false;
                    if (Hills.Skills.Any(s => s.Skill == EnemySkill.Reveal))
                    {
                        CombatEnemies.Add(Hills);
                        Reveal(Hills);
                    }
                    Hills = null;
                }
            }
            if (Ruins != null)
            {
                if (Ruins.Skills.Any(s => s.Skill == EnemySkill.Runner) && !Ruins.FaceDown)
                {
                    if (Hills != null)
                    {
                        Hills.FaceDown = false;
                        if (Hills.Skills.Any(s => s.Skill == EnemySkill.Reveal))
                        {
                            CombatEnemies.Add(Hills);
                            Reveal(Hills);
                        }
                    }
                    Hills = Ruins;
                    Ruins = null;
                }
            }
            if (River != null)
            {
                if (River.Skills.Any(s => s.Skill == EnemySkill.Runner) && !River.FaceDown)
                {
                    if (Ruins != null)
                    {
                        if (Hills != null)
                        {
                            Hills.FaceDown = false;
                            if (Hills.Skills.Any(s => s.Skill == EnemySkill.Reveal))
                            {
                                CombatEnemies.Add(Hills);
                                Reveal(Hills);
                            }
                        }
                        Hills = Ruins;
                    }
                    Ruins = River;
                    River = null;
                }
            }
            if (Graveyard != null)
            {
                if (Graveyard.Skills.Any(s => s.Skill == EnemySkill.Runner) && !Graveyard.FaceDown)
                {
                    if (River != null)
                    {
                        if (Ruins != null)
                        {
                            if (Hills != null)
                            {
                                Hills.FaceDown = false;
                                if (Hills.Skills.Any(s => s.Skill == EnemySkill.Reveal))
                                {
                                    CombatEnemies.Add(Hills);
                                    Reveal(Hills);
                                }
                            }
                            Hills = Ruins;
                        }
                        Ruins = River;
                    }
                    River = Graveyard;
                    Graveyard = null;
                }
            }
            if (Underground != null)
            {
                if (Underground.Skills.Any(s => s.Skill == EnemySkill.Runner) && !Graveyard.FaceDown)
                {
                    if (Graveyard != null)
                    {
                        if (River != null)
                        {
                            if (Ruins != null)
                            {
                                if (Hills != null)
                                {
                                    Hills.FaceDown = false;
                                    if (Hills.Skills.Any(s => s.Skill == EnemySkill.Reveal))
                                    {
                                        CombatEnemies.Add(Hills);
                                        Reveal(Hills);
                                    }
                                }
                                Hills = Ruins;
                            }
                            Ruins = River;
                        }
                        River = Graveyard;
                    }
                    Graveyard = Underground;
                    Underground = null;
                }
            }

            //After Runners, have a new enemy
            if (EnemyDeck.Count != 0)
            {
                Enemy tmp = EnemyDeck.First();
                tmp.FaceDown = true;
                EnemyDeck.RemoveAt(0);
                if (Underground != null)
                {
                    if (Graveyard != null)
                    {
                        if (River != null)
                        {
                            if (Ruins != null)
                            {
                                if (Hills != null)
                                {
                                    Hills.FaceDown = false;
                                    if (Hills.Skills.Any(s => s.Skill==EnemySkill.Reveal))
                                    {
                                        CombatEnemies.Add(Hills);
                                        Reveal(Hills);
                                    }
                                }
                                Hills = Ruins;
                            }
                            Ruins = River;
                        }
                        River = Graveyard;
                    }
                    Graveyard = Underground;
                }
                Underground = tmp;
            }
            else
            {
                var rnd = new Random();
                DeadEnemies = DeadEnemies.OrderBy(item => rnd.Next()).ToList();
                EnemyDeck.AddRange(DeadEnemies);
                DeadEnemies.Clear();
                NewEnemy();
            }
        }

        public void Combat()
        {
            if (!Players[ActivePlayer].IsAlive())
                return;

            if (Players[ActivePlayer].ActiveCards.Any(c => c.Name == "Put Him On The Payroll"))
                return;

            if (CombatEnemies == null)
                return;
            foreach (Enemy card in CombatEnemies)
            {
                Damaged();

                if (card.Skills.Any(e => e.Skill == EnemySkill.Double_strike))
                {
                    Damaged();
                }
            }
            var filtered = CombatEnemies.Where(e => e.Name == "Almost No Weight. Cuts Like Steel.").ToList();
            if (filtered.Count > 0)
                DeadEnemies.AddRange(filtered);
            CombatEnemies.RemoveAll(e => e.Name == "Almost No Weight. Cuts Like Steel.");
        }

        public void Damaged()
        {
            if (!(DamageDeck.Count > 0))
            {
                var rnd = new Random();
                UsedDamageDeck.OrderBy(item => rnd.Next());
                DamageDeck.AddRange(UsedDamageDeck);
                UsedDamageDeck.Clear();
                Damaged();
            }
            else
            {
                var tmp = DamageDeck.First();
                DamageDeck.RemoveAt(0);
                if (tmp.Name == "Close Call")
                {
                    if (CombatEnemies.Any(e => e.Name == "One At A Time"))
                    {
                        Damaged();
                    }
                    UsedDamageDeck.Add(tmp);
                    return;
                }
                if (Players[ActivePlayer].Avoid > 0)
                {
                    UsedDamageDeck.Add(tmp);
                }

                var survive = Players[ActivePlayer].Damage(tmp);
                if (survive)
                {
                    if (tmp.Skills.Any(s => s.Skill == DamageSkill.Mark))
                    {
                        if (Players[ActivePlayer].MarkNum != 0)
                        {
                            for (int i = 0; i < Players[ActivePlayer].MarkNum; i++)
                            {
                                Damaged();
                            }
                        }
                    }
                }
            }
        }

        public void Heal(Player from, Player to)
        {
            if (from.Heal > 0 && to.Injuries.Count > 0)
            {
                from.Heal -= 1;
                var damage = to.Healed();
                UsedDamageDeck.Add(damage);
            }
        }

        public void HealMin(Player from, Player to)
        {
            if (from.HealMin > 0 && to.Injuries.Count > 0)
            {
                from.HealMin -= 1;
                var damage = to.HealedMin();
                UsedDamageDeck.Add(damage);
            }
        }

        public bool Attack(Enemy enemy)
        {
            if (enemy.Name == "Val Verde Guerilla")
            {
                var check = new List<Enemy>();
                if (Hills != null)
                    check.Add(Hills);
                if (Ruins != null)
                    check.Add(Ruins);
                if (River != null)
                    check.Add(River);
                if (Graveyard != null)
                    check.Add(Graveyard);
                if (Underground != null)
                    check.Add(Underground);
                if (check.Any(e => e.Name == "Soviet Advisor" && !e.FaceDown) || CombatEnemies.Any(e => e.Name == "Soviet Advisor"))
                {
                    enemy.Health += 1;
                }
            }

            if (enemy.Name == "One Big Ugly Mother...")
            {
                for (int i = 0; i< Players[ActivePlayer].MarkNum; i++)
                {
                    Damaged();
                }
                if (!Players[ActivePlayer].IsAlive())
                {
                    StepPlayer();
                    return false;
                }
                var check = new List<Enemy>();
                if (Hills != null)
                    check.Add(Hills);
                if (Ruins != null)
                    check.Add(Ruins);
                if (River != null)
                    check.Add(River);
                if (Graveyard != null)
                    check.Add(Graveyard);
                if (Underground != null)
                    check.Add(Underground);
                if (check.Any(e => e.Name == "No Killing What Can't Be Killed" && !e.FaceDown) || CombatEnemies.Any(e => e.Name == "No Killing What Can't Be Killed"))
                {
                    return false;
                }
            }

            if (Players[ActivePlayer].ActiveCards.Any(c => c.Name == "Knock Knock"))
                enemy.Health -= 1;

            bool success = Players[ActivePlayer].Attack(enemy);
            if (success)
            {
                if (enemy.Name == "One Ugly Mother...")
                {
                    Active = false;
                    Result = 1;
                }

                if (enemy.Name == "One Big Ugly Mother...")
                {
                    Active = false;
                    Result = 1;
                }

                if (enemy.Skills.Any(s => s.Skill == EnemySkill.Death))
                {
                    if (enemy.Name == "Val Verde Guerilla")
                    {
                        if (Operations != null)
                        {
                            if (Operations.Where(e => e.Name == "Guerilla Camp").ToList().Count > 0)
                            {
                                SpecialValue -= 1;
                            }
                            else
                            {
                                Damaged();
                            }
                        }
                    }
                    if (enemy.Name == "Scorpion Enforcer")
                    {
                        Players[ActivePlayer].DisposeDeck.Add(Players[ActivePlayer].DrawDeck.First());
                        Players[ActivePlayer].DrawDeck.RemoveAt(0);

                        var check = new List<Enemy>();
                        if (Hills != null)
                            check.Add(Hills);
                        if (Ruins != null)
                            check.Add(Ruins);
                        if (River != null)
                            check.Add(River);
                        if (Graveyard != null)
                            check.Add(Graveyard);
                        if (Underground != null)
                            check.Add(Underground);
                        if (check.Any(e => e.Name == "El Scorpio" && !e.FaceDown) || CombatEnemies.Any(e => e.Name == "El Scorpio"))
                        {
                            Damaged();
                        }
                    }
                    if (enemy.Name == "Something Out There Waiting For Us") {
                        if (!Players[ActivePlayer].ActiveCards.Any(c => c.Class.Class == PlayableClass.Green))
                        {
                            NewEnemy();
                        }
                    }
                    if (enemy.Name == "The Eyes Of The Demon")
                    {
                        if (!Players[ActivePlayer].ActiveCards.Any(c => c.Class.Class == PlayableClass.Red))
                        {
                            Damaged();
                        }
                    }
                    if (enemy.Name == "The Eyes Of The Demon")
                    {
                        if (!Players[ActivePlayer].ActiveCards.Any(c => c.Class.Class == PlayableClass.Red))
                        {
                            Damaged();
                        }
                    }
                    if (enemy.Name == "Fun And Games")
                    {
                        if (!Players[ActivePlayer].ActiveCards.Any(c => c.Class.Class == PlayableClass.Yellow))
                        {
                            Hills.FaceDown = true;
                            Ruins.FaceDown = true;
                            River.FaceDown = true;
                            Graveyard.FaceDown = true;
                            Underground.FaceDown = true;
                        }
                    }
                }

                if (CombatEnemies.Contains(enemy))
                {
                    DeadEnemies.Add(enemy);
                    CombatEnemies.Remove(enemy);
                }
                else
                {
                    DeadEnemies.Add(enemy);
                }
            }
            else
            {
                if (Players[ActivePlayer].ActiveCards.Any(c => c.Name == "Knock Knock"))
                    enemy.Health += 1;
            }
            return success;
        }

        public void Scann(Enemy enemy, string location)
        {
            int expensive = 0;
            var check = new List<Enemy>();
            if (Hills != null)
                check.Add(Hills);
            if (Ruins != null)
                check.Add(Ruins);
            if (River != null)
                check.Add(River);
            if (Graveyard != null)
                check.Add(Graveyard);
            if (Underground != null)
                check.Add(Underground);
            if (check.Any(e => e.Name == "Not A Single Track" && !e.FaceDown) || CombatEnemies.Any(e => e.Name == "Not A Single Track"))
            {
                expensive = 2;
            }

            int price = 0;
            switch (location)
            {
                case "Hills":
                    price = 2;
                    break;
                case "Ruins":
                    price = 2;
                    break;
                case "River":
                    price = 3;
                    break;
                case "Graveyard":
                    price = 3;
                    break;
                case "Underground":
                    price = 4;
                    break;
            }

            bool success = Players[ActivePlayer].Scann(price + expensive);
            if (success)
            {
                enemy.FaceDown = false;
                if (enemy.Name == "Event" || 
                    enemy.Name == "Hazard" || 
                    enemy.Name == "Guerilla Camp" || 
                    enemy.Name == "Defensive Position" || 
                    enemy.Name == "Assault The Stronghold" ||
                    enemy.Name == "Forensic Analysis" ||
                    enemy.Name == "Physical Evidence" ||
                    enemy.Name == "Witness Testimony")
                {
                    switch (location)
                    {
                        case "Hills":
                            Hills = null;
                            break;
                        case "Ruins":
                            Ruins = null;
                            break;
                        case "River":
                            River = null;
                            break;
                        case "Graveyard":
                            Graveyard = null;
                            break;
                        case "Underground":
                            Underground = null;
                            break;
                    }
                }
                if (enemy.Name == "Over Here")
                {
                    enemy.FaceDown = true;
                    Damaged();
                    return;
                }

                if (enemy.Skills.Any(e => e.Skill == EnemySkill.Reveal))
                {
                    Reveal(enemy);
                }
            }
        }

        public void Reveal(Enemy enemy)
        {
            enemy.FaceDown = false;
            if (enemy.Name == "Event")
            {
                CombatEnemies.Remove(enemy);
                if (ObjectiveDeck != null)
                {
                    if (ObjectiveDeck[0].Name == "Expendable Assets")
                    {
                        if (Operations.Count > 0)
                        {
                            if (Operations.Any(e => e.Name == "Guerilla Camp"))
                            {
                                SpecialValue += 1;
                            }
                        }
                        DeadEnemies.Add(enemy);
                    }
                    else if (ObjectiveDeck[0].Name == "Flares, Frags, and Claymores")
                    {
                        if (EnemyDeck.Count != 0)
                        {
                            Enemy tmp = EnemyDeck.First();
                            tmp.FaceDown = true;
                            EnemyDeck.RemoveAt(0);
                            if (Hills != null)
                            {
                                CombatEnemies.Add(Hills);
                            }
                            Hills = tmp;
                        }
                        DeadEnemies.Add(enemy);
                    }
                    else if (ObjectiveDeck[0].Name == "Get To The Choppa!")
                    {
                        if (Players[ActivePlayer].MarkNum > 0)
                        {
                            for (int i = 0; i < Players[ActivePlayer].MarkNum; i++)
                            {
                                Damaged();
                            }
                        }
                        DeadEnemies.Add(enemy);
                    }
                    else if (ObjectiveDeck[0].Name == "War Zone")
                    {
                        Operations.Add(enemy);
                    }
                    else if (ObjectiveDeck[0].Name == "Personal Little War")
                    {
                        if (Operations.Any(e => e.Name == "Forensic Analysis" ||
                                            e.Name == "Physical Evidence" ||
                                            e.Name == "Witness Testimony"))
                        {
                            var ind = Operations.FindIndex(e => e.Name == "Forensic Analysis" ||
                                            e.Name == "Physical Evidence" ||
                                            e.Name == "Witness Testimony");
                            Operations.RemoveAt(ind);
                            SpecialMissed += 1;
                            SpecialValue -= 1;
                        }
                        DeadEnemies.Add(enemy);
                    }
                    else if (ObjectiveDeck[0].Name == "Other-World Life-Form")
                    {
                        Players[ActivePlayer].MarkNum += 1;
                        DeadEnemies.Add(enemy);
                    }
                }
            }
            else if (enemy.Name == "Hazard")
            {
                CombatEnemies.Remove(enemy);
                DeadEnemies.Add(enemy);
                Players[ActivePlayer].MarkNum += 1;
                var num = Players[ActivePlayer].MarkNum;
                if (Location.Name == "The Val Verdean Jungle")
                {
                    if (Hills != null && num >= 1)
                    {
                        CombatEnemies.Add(Hills);
                        if (Hills.Skills.Any(s => s.Skill == EnemySkill.Reveal))
                            Reveal(Hills);
                        Hills = null;
                        num -= 1;
                    }
                    if ( Ruins != null && num >= 1)
                    {
                        CombatEnemies.Add(Ruins);
                        if (Ruins.Skills.Any(s => s.Skill == EnemySkill.Reveal))
                            Reveal(Ruins);
                        Ruins = null;
                        num -= 1;
                    }
                    if (River != null && num >= 1)
                    {
                        CombatEnemies.Add(River);
                        if (River.Skills.Any(s => s.Skill == EnemySkill.Reveal))
                            Reveal(River);
                        River = null;
                        num -= 1;
                    }
                    if (Graveyard != null && num >= 1)
                    {
                        CombatEnemies.Add(Graveyard);
                        if (Graveyard.Skills.Any(s => s.Skill == EnemySkill.Reveal))
                            Reveal(Graveyard);
                        Graveyard = null;
                        num -= 1;
                    }
                    if (Underground != null && num >= 1)
                    {
                        CombatEnemies.Add(Underground);
                        if (Underground.Skills.Any(s => s.Skill == EnemySkill.Reveal))
                            Reveal(Underground);
                        Underground = null;
                        num -= 1;
                    }
                }
                else
                {
                    for (int i=0; i<num; i++)
                    {
                        NewEnemy();
                    }
                }
            }
            if (enemy.Name == "No Stopping What Can't Be Stopped")
            {
                StepPlayer();
            }

            if (enemy.Name == "Guerilla Camp")
            {
                CombatEnemies.Remove(enemy);
                Operations.Add(enemy);
                SpecialValue = 3;
            }
            if (enemy.Name == "Defensive Position")
            {
                CombatEnemies.Remove(enemy);
                Operations.Add(enemy);
            }
            if (enemy.Name == "Assault The Stronghold")
            {
                CombatEnemies.Remove(enemy);
                Operations.Add(enemy);
            }

            if (enemy.Name == "Forensic Analysis" ||
                    enemy.Name == "Physical Evidence" ||
                    enemy.Name == "Witness Testimony")
            {
                if(CombatEnemies.Contains(enemy))
                {
                    CombatEnemies.Remove(enemy);
                    SpecialMissed += 1;
                }
                else
                {
                    Operations.Add(enemy);
                    SpecialValue += 1;
                }

                if (SpecialValue + SpecialMissed == 3)
                {
                    foreach (Player player in Players)
                    {
                        player.Hand.AddRange(player.DrawDeck.Take(SpecialValue));
                        player.DrawDeck.RemoveRange(0, SpecialValue);
                    }
                    Operations.RemoveAll(e => enemy.Name == "Forensic Analysis" ||
                                              enemy.Name == "Physical Evidence" ||
                                              enemy.Name == "Witness Testimony");
                }
            }
        }

        public void Buy(Playable card)
        {
            bool success = Players[ActivePlayer].Buy(card);
            if (success)
            {
                if (Barrack.Contains(card))
                {
                    Barrack.Remove(card);
                    if (HQDeck.Count > 0)
                    {
                        Barrack.Add(HQDeck.First());
                        HQDeck.RemoveAt(0);
                    }
                }
                else if (CommanderDeck.Contains(card))
                {
                    CommanderDeck.Remove(card);
                }
            }
        }

        public void Play(Playable card)
        {
            Players[ActivePlayer].Play(card);
        }

        public void Activate(Playable card)
        {
            if (card.Name == "Ain't Got Time To Bleed")
            {
                var res = 0;
                var tmp = DamageDeck.First();
                res += tmp.Dmg;
                DamageDeck.RemoveAt(0);
                UsedDamageDeck.Add(tmp);

                tmp = DamageDeck.First();
                res += tmp.Dmg;
                DamageDeck.RemoveAt(0);
                UsedDamageDeck.Add(tmp);

                Players[ActivePlayer].CurAtt += res;
            }

            Players[ActivePlayer].Activate(card);

            if (!card.Activated)
            {
                var ind = Players[ActivePlayer].ActiveCards.FindIndex(c => c.Name == card.Name && c.Activated == false);
                Players[ActivePlayer].ActiveCards[ind].Activated = true;
            }
        }

        public void Coordinate(Player from, Player to, Playable toCoord)
        {
            var success = false;
            var check = new List<Enemy>();
            if (Hills != null)
                check.Add(Hills);
            if (Ruins != null)
                check.Add(Ruins);
            if (River != null)
                check.Add(River);
            if (Graveyard != null)
                check.Add(Graveyard);
            if (Underground != null)
                check.Add(Underground);
            if (check.Any(e => e.Name == "A World Of Hurt" && !e.FaceDown) || CombatEnemies.Any(e => e.Name == "A World Of Hurt"))
            {
                success = from.Coordinate(toCoord, false);
            }
            else
            {
                success = from.Coordinate(toCoord);
            }
            
            if (success)
            {
                if (check.Any(e => e.Name == "City Of Fear" && !e.FaceDown) || CombatEnemies.Any(e => e.Name == "City Of Fear"))
                {
                    Damaged();
                }
                toCoord.CoordinateBy = Players.IndexOf(from);
                to.Play(toCoord);
                to.GotCoord += 1;
            }
        }

        public void Kill(Playable card, string location)
        {
            Players[ActivePlayer].Killed(card, location);
        }

        public void Convert(Playable card)
        {
            Players[ActivePlayer].CurAtt -= card.AttPoint;
            Players[ActivePlayer].CurAtt += card.RecPoint;

            Players[ActivePlayer].CurRec += card.AttPoint;
            Players[ActivePlayer].CurRec -= card.RecPoint;

            Players[ActivePlayer].Convert -= 1;
        }

        public void Check(Enemy enemy)
        {
            if (enemy.Name == "Guerilla Camp")
            {
                var isFree = false;

                switch (SpecialValue)
                {
                    case 1:
                        isFree = (Hills == null);
                        break;
                    case 2:
                        isFree = (Ruins == null);
                        break;
                    case 3:
                        isFree = (River == null);
                        break;
                    case 4:
                        isFree = (Graveyard == null);
                        break;
                    case 5:
                        isFree = (Underground == null);
                        break;
                }
                if (isFree && Players[ActivePlayer].CurAtt > 0)
                {
                    Players[ActivePlayer].CurAtt -= 1;
                    Operations.Remove(enemy);
                    ObjectiveDeck.RemoveAt(0);
                }
            }
            else if (enemy.Name == "Defensive Position")
            {
                if (Hills == null && Players[ActivePlayer].CurRec > 5)
                {
                    Players[ActivePlayer].CurRec -= 6;
                    Operations.Remove(enemy);
                    ObjectiveDeck.RemoveAt(0);
                }
            }
            else if (enemy.Name == "Assault The Stronghold")
            {
                var flipped = new List<Playable>();
                foreach(Player player in Players)
                {
                    flipped.Add(player.DrawDeck.First());
                    player.DisposeDeck.Add(player.DrawDeck.First());
                    player.DrawDeck.RemoveAt(0);
                }
                var tmpAtt = 0;
                var tmpRec = 0;
                foreach (Playable card in flipped)
                {
                    tmpAtt += card.AttPoint;
                    tmpRec += card.RecPoint;
                }

                if (tmpAtt >= tmpRec)
                {
                    if (Operations.Any(e => e.Name == "Event"))
                    {
                        var index = Operations.FindIndex(e => e.Name == "Event");
                        Operations.RemoveAt(index);
                    }
                    else
                    {
                        Operations.Remove(enemy);
                        ObjectiveDeck.RemoveAt(0);
                    }
                }
            }
        }
    }
}
