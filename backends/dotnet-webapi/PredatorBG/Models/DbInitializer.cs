using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebAPI.PredatorBG.Models.Enums;

namespace WebAPI.PredatorBG.Models
{
    public class DbInitializer
    {
        public static void Initialize(PredatorBGDbContext context, string imageDirectory)
        {
            // Use only one of the below.
            // Create / update database based on migration classes.
            context.Database.Migrate();
            // Create database if not exists based on current code-first model (no migrations!).
            //context.Database.EnsureCreated();

            if (context.Cards.Any())
            {
                return;
            }

            IList<Location> defaultLocations = new List<Location>
            {
                new Location
                {
                    Name = "The Val Verdean Jungle",
                    Imagepath = Path.Combine(imageDirectory, "TheValVerdeanJungle.png"),

                },
                new Location
                {
                    Name = "The Streets of Los Angeles",
                    Imagepath = Path.Combine(imageDirectory, "TheStreetsOfLosAngeles.png"),
                },
            };

            IList<Avatar> defaulAvatars = new List<Avatar>
            {
                new Avatar
                {
                    Name = "Reporter",
                    Team = 2,
                    Health = 9,
                    Armor = 5,
                    Imagepath =Path.Combine(imageDirectory, "Reporter.png"),
                },

                new Avatar
                {
                    Name = "CIA Agent",
                    Team = 1,
                    Health = 12,
                    Armor = 4,
                    Imagepath = Path.Combine(imageDirectory, "CIAAgent.png"),
                },

                new Avatar
                {
                    Name = "Radioman",
                    Team = 1,
                    Health = 11,
                    Armor = 4,
                    Imagepath = Path.Combine(imageDirectory, "Radioman.png"),
                },

                new Avatar
                {
                    Name = "Gangster",
                    Team = 2,
                    Health = 10,
                    Armor = 4,
                    Imagepath = Path.Combine(imageDirectory, "Gangster.png"),
                },

                new Avatar
                {
                    Name = "Lieutenant",
                    Team = 1,
                    Health = 9,
                    Armor = 5,
                    Imagepath = Path.Combine(imageDirectory, "Lieutenant.png"),
                },

                new Avatar
                {
                    Name = "Guerilla",
                    Team = 1,
                    Health = 10,
                    Armor = 4,
                    Imagepath = Path.Combine(imageDirectory, "Guerilla.png"),
                },

                new Avatar
                {
                    Name = "Tracker",
                    Team = 1,
                    Health = 10,
                    Armor = 4,
                    Imagepath = Path.Combine(imageDirectory, "Tracker.png"),
                },

                new Avatar
                {
                    Name = "O.W.L.F Agent",
                    Team = 2,
                    Health = 11,
                    Armor = 4,
                    Imagepath = Path.Combine(imageDirectory, "O.W.L.FAgent.png"),
                },

                new Avatar
                {
                    Name = "SWAT Officer",
                    Team = 2,
                    Health = 11,
                    Armor = 4,
                    Imagepath = Path.Combine(imageDirectory, "SWATOfficer.png"),
                },

                new Avatar
                {
                    Name = "Detective",
                    Team = 2,
                    Health = 9,
                    Armor = 5,
                    Imagepath = Path.Combine(imageDirectory, "Detective.png"),
                },
            };

            IList<Playable> defaultCards = new List<Playable>
            {

                #region Role cards
                new Playable
                {
                    Name = "Position And Situation",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Call_for_backup }
                    },
                    Imagepath = Path.Combine(imageDirectory, "PositionAndSituation.png"),
                },

                new Playable
                {
                    Name = "In The Shadows",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Call_for_backup }
                    },
                    Imagepath = Path.Combine(imageDirectory, "InTheShadows.png"),
                },

                new Playable
                {
                    Name = "Command Decisions",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Call_for_backup }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CommandDecisions.png"),
                },

                new Playable
                {
                    Name = "Fighting The Good Fight",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Green },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Call_for_backup }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FightingTheGoodFight.png"),
                },

                new Playable
                {
                    Name = "Sources And Contacts",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Call_for_backup }
                    },
                    Imagepath = Path.Combine(imageDirectory, "SourcesAndContacts.png"),
                },

                new Playable
                {
                    Name = "It Ain't No Man",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Yellow },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Call_for_backup }
                    },
                    Imagepath = Path.Combine(imageDirectory, "ItAin'tNoMan.png"),
                },

                new Playable
                {
                    Name = "Running The Streets",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Green },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Call_for_backup }
                    },
                    Imagepath =Path.Combine(imageDirectory, "RunningTheStreets.png"),
                },

                new Playable
                {
                    Name = "Partners In Crime",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Call_for_backup }
                    },
                    Imagepath = Path.Combine(imageDirectory, "PartnersInCrime.png"),
                },

                new Playable
                {
                    Name = "Knocking On Doors",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Yellow },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Call_for_backup }
                    },
                    Imagepath = Path.Combine(imageDirectory, "KnockingOnDoors.png"),
                },

                new Playable
                {
                    Name = "The Highest Tech",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Call_for_backup }
                    },
                    Imagepath = Path.Combine(imageDirectory, "TheHighestTech.png"),
                },

                #endregion

                #region Starting cards
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },
                new Playable
                {
                    Name = "Experience",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "Experience.png"),
                },

                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },
                new Playable
                {
                    Name = "Brute Strength",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.None },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 0,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BruteStrength.png"),
                },

                #endregion

                #region Commanders
                new Playable
                {
                    Name = "Commander",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CommanderBlue.png"),
                },
                new Playable
                {
                    Name = "Commander",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CommanderBlue.png"),
                },

                new Playable
                {
                    Name = "Commander",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Green },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CommanderGreen.png"),
                },
                new Playable
                {
                    Name = "Commander",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Green },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CommanderGreen.png"),
                },

                new Playable
                {
                    Name = "Commander",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CommanderGray.png"),
                },
                new Playable
                {
                    Name = "Commander",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CommanderGray.png"),
                },

                new Playable
                {
                    Name = "Commander",
                   Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CommanderRed.png"),
                },
                new Playable
                {
                    Name = "Commander",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CommanderRed.png"),
                },

                new Playable
                {
                    Name = "Commander",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Yellow },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CommanderYellow.png"),
                },
                new Playable
                {
                    Name = "Commander",
                    Character = new PChar { Character = PlayableCharacter.None },
                    Class = new PClass { Class = PlayableClass.Yellow },
                    Team = new PTeam { Team = PlayableTeam.None },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CommanderYellow.png"),
                },

                #endregion

                #region HeadQuarters
                #region Predator1
                #region Mac
                new Playable
                {
                    Name = "Gonna Have Me Some Fun", //1
                    Character = new PChar { Character = PlayableCharacter.Mac },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 4,
                    RecPoint = 0,
                    Price = 8,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Kill }
                    },
                    Imagepath = Path.Combine(imageDirectory, "GonnaHaveMeSomeFun.png"),
                },

                new Playable
                {
                    Name = "Gonna Cut Your Name Into Him!", // 5
                    Character = new PChar { Character = PlayableCharacter.Mac },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 0,
                    RecPoint = 0,
                    Price = 2,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "GonnaCutYourNameIntoHim!.png"),
                },
                new Playable
                {
                    Name = "Gonna Cut Your Name Into Him!", // 5
                    Character = new PChar { Character = PlayableCharacter.Mac },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 0,
                    RecPoint = 0,
                    Price = 2,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate },
                    },
                    Imagepath = Path.Combine(imageDirectory, "GonnaCutYourNameIntoHim!.png"),
                },
                new Playable
                {
                    Name = "Gonna Cut Your Name Into Him!", // 5
                    Character = new PChar { Character = PlayableCharacter.Mac },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 0,
                    RecPoint = 0,
                    Price = 2,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate },
                    },
                    Imagepath = Path.Combine(imageDirectory, "GonnaCutYourNameIntoHim!.png"),
                },
                new Playable
                {
                    Name = "Gonna Cut Your Name Into Him!", // 5
                    Character = new PChar { Character = PlayableCharacter.Mac },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 0,
                    RecPoint = 0,
                    Price = 2,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate },
                    },
                    Imagepath = Path.Combine(imageDirectory, "GonnaCutYourNameIntoHim!.png"),
                },
                new Playable
                {
                    Name = "Gonna Cut Your Name Into Him!", // 5
                    Character = new PChar { Character = PlayableCharacter.Mac },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 0,
                    RecPoint = 0,
                    Price = 2,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate },
                    },
                    Imagepath = Path.Combine(imageDirectory, "GonnaCutYourNameIntoHim!.png"),
                },

                new Playable
                {
                    Name = "I See You", // 3
                    Character = new PChar { Character = PlayableCharacter.Mac },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 5,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Brothers_in_arms }
                    },
                    Imagepath =Path.Combine(imageDirectory, "ISeeYou.png"),
                },
                new Playable
                {
                    Name = "I See You", // 3
                    Character = new PChar { Character = PlayableCharacter.Mac },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 5,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Brothers_in_arms }
                    },
                    Imagepath =Path.Combine(imageDirectory, "ISeeYou.png"),
                },
                new Playable
                {
                    Name = "I See You", // 3
                    Character = new PChar { Character = PlayableCharacter.Mac },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 5,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Brothers_in_arms }
                    },
                    Imagepath =Path.Combine(imageDirectory, "ISeeYou.png"),
                },

                #endregion

                #region Dillon
                new Playable
                {
                    Name = "Before Anybody Knows We Were There", // 3
                    Character = new PChar { Character = PlayableCharacter.Dillon },
                    Class = new PClass { Class = PlayableClass.Green },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 5,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Brothers_in_arms }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BeforeAnybodyKnowsWeWereThere.png"),
                },
                new Playable
                {
                    Name = "Before Anybody Knows We Were There", // 3
                    Character = new PChar { Character = PlayableCharacter.Dillon },
                    Class = new PClass { Class = PlayableClass.Green },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 5,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Brothers_in_arms }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BeforeAnybodyKnowsWeWereThere.png"),
                },
                new Playable
                {
                    Name = "Before Anybody Knows We Were There", // 3
                    Character = new PChar { Character = PlayableCharacter.Dillon },
                    Class = new PClass { Class = PlayableClass.Green },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 0,
                    RecPoint = 1,
                    Price = 5,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Brothers_in_arms }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BeforeAnybodyKnowsWeWereThere.png"),
                },

                new Playable
                {
                    Name = "Real Nasty Habit", // 5
                    Character = new PChar { Character = PlayableCharacter.Dillon },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate },
                    },
                    Imagepath = Path.Combine(imageDirectory, "RealNastyHabit.png"),
                },
                new Playable
                {
                    Name = "Real Nasty Habit", // 5
                    Character = new PChar { Character = PlayableCharacter.Dillon },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate },
                    },
                    Imagepath = Path.Combine(imageDirectory, "RealNastyHabit.png"),
                },
                new Playable
                {
                    Name = "Real Nasty Habit", // 5
                    Character = new PChar { Character = PlayableCharacter.Dillon },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate },
                    },
                    Imagepath = Path.Combine(imageDirectory, "RealNastyHabit.png"),
                },
                new Playable
                {
                    Name = "Real Nasty Habit", // 5
                    Character = new PChar { Character = PlayableCharacter.Dillon },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate },
                    },
                    Imagepath = Path.Combine(imageDirectory, "RealNastyHabit.png"),
                },
                new Playable
                {
                    Name = "Real Nasty Habit", // 5
                    Character = new PChar { Character = PlayableCharacter.Dillon },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate },
                    },
                    Imagepath = Path.Combine(imageDirectory, "RealNastyHabit.png"),
                },

                #endregion

                #region Dutch
                new Playable
                {
                    Name = "Bad Idea", // 3
                    Character = new PChar { Character = PlayableCharacter.Dutch },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 6,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Brothers_in_arms }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BadIdea.png"),
                },
                new Playable
                {
                    Name = "Bad Idea", // 3
                    Character = new PChar { Character = PlayableCharacter.Dutch },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 6,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Brothers_in_arms }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BadIdea.png"),
                },
                new Playable
                {
                    Name = "Bad Idea", // 3
                    Character = new PChar { Character = PlayableCharacter.Dutch },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 6,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Brothers_in_arms }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BadIdea.png"),
                },

                new Playable
                {
                    Name = "Knock Knock", // 5
                    Character = new PChar { Character = PlayableCharacter.Dutch },
                    Class = new PClass { Class = PlayableClass.Green },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None },
                    },
                    Imagepath = Path.Combine(imageDirectory, "KnockKnock.png"),
                },
                new Playable
                {
                    Name = "Knock Knock", // 5
                    Character = new PChar { Character = PlayableCharacter.Dutch },
                    Class = new PClass { Class = PlayableClass.Green },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None },
                    },
                    Imagepath = Path.Combine(imageDirectory, "KnockKnock.png"),
                },
                new Playable
                {
                    Name = "Knock Knock", // 5
                    Character = new PChar { Character = PlayableCharacter.Dutch },
                    Class = new PClass { Class = PlayableClass.Green },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None },
                    },
                    Imagepath = Path.Combine(imageDirectory, "KnockKnock.png"),
                },
                new Playable
                {
                    Name = "Knock Knock", // 5
                    Character = new PChar { Character = PlayableCharacter.Dutch },
                    Class = new PClass { Class = PlayableClass.Green },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None },
                    },
                    Imagepath = Path.Combine(imageDirectory, "KnockKnock.png"),
                },
                new Playable
                {
                    Name = "Knock Knock", // 5
                    Character = new PChar { Character = PlayableCharacter.Dutch },
                    Class = new PClass { Class = PlayableClass.Green },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None },
                    },
                    Imagepath = Path.Combine(imageDirectory, "KnockKnock.png"),
                },

                #endregion

                #region Blain
                new Playable
                {
                    Name = "Dug In Like An Alabama Tick", // 3
                    Character = new PChar { Character = PlayableCharacter.Blain },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 6,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Brothers_in_arms }
                    },
                    Imagepath = Path.Combine(imageDirectory, "DugInLikeAnAlabamaTick.png"),
                },
                new Playable
                {
                    Name = "Dug In Like An Alabama Tick", // 3
                    Character = new PChar { Character = PlayableCharacter.Blain },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 6,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Brothers_in_arms }
                    },
                    Imagepath = Path.Combine(imageDirectory, "DugInLikeAnAlabamaTick.png"),
                },
                new Playable
                {
                    Name = "Dug In Like An Alabama Tick", // 3
                    Character = new PChar { Character = PlayableCharacter.Blain },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 6,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Brothers_in_arms }
                    },
                    Imagepath = Path.Combine(imageDirectory, "DugInLikeAnAlabamaTick.png"),
                },

                new Playable
                {
                    Name = "Sexual Tyrannosaurus", // 5
                    Character = new PChar { Character = PlayableCharacter.Blain },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 2,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Red }
                    },
                    Imagepath = Path.Combine(imageDirectory, "SexualTyrannosaurus.png"),
                },
                new Playable
                {
                    Name = "Sexual Tyrannosaurus", // 5
                    Character = new PChar { Character = PlayableCharacter.Blain },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 2,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Red }
                    },
                    Imagepath = Path.Combine(imageDirectory, "SexualTyrannosaurus.png"),
                },
                new Playable
                {
                    Name = "Sexual Tyrannosaurus", // 5
                    Character = new PChar { Character = PlayableCharacter.Blain },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 2,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Red }
                    },
                    Imagepath = Path.Combine(imageDirectory, "SexualTyrannosaurus.png"),
                },
                new Playable
                {
                    Name = "Sexual Tyrannosaurus", // 5
                    Character = new PChar { Character = PlayableCharacter.Blain },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 2,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Red }
                    },
                    Imagepath = Path.Combine(imageDirectory, "SexualTyrannosaurus.png"),
                },
                new Playable
                {
                    Name = "Sexual Tyrannosaurus", // 5
                    Character = new PChar { Character = PlayableCharacter.Blain },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 2,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Red }
                    },
                    Imagepath = Path.Combine(imageDirectory, "SexualTyrannosaurus.png"),
                },

                new Playable
                {
                    Name = "Ain't Got Time To Bleed", // 1
                    Character = new PChar { Character = PlayableCharacter.Blain },
                    Class = new PClass { Class = PlayableClass.Green },
                    Team = new PTeam { Team = PlayableTeam.Dutch },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 7,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Ain'tGotTimeToBleed.png"),
                },

                #endregion

                #endregion

                #region Predator2
                #region Harrigan
                new Playable
                {
                    Name = "I'm Gonna Finish It", // 1
                    Character = new PChar { Character = PlayableCharacter.Harrigan },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 0,
                    RecPoint = 0,
                    Price = 8,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None },
                    },
                    Imagepath = Path.Combine(imageDirectory, "I'mGonnaFinishIt.png"),
                },

                new Playable
                {
                    Name = "The Speech", // 5
                    Character = new PChar { Character = PlayableCharacter.Harrigan },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 1,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "TheSpeech.png"),
                },
                new Playable
                {
                    Name = "The Speech", // 5
                    Character = new PChar { Character = PlayableCharacter.Harrigan },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 1,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "TheSpeech.png"),
                },
                new Playable
                {
                    Name = "The Speech", // 5
                    Character = new PChar { Character = PlayableCharacter.Harrigan },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 1,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "TheSpeech.png"),
                },
                new Playable
                {
                    Name = "The Speech", // 5
                    Character = new PChar { Character = PlayableCharacter.Harrigan },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 1,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "TheSpeech.png"),
                },
                new Playable
                {
                    Name = "The Speech", // 5
                    Character = new PChar { Character = PlayableCharacter.Harrigan },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 1,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate }
                    },
                    Imagepath = Path.Combine(imageDirectory, "TheSpeech.png"),
                },

                new Playable
                {
                    Name = "Now It's Personal", // 5
                    Character = new PChar { Character = PlayableCharacter.Harrigan },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 4,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NowIt'sPersonal.png"),
                },
                new Playable
                {
                    Name = "Now It's Personal", // 5
                    Character = new PChar { Character = PlayableCharacter.Harrigan },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 4,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NowIt'sPersonal.png"),
                },
                new Playable
                {
                    Name = "Now It's Personal", // 5
                    Character = new PChar { Character = PlayableCharacter.Harrigan },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 4,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NowIt'sPersonal.png"),
                },
                new Playable
                {
                    Name = "Now It's Personal", // 5
                    Character = new PChar { Character = PlayableCharacter.Harrigan },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 4,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NowIt'sPersonal.png"),
                },
                new Playable
                {
                    Name = "Now It's Personal", // 5
                    Character = new PChar { Character = PlayableCharacter.Harrigan },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 4,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NowIt'sPersonal.png"),
                },

                #endregion

                #region Danny
                new Playable
                {
                    Name = "Put Him On The Payroll", // 1
                    Character = new PChar { Character = PlayableCharacter.Danny },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 4,
                    RecPoint = 0,
                    Price = 8,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.None },
                    },
                    Imagepath = Path.Combine(imageDirectory, "PutHimOnThePayroll.png"),
                },

                new Playable
                {
                    Name = "Take A Good Look", // 5
                    Character = new PChar { Character = PlayableCharacter.Danny },
                    Class = new PClass { Class = PlayableClass.Yellow },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 4,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate },
                    },
                    Imagepath = Path.Combine(imageDirectory, "TakeAGoodLook.png"),
                },
                new Playable
                {
                    Name = "Take A Good Look", // 5
                    Character = new PChar { Character = PlayableCharacter.Danny },
                    Class = new PClass { Class = PlayableClass.Yellow },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 4,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate },
                    },
                    Imagepath = Path.Combine(imageDirectory, "TakeAGoodLook.png"),
                },
                new Playable
                {
                    Name = "Take A Good Look", // 5
                    Character = new PChar { Character = PlayableCharacter.Danny },
                    Class = new PClass { Class = PlayableClass.Yellow },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 4,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate },
                    },
                    Imagepath = Path.Combine(imageDirectory, "TakeAGoodLook.png"),
                },
                new Playable
                {
                    Name = "Take A Good Look", // 5
                    Character = new PChar { Character = PlayableCharacter.Danny },
                    Class = new PClass { Class = PlayableClass.Yellow },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 4,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate },
                    },
                    Imagepath = Path.Combine(imageDirectory, "TakeAGoodLook.png"),
                },
                new Playable
                {
                    Name = "Take A Good Look", // 5
                    Character = new PChar { Character = PlayableCharacter.Danny },
                    Class = new PClass { Class = PlayableClass.Yellow },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 1,
                    RecPoint = 0,
                    Price = 4,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Coordinate },
                    },
                    Imagepath = Path.Combine(imageDirectory, "TakeAGoodLook.png"),
                },

                new Playable
                {
                    Name = "Fifteen Years On The Street", // 5
                    Character = new PChar { Character = PlayableCharacter.Danny },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 2,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FifteenYearsOnTheStreet.png"),
                },
                new Playable
                {
                    Name = "Fifteen Years On The Street", // 5
                    Character = new PChar { Character = PlayableCharacter.Danny },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 2,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FifteenYearsOnTheStreet.png"),
                },
                new Playable
                {
                    Name = "Fifteen Years On The Street", // 5
                    Character = new PChar { Character = PlayableCharacter.Danny },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 2,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FifteenYearsOnTheStreet.png"),
                },
                new Playable
                {
                    Name = "Fifteen Years On The Street", // 5
                    Character = new PChar { Character = PlayableCharacter.Danny },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 2,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FifteenYearsOnTheStreet.png"),
                },
                new Playable
                {
                    Name = "Fifteen Years On The Street", // 5
                    Character = new PChar { Character = PlayableCharacter.Danny },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 2,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FifteenYearsOnTheStreet.png"),
                },

                #endregion

                #region Keyes

                new Playable
                {
                    Name = "Enjoy The Show", // 5
                    Character = new PChar { Character = PlayableCharacter.Keyes },
                    Class = new PClass { Class = PlayableClass.Yellow },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "EnjoyTheShow.png"),
                },
                new Playable
                {
                    Name = "Enjoy The Show", // 5
                    Character = new PChar { Character = PlayableCharacter.Keyes },
                    Class = new PClass { Class = PlayableClass.Yellow },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "EnjoyTheShow.png"),
                },
                new Playable
                {
                    Name = "Enjoy The Show", // 5
                    Character = new PChar { Character = PlayableCharacter.Keyes },
                    Class = new PClass { Class = PlayableClass.Yellow },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "EnjoyTheShow.png"),
                },
                new Playable
                {
                    Name = "Enjoy The Show", // 5
                    Character = new PChar { Character = PlayableCharacter.Keyes },
                    Class = new PClass { Class = PlayableClass.Yellow },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "EnjoyTheShow.png"),
                },
                new Playable
                {
                    Name = "Enjoy The Show", // 5
                    Character = new PChar { Character = PlayableCharacter.Keyes },
                    Class = new PClass { Class = PlayableClass.Yellow },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 0,
                    RecPoint = 2,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "EnjoyTheShow.png"),
                },

                new Playable
                {
                    Name = "Jurisdictional Intrusion", // 3
                    Character = new PChar { Character = PlayableCharacter.Keyes },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 3,
                    RecPoint = 0,
                    Price = 5,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Gray }
                    },
                    Imagepath = Path.Combine(imageDirectory, "JurisdictionalIntrusion.png"),
                },
                new Playable
                {
                    Name = "Jurisdictional Intrusion", // 3
                    Character = new PChar { Character = PlayableCharacter.Keyes },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 3,
                    RecPoint = 0,
                    Price = 5,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Gray }
                    },
                    Imagepath = Path.Combine(imageDirectory, "JurisdictionalIntrusion.png"),
                },
                new Playable
                {
                    Name = "Jurisdictional Intrusion", // 3
                    Character = new PChar { Character = PlayableCharacter.Keyes },
                    Class = new PClass { Class = PlayableClass.Gray },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 3,
                    RecPoint = 0,
                    Price = 5,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Gray }
                    },
                    Imagepath = Path.Combine(imageDirectory, "JurisdictionalIntrusion.png"),
                },

                new Playable
                {
                    Name = "Too Late To Go Home Now", // 5
                    Character = new PChar { Character = PlayableCharacter.Keyes },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Harrigan }
                    },
                    Imagepath = Path.Combine(imageDirectory, "TooLateToGoHomeNow.png"),
                },
                new Playable
                {
                    Name = "Too Late To Go Home Now", // 5
                    Character = new PChar { Character = PlayableCharacter.Keyes },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Harrigan }
                    },
                    Imagepath = Path.Combine(imageDirectory, "TooLateToGoHomeNow.png"),
                },
                new Playable
                {
                    Name = "Too Late To Go Home Now", // 5
                    Character = new PChar { Character = PlayableCharacter.Keyes },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Harrigan }
                    },
                    Imagepath = Path.Combine(imageDirectory, "TooLateToGoHomeNow.png"),
                },
                new Playable
                {
                    Name = "Too Late To Go Home Now", // 5
                    Character = new PChar { Character = PlayableCharacter.Keyes },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Harrigan }
                    },
                    Imagepath = Path.Combine(imageDirectory, "TooLateToGoHomeNow.png"),
                },
                new Playable
                {
                    Name = "Too Late To Go Home Now", // 5
                    Character = new PChar { Character = PlayableCharacter.Keyes },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 3,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Harrigan }
                    },
                    Imagepath = Path.Combine(imageDirectory, "TooLateToGoHomeNow.png"),
                },

                #endregion

                #region Lambert

                new Playable
                {
                    Name = "Luck Is My Specialty", // 3
                    Character = new PChar { Character = PlayableCharacter.Lambert },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 2,
                    Price = 6,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Blue }
                    },
                    Imagepath = Path.Combine(imageDirectory, "LuckIsMySpecialty.png"),
                },
                new Playable
                {
                    Name = "Luck Is My Specialty", // 3
                    Character = new PChar { Character = PlayableCharacter.Lambert },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 2,
                    Price = 6,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Blue }
                    },
                    Imagepath = Path.Combine(imageDirectory, "LuckIsMySpecialty.png"),
                },
                new Playable
                {
                    Name = "Luck Is My Specialty", // 3
                    Character = new PChar { Character = PlayableCharacter.Lambert },
                    Class = new PClass { Class = PlayableClass.Blue },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 2,
                    Price = 6,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Blue }
                    },
                    Imagepath = Path.Combine(imageDirectory, "LuckIsMySpecialty.png"),
                },

                new Playable
                {
                    Name = "No Autographs", // 5
                    Character = new PChar { Character = PlayableCharacter.Lambert },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 4,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NoAutographs.png"),
                },
                new Playable
                {
                    Name = "No Autographs", // 5
                    Character = new PChar { Character = PlayableCharacter.Lambert },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 4,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NoAutographs.png"),
                },
                new Playable
                {
                    Name = "No Autographs", // 5
                    Character = new PChar { Character = PlayableCharacter.Lambert },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 4,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NoAutographs.png"),
                },
                new Playable
                {
                    Name = "No Autographs", // 5
                    Character = new PChar { Character = PlayableCharacter.Lambert },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 4,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NoAutographs.png"),
                },
                new Playable
                {
                    Name = "No Autographs", // 5
                    Character = new PChar { Character = PlayableCharacter.Lambert },
                    Class = new PClass { Class = PlayableClass.Red },
                    Team = new PTeam { Team = PlayableTeam.Harrigan },
                    AttPoint = 2,
                    RecPoint = 0,
                    Price = 4,
                    Skills = new List<PSkill> {
                        new PSkill { Skill = PlayableSkill.Showboat }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NoAutographs.png"),
                },

                #endregion

                #endregion

                #endregion
            };

            IList<Card> defaultObjectives = new List<Card>
            {
                #region Predator1
                new Card
                {
                    Name = "Expendable Assets",
                    Imagepath = Path.Combine(imageDirectory, "ExpendableAssets.png"),
                },

                new Card
                {
                    Name = "Flares, Frags, and Claymores",
                    Imagepath = Path.Combine(imageDirectory, "Flares,Frags,AndClaymores.png"),
                },

                new Card
                {
                    Name = "Get To The Choppa!",
                    Imagepath = Path.Combine(imageDirectory, "GetToTheChoppa!.png"),
                },

                #endregion

                #region Predator2
                new Card
                {
                    Name = "War Zone",
                    Imagepath = Path.Combine(imageDirectory, "WarZone.png"),
                },

                new Card
                {
                    Name = "Personal Little War",
                    Imagepath = Path.Combine(imageDirectory, "PersonalLittleWar.png"),
                },

                new Card
                {
                    Name = "Other-World Life-Form",
                    Imagepath = Path.Combine(imageDirectory, "Other-WorldLife-Form.png"),
                },

                #endregion

            };

            IList<Enemy> defaultEnemies = new List<Enemy>
            {
                #region Objectives + Végső ellenfelek

                #region Predator1
                new Enemy
                {
                    Name = "Guerilla Camp",
                    Team = new ETeam { Team = EnemyTeam.P1O1 },
                    FaceDown = true,
                    Health = 1,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },

                    Imagepath = Path.Combine(imageDirectory, "GuerillaCamp.png"),
                },

                new Enemy
                {
                    Name = "Defensive Position",
                    Team = new ETeam { Team = EnemyTeam.P1O2 },
                    FaceDown = true,
                    Health = 0,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                        new ESkill { Skill = EnemySkill.Operations },
                    },
                    Imagepath = Path.Combine(imageDirectory, "DefensivePosition.png"),
                },

                new Enemy
                {
                    Name = "One Ugly Mother...",
                    Team = new ETeam { Team = EnemyTeam.P1O3 },
                    FaceDown = true,
                    Health = 10,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Runner },
                        new ESkill { Skill = EnemySkill.Double_strike },
                        new ESkill { Skill = EnemySkill.Ongoing }
                    },
                    Imagepath = Path.Combine(imageDirectory, "OneUglyMother....png"),
                },

                #endregion

                #region Predator2
                new Enemy
                {
                    Name = "Assault The Stronghold",
                    Team = new ETeam { Team = EnemyTeam.P2O1 },
                    FaceDown = true,
                    Health = 0,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                        new ESkill { Skill = EnemySkill.Operations },
                    },
                    Imagepath = Path.Combine(imageDirectory, "AssaultTheStronghold.png"),
                },

                new Enemy
                {
                    Name = "Forensic Analysis",
                    Team = new ETeam { Team = EnemyTeam.P2O2 },
                    FaceDown = true,
                    Health = 0,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                        new ESkill { Skill = EnemySkill.Operations },
                    },
                    Imagepath = Path.Combine(imageDirectory, "ForensicAnalysis.png"),
                },

                new Enemy
                {
                    Name = "Physical Evidence",
                    Team = new ETeam { Team = EnemyTeam.P2O2 },
                    FaceDown = true,
                    Health = 0,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                        new ESkill { Skill = EnemySkill.Operations },
                    },
                    Imagepath = Path.Combine(imageDirectory, "PhysicalEvidence.png"),
                },

                new Enemy
                {
                    Name = "Witness Testimony",
                    Team = new ETeam { Team = EnemyTeam.P2O2 },
                    FaceDown = true,
                    Health = 0,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                        new ESkill { Skill = EnemySkill.Operations },
                    },
                    Imagepath = Path.Combine(imageDirectory, "WitnessTestimony.png"),
                },

                new Enemy
                {
                    Name = "One Big Ugly Mother...",
                    Team = new ETeam { Team = EnemyTeam.P2O3 },
                    FaceDown = true,
                    Health = 11,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Runner },
                        new ESkill { Skill = EnemySkill.Ongoing },
                    },
                    Imagepath = Path.Combine(imageDirectory, "OneBigUglyMother....png"),
                },

                #endregion

                #endregion

                #region Specials(Event+Hazard)
                new Enemy
                {
                    Name = "Event", //  3 + 2 + 2 + 2 / each movie (3 is YoungBlood)
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P1O1},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Event.png"),
                },
                new Enemy
                {
                    Name = "Event", //  3 + 2 + 2 + 2 / each movie (3 is YoungBlood)
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P1O1},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Event.png"),
                },
                new Enemy
                {
                    Name = "Event", //  3 + 2 + 2 + 2 / each movie (3 is YoungBlood)
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P1O2},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Event.png"),
                },
                new Enemy
                {
                    Name = "Event", //  3 + 2 + 2 + 2 / each movie (3 is YoungBlood)
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P1O2},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Event.png"),
                },
                new Enemy
                {
                    Name = "Event", //  3 + 2 + 2 + 2 / each movie (3 is YoungBlood)
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P1O3},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Event.png"),
                },
                new Enemy
                {
                    Name = "Event", //  3 + 2 + 2 + 2 / each movie (3 is YoungBlood)
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P1O3},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Event.png"),
                },
                new Enemy
                {
                    Name = "Event", //  3 + 2 + 2 + 2 / each movie (3 is YoungBlood)
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P2O1},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Event.png"),
                },
                new Enemy
                {
                    Name = "Event", //  3 + 2 + 2 + 2 / each movie (3 is YoungBlood)
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P2O1},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Event.png"),
                },
                new Enemy
                {
                    Name = "Event", //  3 + 2 + 2 + 2 / each movie (3 is YoungBlood)
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P2O2},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Event.png"),
                },
                new Enemy
                {
                    Name = "Event", //  3 + 2 + 2 + 2 / each movie (3 is YoungBlood)
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P2O2},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Event.png"),
                },
                new Enemy
                {
                    Name = "Event", //  3 + 2 + 2 + 2 / each movie (3 is YoungBlood)
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P2O3},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Event.png"),
                },
                new Enemy
                {
                    Name = "Event", //  3 + 2 + 2 + 2 / each movie (3 is YoungBlood)
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P2O3},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Event.png"),
                },

                new Enemy
                {
                    Name = "Hazard", // 1 + 1 + 1 / each movie
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P1O1},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Hazard.png"),
                },
                new Enemy
                {
                    Name = "Hazard", // 1 + 1 + 1 / each movie
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P1O2},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Hazard.png"),
                },
                new Enemy
                {
                    Name = "Hazard", // 1 + 1 + 1 / each movie
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P1O3},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Hazard.png"),
                },
                new Enemy
                {
                    Name = "Hazard", // 1 + 1 + 1 / each movie
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P2O1},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Hazard.png"),
                },
                new Enemy
                {
                    Name = "Hazard", // 1 + 1 + 1 / each movie
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P2O2},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Hazard.png"),
                },
                new Enemy
                {
                    Name = "Hazard", // 1 + 1 + 1 / each movie
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.P2O3},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Hazard.png"),
                },

                #endregion

                #region Enemy
                #region Predator1
                #region 1
                new Enemy
                {
                    Name = "Soviet Advisor", // 1
                    Team = new ETeam { Team = EnemyTeam.P1O1 },
                    FaceDown = true,
                    Health = 5,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing },
                    },
                    Imagepath = Path.Combine(imageDirectory, "SovietAdvisor.png"),
                },

                new Enemy
                {
                    Name = "Val Verde Guerilla", // 4
                    Team = new ETeam { Team = EnemyTeam.P1O1 },
                    FaceDown = true,
                    Health = 3,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death },
                    },
                    Imagepath = Path.Combine(imageDirectory, "ValVerdeGuerilla.png"),
                },
                new Enemy
                {
                    Name = "Val Verde Guerilla", // 4
                    Team = new ETeam { Team = EnemyTeam.P1O1 },
                    FaceDown = true,
                    Health = 3,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death },
                    },
                    Imagepath = Path.Combine(imageDirectory, "ValVerdeGuerilla.png"),
                },
                new Enemy
                {
                    Name = "Val Verde Guerilla", // 4
                    Team = new ETeam { Team = EnemyTeam.P1O1 },
                    FaceDown = true,
                    Health = 3,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death },
                    },
                    Imagepath = Path.Combine(imageDirectory, "ValVerdeGuerilla.png"),
                },
                new Enemy
                {
                    Name = "Val Verde Guerilla", // 4
                    Team = new ETeam { Team = EnemyTeam.P1O1 },
                    FaceDown = true,
                    Health = 3,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death },
                    },
                    Imagepath = Path.Combine(imageDirectory, "ValVerdeGuerilla.png"),
                },

                #endregion

                #region 2
                new Enemy
                {
                    Name = "It Changed Colors", // 3
                    Team = new ETeam { Team = EnemyTeam.P1O2 },
                    FaceDown = true,
                    Health = 8,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing },
                    },
                    Imagepath = Path.Combine(imageDirectory, "ItChangedColors.png"),
                },
                new Enemy
                {
                    Name = "It Changed Colors", // 3
                    Team = new ETeam { Team = EnemyTeam.P1O2 },
                    FaceDown = true,
                    Health = 8,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing },
                    },
                    Imagepath = Path.Combine(imageDirectory, "ItChangedColors.png"),
                },
                new Enemy
                {
                    Name = "It Changed Colors", // 3
                    Team = new ETeam { Team = EnemyTeam.P1O2 },
                    FaceDown = true,
                    Health = 8,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing },
                    },
                    Imagepath = Path.Combine(imageDirectory, "ItChangedColors.png"),
                },

                new Enemy
                {
                    Name = "One At A Time", // 1
                    Team = new ETeam { Team = EnemyTeam.P1O2 },
                    FaceDown = true,
                    Health = 7,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.CombatZone }
                    },
                    Imagepath = Path.Combine(imageDirectory, "OneAtATime.png"),
                },

                #endregion

                #region 3
                new Enemy
                {
                    Name = "A World Of Hurt", // 2
                    Team = new ETeam { Team = EnemyTeam.P1O3 },
                    FaceDown = true,
                    Health = 8,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing }
                    },
                    Imagepath = Path.Combine(imageDirectory, "AWorldOfHurt.png"),
                },
                new Enemy
                {
                    Name = "A World Of Hurt", // 2
                    Team = new ETeam { Team = EnemyTeam.P1O3 },
                    FaceDown = true,
                    Health = 8,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing }
                    },
                    Imagepath = Path.Combine(imageDirectory, "AWorldOfHurt.png"),
                },

                new Enemy
                {
                    Name = "Not A Single Track", // 3
                    Team = new ETeam { Team = EnemyTeam.P1O3 },
                    FaceDown = true,
                    Health = 5,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NotASingleTrack.png"),
                },
                new Enemy
                {
                    Name = "Not A Single Track", // 3
                    Team = new ETeam { Team = EnemyTeam.P1O3 },
                    FaceDown = true,
                    Health = 5,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NotASingleTrack.png"),
                },
                new Enemy
                {
                    Name = "Not A Single Track", // 3
                    Team = new ETeam { Team = EnemyTeam.P1O3 },
                    FaceDown = true,
                    Health = 5,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NotASingleTrack.png"),
                },

                #endregion

                #endregion

                #region Predator2
                #region 1
                new Enemy
                {
                    Name = "El Scorpio", // 1
                    Team = new ETeam { Team = EnemyTeam.P2O1 },
                    FaceDown = true,
                    Health = 5,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing },
                    },
                    Imagepath = Path.Combine(imageDirectory, "ElScorpio.png"),
                },

                new Enemy
                {
                    Name = "Scorpion Enforcer", // 3
                    Team = new ETeam { Team = EnemyTeam.P2O1 },
                    FaceDown = true,
                    Health = 3,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death },
                    },
                    Imagepath = Path.Combine(imageDirectory, "ScorpionEnforcer.png"),
                },
                new Enemy
                {
                    Name = "Scorpion Enforcer", // 3
                    Team = new ETeam { Team = EnemyTeam.P2O1 },
                    FaceDown = true,
                    Health = 3,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death },
                    },
                    Imagepath = Path.Combine(imageDirectory, "ScorpionEnforcer.png"),
                },
                new Enemy
                {
                    Name = "Scorpion Enforcer", // 3
                    Team = new ETeam { Team = EnemyTeam.P2O1 },
                    FaceDown = true,
                    Health = 3,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death },
                    },
                    Imagepath = Path.Combine(imageDirectory, "ScorpionEnforcer.png"),
                },

                #endregion

                #region 2
                new Enemy
                {
                    Name = "City Of Fear", // 3
                    Team = new ETeam { Team = EnemyTeam.P2O2 },
                    FaceDown = true,
                    Health = 6,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing },
                    },
                    Imagepath = Path.Combine(imageDirectory, "CityOfFear.png"),
                },
                new Enemy
                {
                    Name = "City Of Fear", // 3
                    Team = new ETeam { Team = EnemyTeam.P2O2 },
                    FaceDown = true,
                    Health = 6,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing },
                    },
                    Imagepath = Path.Combine(imageDirectory, "CityOfFear.png"),
                },
                new Enemy
                {
                    Name = "City Of Fear", // 3
                    Team = new ETeam { Team = EnemyTeam.P2O2 },
                    FaceDown = true,
                    Health = 6,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing },
                    },
                    Imagepath = Path.Combine(imageDirectory, "CityOfFear.png"),
                },

                #endregion

                #region 3
                new Enemy
                {
                    Name = "No Stopping What Can't Be Stopped", // 2
                    Team = new ETeam { Team = EnemyTeam.P2O3 },
                    FaceDown = true,
                    Health = 3,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NoStoppingWhatCan'tBeStopped.png"),
                },
                new Enemy
                {
                    Name = "No Stopping What Can't Be Stopped", // 2
                    Team = new ETeam { Team = EnemyTeam.P2O3 },
                    FaceDown = true,
                    Health = 3,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NoStoppingWhatCan'tBeStopped.png"),
                },

                new Enemy
                {
                    Name = "No Killing What Can't Be Killed", // 3
                    Team = new ETeam { Team = EnemyTeam.P2O3 },
                    FaceDown = true,
                    Health = 5,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NoKillingWhatCan'tBeKilled.png"),
                },
                new Enemy
                {
                    Name = "No Killing What Can't Be Killed", // 3
                    Team = new ETeam { Team = EnemyTeam.P2O3 },
                    FaceDown = true,
                    Health = 5,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NoKillingWhatCan'tBeKilled.png"),
                },
                new Enemy
                {
                    Name = "No Killing What Can't Be Killed", // 3
                    Team = new ETeam { Team = EnemyTeam.P2O3 },
                    FaceDown = true,
                    Health = 5,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Ongoing }
                    },
                    Imagepath = Path.Combine(imageDirectory, "NoKillingWhatCan'tBeKilled.png"),
                },

                #endregion

                #endregion

                #region Young-blood
                new Enemy
                {
                    Name = "Event", //  3 + 2 + 2 + 2 / each movie (3 is YoungBlood)
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.Young_blood},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Event.png"),
                },
                new Enemy
                {
                    Name = "Event", //  3 + 2 + 2 + 2 / each movie (3 is YoungBlood)
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.Young_blood},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Event.png"),
                },
                new Enemy
                {
                    Name = "Event", //  3 + 2 + 2 + 2 / each movie (3 is YoungBlood)
                    Health = 0,
                    Team = new ETeam { Team = EnemyTeam.Young_blood},
                    FaceDown = true,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal },
                    },
                    Imagepath = Path.Combine(imageDirectory, "Event.png"),
                },

                new Enemy
                {
                    Name = "Over Here", // 3
                    Team = new ETeam { Team = EnemyTeam.Young_blood },
                    FaceDown = true,
                    Health = 1,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal }
                    },
                    Imagepath = Path.Combine(imageDirectory, "OverHere.png"),
                },
                new Enemy
                {
                    Name = "Over Here", // 3
                    Team = new ETeam { Team = EnemyTeam.Young_blood },
                    FaceDown = true,
                    Health = 1,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal }
                    },
                    Imagepath = Path.Combine(imageDirectory, "OverHere.png"),
                },
                new Enemy
                {
                    Name = "Over Here", // 3
                    Team = new ETeam { Team = EnemyTeam.Young_blood },
                    FaceDown = true,
                    Health = 1,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Reveal }
                    },
                    Imagepath = Path.Combine(imageDirectory, "OverHere.png"),
                },

                new Enemy
                {
                    Name = "Almost No Weight. Cuts Like Steel.", // 3
                    Team = new ETeam { Team = EnemyTeam.Young_blood },
                    FaceDown = true,
                    Health = 5,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Double_strike },
                        new ESkill { Skill = EnemySkill.CombatZone }
                    },
                    Imagepath =Path.Combine(imageDirectory, "AlmostNoWeight.CutsLikeSteel..png"),
                },
                new Enemy
                {
                    Name = "Almost No Weight. Cuts Like Steel.", // 3
                    Team = new ETeam { Team = EnemyTeam.Young_blood },
                    FaceDown = true,
                    Health = 5,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Double_strike },
                        new ESkill { Skill = EnemySkill.CombatZone }
                    },
                    Imagepath =Path.Combine(imageDirectory, "AlmostNoWeight.CutsLikeSteel..png"),
                },
                new Enemy
                {
                    Name = "Almost No Weight. Cuts Like Steel.", // 3
                    Team = new ETeam { Team = EnemyTeam.Young_blood },
                    FaceDown = true,
                    Health = 5,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Double_strike },
                        new ESkill { Skill = EnemySkill.CombatZone }
                    },
                    Imagepath =Path.Combine(imageDirectory, "AlmostNoWeight.CutsLikeSteel..png"),
                },

                new Enemy
                {
                    Name = "Something Out There Waiting For Us", // 3
                    Team = new ETeam { Team = EnemyTeam.Young_blood },
                    FaceDown = true,
                    Health = 3,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death }
                    },
                    Imagepath = Path.Combine(imageDirectory, "SomethingOutThereWaitingForUs.png"),
                },
                new Enemy
                {
                    Name = "Something Out There Waiting For Us", // 3
                    Team = new ETeam { Team = EnemyTeam.Young_blood },
                    FaceDown = true,
                    Health = 3,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death }
                    },
                    Imagepath = Path.Combine(imageDirectory, "SomethingOutThereWaitingForUs.png"),
                },
                new Enemy
                {
                    Name = "Something Out There Waiting For Us", // 3
                    Team = new ETeam { Team = EnemyTeam.Young_blood },
                    FaceDown = true,
                    Health = 3,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death }
                    },
                    Imagepath = Path.Combine(imageDirectory, "SomethingOutThereWaitingForUs.png"),
                },

                new Enemy
                {
                    Name = "The Eyes Of The Demon", // 3
                    Team = new ETeam { Team = EnemyTeam.Young_blood },
                    FaceDown = true,
                    Health = 2,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death }
                    },
                    Imagepath = Path.Combine(imageDirectory, "TheEyesOfTheDemon.png"),
                },
                new Enemy
                {
                    Name = "The Eyes Of The Demon", // 3
                    Team = new ETeam { Team = EnemyTeam.Young_blood },
                    FaceDown = true,
                    Health = 2,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death }
                    },
                    Imagepath = Path.Combine(imageDirectory, "TheEyesOfTheDemon.png"),
                },
                new Enemy
                {
                    Name = "The Eyes Of The Demon", // 3
                    Team = new ETeam { Team = EnemyTeam.Young_blood },
                    FaceDown = true,
                    Health = 2,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death }
                    },
                    Imagepath = Path.Combine(imageDirectory, "TheEyesOfTheDemon.png"),
                },

                new Enemy
                {
                    Name = "Fun And Games", // 3
                    Team = new ETeam { Team = EnemyTeam.Young_blood },
                    FaceDown = true,
                    Health = 4,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FunAndGames.png"),
                },
                new Enemy
                {
                    Name = "Fun And Games", // 3
                    Team = new ETeam { Team = EnemyTeam.Young_blood },
                    FaceDown = true,
                    Health = 4,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FunAndGames.png"),
                },
                new Enemy
                {
                    Name = "Fun And Games", // 3
                    Team = new ETeam { Team = EnemyTeam.Young_blood },
                    FaceDown = true,
                    Health = 4,
                    Skills = new List<ESkill> {
                        new ESkill { Skill = EnemySkill.Death }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FunAndGames.png"),
                },

                #endregion

                #endregion
            }; 

            IList<Damage> defaultDamages = new List<Damage>
            {
                new Damage
                {
                    Name = "Close Call",
                    Dmg = 0,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CloseCall.png"),
                },
                new Damage
                {
                    Name = "Close Call",
                    Dmg = 0,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CloseCall.png"),
                },
                new Damage
                {
                    Name = "Close Call",
                    Dmg = 0,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CloseCall.png"),
                },
                new Damage
                {
                    Name = "Close Call",
                    Dmg = 0,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CloseCall.png"),
                },
                new Damage
                {
                    Name = "Close Call",
                    Dmg = 0,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CloseCall.png"),
                },
                new Damage
                {
                    Name = "Close Call",
                    Dmg = 0,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "CloseCall.png"),
                },

                new Damage
                {
                    Name = "Open Wound",
                    Dmg = 0,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.Priority }
                    },
                    Imagepath = Path.Combine(imageDirectory, "OpenWound.png"),
                },
                new Damage
                {
                    Name = "Open Wound",
                    Dmg = 0,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.Priority }
                    },
                    Imagepath = Path.Combine(imageDirectory, "OpenWound.png"),
                },

                new Damage
                {
                    Name = "Brutal Puncture",
                    Dmg = 3,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BrutalPuncture.png"),
                },
                new Damage
                {
                    Name = "Brutal Puncture",
                    Dmg = 3,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BrutalPuncture.png"),
                },
                new Damage
                {
                    Name = "Brutal Puncture",
                    Dmg = 3,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "BrutalPuncture.png"),
                },

                new Damage
                {
                    Name = "Deep gash",
                    Dmg = 2,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "DeepGash.png"),
                },
                new Damage
                {
                    Name = "Deep gash",
                    Dmg = 2,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "DeepGash.png"),
                },
                new Damage
                {
                    Name = "Deep gash",
                    Dmg = 2,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "DeepGash.png"),
                },
                new Damage
                {
                    Name = "Deep gash",
                    Dmg = 2,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "DeepGash.png"),
                },
                new Damage
                {
                    Name = "Deep gash",
                    Dmg = 2,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "DeepGash.png"),
                },
                new Damage
                {
                    Name = "Deep gash",
                    Dmg = 2,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "DeepGash.png"),
                },
                new Damage
                {
                    Name = "Deep gash",
                    Dmg = 2,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "DeepGash.png"),
                },
                new Damage
                {
                    Name = "Deep gash",
                    Dmg = 2,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "DeepGash.png"),
                },

                new Damage
                {
                    Name = "Flesh Wound",
                    Dmg = 1,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FleshWound.png"),
                },
                new Damage
                {
                    Name = "Flesh Wound",
                    Dmg = 1,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FleshWound.png"),
                },
                new Damage
                {
                    Name = "Flesh Wound",
                    Dmg = 1,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FleshWound.png"),
                },
                new Damage
                {
                    Name = "Flesh Wound",
                    Dmg = 1,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FleshWound.png"),
                },
                new Damage
                {
                    Name = "Flesh Wound",
                    Dmg = 1,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FleshWound.png"),
                },
                new Damage
                {
                    Name = "Flesh Wound",
                    Dmg = 1,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FleshWound.png"),
                },
                new Damage
                {
                    Name = "Flesh Wound",
                    Dmg = 1,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FleshWound.png"),
                },
                new Damage
                {
                    Name = "Flesh Wound",
                    Dmg = 1,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FleshWound.png"),
                },
                new Damage
                {
                    Name = "Flesh Wound",
                    Dmg = 1,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FleshWound.png"),
                },
                new Damage
                {
                    Name = "Flesh Wound",
                    Dmg = 1,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.None }
                    },
                    Imagepath = Path.Combine(imageDirectory, "FleshWound.png"),
                },

                new Damage
                {
                    Name = "Stunning Blow",
                    Dmg = 1,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.Mark }
                    },
                    Imagepath = Path.Combine(imageDirectory, "StunningBlow.png"),
                },
                new Damage
                {
                    Name = "Stunning Blow",
                    Dmg = 1,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.Mark }
                    },
                    Imagepath = Path.Combine(imageDirectory, "StunningBlow.png"),
                },
                new Damage
                {
                    Name = "Stunning Blow",
                    Dmg = 1,
                    Skills = new List<DSkill> {
                        new DSkill { Skill = DamageSkill.Mark }
                    },
                    Imagepath = Path.Combine(imageDirectory, "StunningBlow.png"),
                },

            };

            context.AddRange(defaultLocations);
            context.AddRange(defaulAvatars);
            context.AddRange(defaultCards);
            context.AddRange(defaultObjectives);
            context.AddRange(defaultEnemies);
            context.AddRange(defaultDamages);
            context.SaveChanges();
        }
    }
}
