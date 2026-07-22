using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.PredatorBG.Models;
using WebAPI.PredatorBG.Models.Enums;

namespace WebAPI.PredatorBG.Services
{
    public interface IPredatorBGService
    {
        #region Card
        List<Card> GetCards(String name = null);

        List<Playable> GetCommanders();

        List<Card> GetObjectivesByMovie(int movie);

        List<Playable> GetPlayablesByMovie(int movie);

        List<Enemy> GetEnemiesByMovie(int movie, int players);

        List<Damage> GetDamages();

        #endregion

        #region Location
        List<Location> GetLocations(String name = null);
        Location GetLocationById(int id);

        #endregion

        #region Avatar
        List<Avatar> GetAvatars(String name = null);

        List<Avatar> GetAvatarsByTeam(int num);

        Avatar GetAvatarById(int id);

        #endregion

        #region Lobby
        Task<List<Lobby>> GetLobbies(String name = null);
        Task<Lobby> GetLobbyById(int id);

        Task<int> CreateLobby(Lobby lobby);

        PredatorGame CreateGame(int movie, int playerNum = 1);

        Task<int> UpdateLobby(Lobby lobby);

        Task<int> DeleteLobby(int id);

        #endregion
    }

    public class PredatorBGService : IPredatorBGService
    {
        private readonly PredatorBGDbContext _context;

        public PredatorBGService(PredatorBGDbContext context)
        {
            _context = context;
        }

        public List<Card> GetCards(String name = null)
        {
            return _context.Cards
                .Where(c => c.Name.Contains(name ?? ""))
                .OrderBy(c => c.Name)
                .ToList();
        }

        public List<Playable> GetCommanders()
        {
            return _context.Playables.Where(p => p.Name.Contains("Commander")).ToList();
        }

        public List<Damage> GetDamages()
        {
            return _context.Damages.ToList();
        }

        public List<Card> GetObjectivesByMovie(int movie) {
            List<Card> objectives = new List<Card>();
            if (movie == 1)
            {
                objectives.Add(GetCards("Expendable Assets")[0]);
                objectives.Add(GetCards("Flares, Frags, and Claymores")[0]);
                objectives.Add(GetCards("Get To The Choppa!")[0]);
            }
            else
            {
                objectives.Add(GetCards("War Zone")[0]);
                objectives.Add(GetCards("Personal Little War")[0]);
                objectives.Add(GetCards("Other-World Life-Form")[0]);
            }
            return objectives;
        }

        public List<Playable> GetPlayablesByMovie(int movie)
        {
            if (movie == 1)
            {
                return _context.Playables.Where(p => p.Team.Team == PlayableTeam.Dutch).ToList();
            }
            else
            {
                return _context.Playables.Where(p => p.Team.Team == PlayableTeam.Harrigan).ToList();
            }
        }

        public List<Enemy> GetEnemiesByMovie(int movie, int players)
        {
            /* Young-blood chart
            Nr. of players | Young-blood in deck 1 | Young-blood in deck 2 | Young-blood in deck 3
            1 | 0 | 0 | 0
            2 | 0 | 1 | 2
            3 | 2 | 3 | 4
            4 | 4 | 5 | 6
            5 | 4 | 5 | 6 *free prep round */
            var rnd = new Random();
            var deck1 = new List<Enemy>();
            var deck2 = new List<Enemy>();
            var deck3 = new List<Enemy>();

            var young_blood = new List<Enemy>();
            young_blood.AddRange(_context.Enemies.Where(e => e.Team.Team == EnemyTeam.Young_blood).ToList());
            young_blood = young_blood.OrderBy(item => rnd.Next()).ToList();

            if (movie == 1)
            {
                deck1 = _context.Enemies.Where(e => e.Team.Team == EnemyTeam.P1O1).ToList();

                deck2 = _context.Enemies.Where(e => e.Team.Team == EnemyTeam.P1O2).ToList();

                deck3 = _context.Enemies.Where(e => e.Team.Team == EnemyTeam.P1O3).ToList();

            }
            else
            {
                deck1 = _context.Enemies.Where(e => e.Team.Team == EnemyTeam.P2O1).ToList();

                deck2 = _context.Enemies.Where(e => e.Team.Team == EnemyTeam.P2O2).ToList();

                deck3 = _context.Enemies.Where(e => e.Team.Team == EnemyTeam.P2O3).ToList();

            }
            if (players == 2)
            {
                deck2.Add(young_blood[0]);

                deck3.Add(young_blood[1]);
                deck3.Add(young_blood[2]);
            }
            else if (players == 3)
            {
                deck1.Add(young_blood[0]);
                deck1.Add(young_blood[1]);

                deck2.Add(young_blood[2]);
                deck2.Add(young_blood[3]);
                deck2.Add(young_blood[4]);

                deck3.Add(young_blood[5]);
                deck3.Add(young_blood[6]);
                deck3.Add(young_blood[7]);
                deck3.Add(young_blood[8]);
            }
            else if (players > 3)
            {
                deck1.Add(young_blood[0]);
                deck1.Add(young_blood[1]);
                deck1.Add(young_blood[2]);
                deck1.Add(young_blood[3]);

                deck2.Add(young_blood[4]);
                deck2.Add(young_blood[5]);
                deck2.Add(young_blood[6]);
                deck2.Add(young_blood[7]);
                deck2.Add(young_blood[8]);

                deck3.Add(young_blood[9]);
                deck3.Add(young_blood[10]);
                deck3.Add(young_blood[11]);
                deck3.Add(young_blood[12]);
                deck3.Add(young_blood[13]);
                deck3.Add(young_blood[14]);
            }

            deck1 = deck1.OrderBy(item => rnd.Next()).ToList();
            deck2 = deck2.OrderBy(item => rnd.Next()).ToList();
            deck3 = deck3.OrderBy(item => rnd.Next()).ToList();

            foreach (Enemy enemy in deck2)
                deck1.Add(enemy);
            foreach (Enemy enemy in deck3)
                deck1.Add(enemy);

            return deck1;
        }

        public List<Location> GetLocations(String name = null)
        {
            return _context.Locations
                .Where(l => l.Name.Contains(name ?? ""))
                .OrderBy(l => l.Name)
                .ToList();
        }
        
        public Location GetLocationById(int id)
        {
            return _context.Locations
                .Single(l => l.Id == id);
        }

        public List<Avatar> GetAvatars(String name = null)
        {
            return _context.Avatars
                .Where(a => a.Name.Contains(name ?? ""))
                .OrderBy(a => a.Name)
                .ToList();
        }

        public List<Avatar> GetAvatarsByTeam(int num)
        {
            return _context.Avatars
                .Where(a => a.Team == num)
                .ToList();
        }

        public Avatar GetAvatarById(int id)
        {
            return _context.Avatars
                .Single(a => a.Id == id);
        }

        public Task<List<Lobby>> GetLobbies(String name = null)
        {
            return _context.Lobbies.Where(l => l.Name.Contains(name ?? "")).OrderBy(l => l.Name).ToListAsync();
        }
        public Task<Lobby> GetLobbyById(int id)
        {
            return _context.Lobbies
                .SingleAsync(l => l.Id == id);
        }

        public Task<int> CreateLobby(Lobby lobby)
        {
            try
            {
                _context.Add(lobby);
                return _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public PredatorGame CreateGame(int movie, int playerNum = 1)
        {
            var rnd = new Random();

            var location = GetLocationById(movie);
            var commanders = GetCommanders().OrderBy(c => rnd.Next()).ToList();
            var avatars = GetAvatarsByTeam(movie);
            
            // Filter Avatars based on Number of players
            if (playerNum < 5)
            {
                avatars = avatars.Where(a => a.Name != "Radioman" && a.Name != "Reporter").ToList();
                if (playerNum < 4)
                {
                    avatars = avatars.Where(a => a.Name != "CIA Agent" && a.Name != "Gangster").ToList();
                    if (playerNum < 3)
                    {
                        avatars = avatars.Where(a => a.Name != "Guerilla" && a.Name != "O.W.L.F Agent").ToList();
                        if (playerNum < 2)
                        {
                            avatars = avatars.Where(a => a.Name != "Tracker" && a.Name != "SWAT Officer").ToList();
                        }
                    }
                }
            }
            
            // Create Players based on Avatars
            List<Player> players = new List<Player>();
            var experiences = _context.Playables.Where(p => p.Name == "Experience").ToList();
            var brutestrength = _context.Playables.Where(p => p.Name == "Brute Strength").ToList();
            foreach (Avatar avatar in avatars)
            {
                var drawDeck = experiences.Take(7).ToList();
                experiences.RemoveRange(0, 7);
                drawDeck.AddRange(brutestrength.Take(5).ToList());
                brutestrength.RemoveRange(0, 5);
                switch (avatar.Name)
                {
                    case "Reporter":
                        drawDeck.Add(_context.Playables.Where(p => p.Name == "Sources and Contacts").ToList()[0]);
                        break;
                    case "Radioman":
                        drawDeck.Add(_context.Playables.Where(p => p.Name == "Position and Situation").ToList()[0]);
                        break;
                    case "CIA Agent":
                        drawDeck.Add(_context.Playables.Where(p => p.Name == "In The Shadows").ToList()[0]);
                        break;
                    case "Gangster":
                        drawDeck.Add(_context.Playables.Where(p => p.Name == "Running the Streets").ToList()[0]);
                        break;
                    case "Guerilla":
                        drawDeck.Add(_context.Playables.Where(p => p.Name == "Fighting the Good Fight").ToList()[0]);
                        break;
                    case "O.W.L.F Agent":
                        drawDeck.Add(_context.Playables.Where(p => p.Name == "The Highest Tech").ToList()[0]);
                        break;
                    case "Tracker":
                        drawDeck.Add(_context.Playables.Where(p => p.Name == "It Ain't No Man").ToList()[0]);
                        break;
                    case "SWAT Officer":
                        drawDeck.Add(_context.Playables.Where(p => p.Name == "Experience").ToList()[0]);
                        break;
                    case "Lieutenant":
                        drawDeck.Add(_context.Playables.Where(p => p.Name == "Command Decisions").ToList()[0]);
                        break;
                    case "Detective":
                        drawDeck.Add(_context.Playables.Where(p => p.Name == "Knocking on Doors").ToList()[0]);
                        break;
                }
                drawDeck =drawDeck.OrderBy(item => rnd.Next()).ToList();
                var hand = new List<Playable>();
                hand.AddRange(drawDeck.Take(6));
                drawDeck.RemoveRange(0, 6);
                var newPlayer = new Player();
                newPlayer.newPlayer(avatar, drawDeck, hand);
                players.Add(newPlayer);
            }
            players = players.OrderBy(item => rnd.Next()).ToList();
            var playables = GetPlayablesByMovie(movie).OrderBy(p => rnd.Next()).ToList();
            var enemies = GetEnemiesByMovie(movie, playerNum);
            var dmgs = GetDamages().OrderBy(d => rnd.Next()).ToList();

            var objectives = GetObjectivesByMovie(movie);
            PredatorGame LobbyGame = new PredatorGame();
            LobbyGame.NewGame(players, location, commanders, playables, enemies, dmgs, objectives);

            return LobbyGame;
        }

        public Task<int> UpdateLobby(Lobby lobby)
        {
            try
            {
                _context.Update(lobby);
                return _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public Task<int> DeleteLobby(int id)
        {
            var lobby = _context.Lobbies.FindAsync(id).Result;
            if (lobby == null)
            {
                return null;
            }

            try
            {
                _context.Remove(lobby);
                return _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
    }
}
