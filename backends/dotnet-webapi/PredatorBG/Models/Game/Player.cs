using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebAPI.PredatorBG.Models.Enums;

namespace WebAPI.PredatorBG.Models
{
    public class Player
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public Int32 Health { get; set; }

        [Required]
        public Int32 Armor { get; set; }

        [Required]
        public string Imagepath { get; set; }

        //Turn stats
        public Int32 CurAtt { get; set; }

        public Int32 CurRec { get; set; }

        public Boolean OnTurn { get; set; }

        //Game stats

        public Int32 MarkNum { get; set; }


        //Special Actions
        public Int32 Avoid { get; set; }

        public Int32 Scan { get; set; }

        public Int32 Kill { get; set; }

        public Int32 Convert { get; set; }

        public Int32 Heal { get; set; }

        public Int32 HealMin { get; set; }

        public Int32 Free { get; set; }

        //For Cooperation
        public Boolean Coordinated { get; set; }

        public Int32 GotCoord { get; set; }

        //In-game card representation
        public virtual List<Playable> DrawDeck { get; set; }

        public virtual List<Playable> DisposeDeck { get; set; }

        public virtual List<Playable> Hand { get; set; }

        public virtual List<Playable> ActiveCards { get; set; }

        public virtual List<Damage> Injuries { get; set; }
        
        public void newPlayer(Avatar avatar, List<Playable> drawDeck, List<Playable> hand)
        {
            Health = avatar.Health;
            Armor = avatar.Armor;
            Imagepath = avatar.Imagepath;
            DrawDeck = drawDeck;
            MarkNum = 0;
            DisposeDeck = new List<Playable>();
            ActiveCards = new List<Playable>();
            Injuries = new List<Damage>();
            Hand = hand;
            CurRec = 0;
            CurAtt = 0;
            OnTurn = false;
            Avoid = 0;
            Scan = 0;
            Kill = 0;
            Heal = 0;
            HealMin = 0;
            Free = 0;
            Coordinated = false;
            GotCoord = 0;
        }

        //functions
        public void StartTurn()
        {
            OnTurn = true;
        }

        public List<Playable> EndTurn()
        {
            CurAtt = 0;
            CurRec = 0;
            OnTurn = false;
            Avoid = 0;
            Free = 0;
            Scan = 0;
            Kill = 0;
            Heal = 0;
            HealMin = 0;
            Coordinated = false;
            GotCoord = 0;
            var tmp = Draw();

            return tmp;
        }

        public List<Playable> Draw()
        {
            var coordinatedCards = ActiveCards.Where(c => c.CoordinateBy != -1).ToList();
            ActiveCards = ActiveCards.Where(c => c.CoordinateBy == -1).ToList();

            DisposeDeck.AddRange(ActiveCards);
            ActiveCards.Clear();
            DisposeDeck.AddRange(Hand);
            Hand.Clear();
            if (DrawDeck.Count >= 6)
            {
                Hand.AddRange(DrawDeck.Take(6));
                DrawDeck.RemoveRange(0, 6);
            }
            else
            {
                int num = DrawDeck.Count;
                Hand.AddRange(DrawDeck.Take(num));
                DrawDeck.Clear();
                DrawDeck.AddRange(DisposeDeck);
                DisposeDeck.Clear();

                var rnd = new Random();
                DrawDeck = DrawDeck.OrderBy(item => rnd.Next()).ToList();
                Hand.AddRange(DrawDeck.Take(6 - num));
                DrawDeck.RemoveRange(0, 6 - num);

                foreach (Playable card in Hand)
                {
                    card.CoordinateBy = -1;
                }
            }

            return coordinatedCards;
        }

        public void Play(Playable toPlay)
        {
            Hand.Remove(toPlay);

            toPlay.Activated = false;
            ActiveCards.Add(toPlay);
            CurAtt += toPlay.AttPoint;
            CurRec += toPlay.RecPoint;
        }

        public void Activate(Playable active)
        {
            if (active.Activated)
                return;

            if (active.Skills.Any(a => a.Skill == PlayableSkill.Call_for_backup))
            {
                if (active.Name.Equals("Position And Situation"))
                {
                    DrawDeck.Reverse();
                    DrawDeck.AddRange(DisposeDeck.TakeLast(GotCoord));
                    DrawDeck.Reverse();
                    DisposeDeck.RemoveRange(DisposeDeck.Count - GotCoord, GotCoord);
                }
                if (active.Name.Equals("In The Shadows"))
                {
                    Avoid += GotCoord;
                }
                if (active.Name.Equals("Command Decisions"))
                {
                    CurRec += 2 * GotCoord;
                }
                if (active.Name.Equals("Fighting The Good Fight"))
                {
                    CurAtt += GotCoord;
                }
                if (active.Name.Equals("Sources And Contacts"))
                {
                    Heal += GotCoord;
                }
                if (active.Name.Equals("It Ain't No Man"))
                {
                    Scan += GotCoord;
                }
                if (active.Name.Equals("Partners In Crime"))
                {
                    Free += GotCoord;
                }
                if (active.Name.Equals("Knocking On Doors"))
                {
                    Hand.AddRange(DrawDeck.Take(GotCoord));
                    DrawDeck.RemoveRange(0, GotCoord);
                }
                if (active.Name.Equals("The Highest Tech"))
                {
                    Convert += GotCoord;
                }
                if (active.Name.Equals("Running The Streets"))
                {
                    Kill += GotCoord;
                }
            }
            if (active.Skills.Any(a => a.Skill == PlayableSkill.Brothers_in_arms))
            {
                Int32 mul = ActiveCards.Select(item => item.Character.Character)
                    .Distinct()
                    .ToList()
                    .Count;

                if (active.Name.Equals("I See You"))
                {
                    Heal += mul;
                }
                if (active.Name.Equals("Before Anybody Knows We Were There"))
                {
                    CurRec += mul * 2;
                }
                if (active.Name.Equals("Bad Idea"))
                {
                    CurAtt += mul * 2;
                }
                if (active.Name.Equals("Dug In Like An Alabama Tick"))
                {
                    Scan += mul;
                }
            }
            if (active.Skills.Any(a => a.Skill == PlayableSkill.Gray))
            {
                if (ActiveCards.Any(c => c.Class.Class == PlayableClass.Gray))
                {
                    if (active.Name.Equals("Jurisdictional Intrusion"))
                    {
                        var tmp = DrawDeck.First();
                        DrawDeck.RemoveAt(0);
                        Hand.Add(tmp);
                        while (tmp.Name != "Experience" || tmp.Name != "Brute Strength")
                        {
                            tmp = DrawDeck.First();
                            DrawDeck.RemoveAt(0);
                            Hand.Add(tmp);
                        }
                    }
                }
            }
            if (active.Skills.Any(a => a.Skill == PlayableSkill.Red))
            {
                if (ActiveCards.Any(c => c.Class.Class == PlayableClass.Red))
                {
                    if (active.Name.Equals("Sexual Tyrannosaurus"))
                    {
                        HealMin += 1;
                    }
                }
            }
            if (active.Skills.Any(a => a.Skill == PlayableSkill.Coordinate))
            {
                if (active.Name == "Gonna Cut Your Name Into Him!")
                {
                    Hand.AddRange(DrawDeck.Take(1));
                    DrawDeck.RemoveRange(0, 1);
                }
                if (active.Name == "Real Nasty Habit")
                {
                    Avoid += 1;
                }
                if (active.Name == "Take A Good Look")
                {
                    Hand.AddRange(DrawDeck.Take(1));
                    DrawDeck.RemoveRange(0, 1);
                }
            }
            if (active.Skills.Any(a => a.Skill == PlayableSkill.Harrigan))
            {
                if (ActiveCards.Any(c => c.Team.Team == PlayableTeam.Harrigan))
                    HealMin += 1;
            }
            if (active.Skills.Any(a => a.Skill == PlayableSkill.Showboat))
            {
                Int32 mul = ActiveCards.Where(item => item.Character.Character == active.Character.Character)
                    .Select(item => item.Name)
                    .Distinct()
                    .ToList()
                    .Count;
                if (active.Name.Equals("Now It's Personal"))
                {
                    CurAtt += mul;
                }
                if (active.Name.Equals("Fifteen Years On The Street"))
                {
                    CurRec += mul;
                }
                if (active.Name.Equals("Enjoy The Show"))
                {
                    Scan += mul;
                }
                if (active.Name.Equals("No Autographs"))
                {
                    Heal += mul;
                }
            }
            if (active.Name.Equals("I'm Gonna Finish It"))
            {
                CurAtt += CurAtt;
            }
        }

        public bool Coordinate(Playable toCoord, bool canDraw = true)
        {
            if (!Coordinated)
            {
                Hand.Remove(toCoord);
                if (canDraw)
                {
                    Hand.AddRange(DrawDeck.Take(1));
                    DrawDeck.RemoveRange(0, 1);
                }
                Coordinated = true;
                return true;
            }
            return false;
        }

        public bool Buy(Playable bought)
        {
            if (Free >= 1 && bought.Price <= 3)
            {
                Free -= 1;
                var blues = ActiveCards.Where(c => c.Class.Class == PlayableClass.Blue && c.Name != "Luck Is My Specialty").ToList();
                if (ActiveCards.Any(c => c.Name == "Luck Is My Specialty" && c.Activated) && blues.Count > 0)
                {
                    var tmp = new List<Playable>();
                    tmp.Add(bought);
                    tmp.AddRange(DrawDeck);
                    DrawDeck = tmp;
                }
                else
                {
                    DisposeDeck.Add(bought);
                }
                return true;
            }
            else
            {
                if (CurRec >= bought.Price)
                {
                    CurRec -= bought.Price;
                    var blues = ActiveCards.Where(c => c.Class.Class == PlayableClass.Blue && c.Name != "Luck Is My Specialty").ToList();
                    if (ActiveCards.Any(c => c.Name == "Luck Is My Specialty" && c.Activated) && blues.Count > 0)
                    {
                        var tmp = new List<Playable>();
                        tmp.Add(bought);
                        tmp.AddRange(DrawDeck);
                        DrawDeck = tmp;
                    }
                    else
                    {
                        DisposeDeck.Add(bought);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Attack(Enemy enemy)
        {
            if (CurAtt >= enemy.Health)
            {
                CurAtt -= enemy.Health;

                if (enemy.Name == "One Ugly Mother..." && MarkNum > 0)
                {
                    MarkNum -= 1;
                    return false;
                }
                if (enemy.Name == "It Changed Colors")
                {
                    var classes = ActiveCards.Select(item => item.Class.Class)
                    .Distinct()
                    .ToList()
                    .Count;

                    enemy.Health -= 2 * classes;
                }
                
                if (ActiveCards.Any(c => c.Name == "Gonna Have Me Some Fun"))
                {
                    var tmp = DrawDeck.Take(2);
                    DrawDeck.RemoveRange(0, 2);
                    Hand.AddRange(tmp);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Killed(Playable toKill, string location)
        {
            if (Kill == 0)
                return;

            if (location == "Hand")
            {
                Hand.Remove(toKill);
                Kill -= 1;
            }
            else
            {
                ActiveCards.Remove(toKill);
                Kill -= 1;
            }
        }

        public bool Scann(Int32 price)
        {
            if (Scan >= 1)
            {
                Scan -= 1;
                return true;
            }
            else
            {
                if (CurAtt >= price)
                {
                    CurAtt -= price;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Damage(Damage injury)
        {
            if (Avoid >= 1)
            {
                Avoid -= 1;
            }
            else
            {
                Injuries.Add(injury);
                Health -= injury.Dmg;
            }
            return IsAlive();
        }
        public Damage HealedMin()
        {
            Damage returnDamage = null;

            var toHeal = 0;
            var priority = Injuries.Where(i => i.Skills.Any(s => s.Skill == DamageSkill.Priority)).ToList();
            if (priority.Count > 0)
            {
                toHeal = Injuries.IndexOf(priority[0]);
                Health += Injuries[toHeal].Dmg;
                Injuries.RemoveAt(toHeal);
                returnDamage = priority[0];
            }
            else
            {
                var findToHeal = Injuries.Where(i => i.Dmg == 3).ToList();
                if (findToHeal.Count > 0)
                {
                    toHeal = Injuries.IndexOf(findToHeal[0]);
                    Health += Injuries[toHeal].Dmg;
                    Injuries.RemoveAt(toHeal);
                    returnDamage = findToHeal[0];
                }
                findToHeal = Injuries.Where(i => i.Dmg == 2).ToList();
                if (findToHeal.Count > 0)
                {
                    toHeal = Injuries.IndexOf(findToHeal[0]);
                    Health += Injuries[toHeal].Dmg;
                    Injuries.RemoveAt(toHeal);
                    returnDamage = findToHeal[0];
                }
                findToHeal = Injuries.Where(i => i.Dmg == 1).ToList();
                if (findToHeal.Count > 0)
                {
                    toHeal = Injuries.IndexOf(findToHeal[0]);
                    Health += Injuries[toHeal].Dmg;
                    Injuries.RemoveAt(toHeal);
                    returnDamage = findToHeal[0];
                }
            }

            return returnDamage;
        }

        public Damage Healed()
        {
            Damage returnDamage = null;

            var toHeal = 0;
            var priority = Injuries.Where(i => i.Skills.Any(s => s.Skill == DamageSkill.Priority)).ToList();
            if (priority.Count > 0)
            {
                toHeal = Injuries.IndexOf(priority[0]);
                Health += Injuries[toHeal].Dmg;
                Injuries.RemoveAt(toHeal);
                returnDamage = priority[0];
            }
            else
            {
                var findToHeal = Injuries.Where(i => i.Dmg == 1).ToList();
                if (findToHeal.Count > 0)
                {
                    toHeal = Injuries.IndexOf(findToHeal[0]);
                    Health += Injuries[toHeal].Dmg;
                    Injuries.RemoveAt(toHeal);
                    returnDamage = findToHeal[0];
                }
                findToHeal = Injuries.Where(i => i.Dmg == 2).ToList();
                if (findToHeal.Count > 0)
                {
                    toHeal = Injuries.IndexOf(findToHeal[0]);
                    Health += Injuries[toHeal].Dmg;
                    Injuries.RemoveAt(toHeal);
                    returnDamage = findToHeal[0];
                }
                findToHeal = Injuries.Where(i => i.Dmg == 3).ToList();
                if (findToHeal.Count > 0)
                {
                    toHeal = Injuries.IndexOf(findToHeal[0]);
                    Health += Injuries[toHeal].Dmg;
                    Injuries.RemoveAt(toHeal);
                    returnDamage = findToHeal[0];
                }
            }

            return returnDamage;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}
