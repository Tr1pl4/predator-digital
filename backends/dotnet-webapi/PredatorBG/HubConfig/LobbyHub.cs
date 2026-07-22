using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using WebAPI.PredatorBG.Models;
using WebAPI.PredatorBG.Services;

namespace WebAPI.PredatorBG.HubConfig
{
    public class LobbyHub : Hub
    {
        private readonly IPredatorBGService _service;

        public LobbyHub(IPredatorBGService service)
        {
            _service = service;
        }

        public async Task getServer(int id)
        {
            Lobby lobby = await _service.GetLobbyById(id);

            await Clients.All.SendAsync("getServerResponse" + id, lobby);
        }

        public async Task updateServer(Lobby lobby, string msg)
        {
            //Gamestate changing messages
            if (msg == "start")
            {
                lobby.LobbyGame = _service.CreateGame(lobby.Movie, lobby.PlayersNum);
                lobby.LobbyGame.Active = true;
                lobby.LobbyGame.StepPhase();
            }
            else if (msg == "endGame")
            {
                lobby.LobbyGame.Active = false;
            }
            else if (msg == "endTurn")
            {
                lobby.LobbyGame.StepPlayer();
            }

            // Cooperative messages
            else if (msg.Contains("Heal"))
            {
                string[] messages = msg.Split(" ");
                int playerId = int.Parse(messages[1]);

                if (lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].Heal > 0)
                {
                    lobby.LobbyGame.Heal(lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer], lobby.LobbyGame.Players[playerId]);
                }
                else if (lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].HealMin > 0)
                {
                    lobby.LobbyGame.HealMin(lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer], lobby.LobbyGame.Players[playerId]);
                }
                else if (lobby.LobbyGame.ObjectiveDeck[0].Name == "Other - World Life - Form")
                {
                    if (lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].CurRec >= 6)
                    {
                        lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].MarkNum -= 1;
                        lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].CurRec -= 6;
                    }
                }
            }

            // Attack messages
            else if (msg == "Hills") {
                if (lobby.LobbyGame.Hills.FaceDown)
                {
                    lobby.LobbyGame.Scann(lobby.LobbyGame.Hills, msg);
                }
                else
                {
                    var success = lobby.LobbyGame.Attack(lobby.LobbyGame.Hills);
                    if (success)
                    {
                        lobby.LobbyGame.Hills = null;
                    }
                }
            }
            else if (msg == "Ruins")
            {
                if (lobby.LobbyGame.Ruins.FaceDown)
                {
                    lobby.LobbyGame.Scann(lobby.LobbyGame.Ruins, msg);
                }
                else
                {
                    var success = lobby.LobbyGame.Attack(lobby.LobbyGame.Ruins);
                    if (success)
                    {
                        lobby.LobbyGame.Ruins = null;
                    }
                }
            }
            else if (msg == "River")
            {
                if (lobby.LobbyGame.River.FaceDown)
                {
                    lobby.LobbyGame.Scann(lobby.LobbyGame.River, msg);
                }
                else
                {
                    var success = lobby.LobbyGame.Attack(lobby.LobbyGame.River);
                    if (success)
                    {
                        lobby.LobbyGame.River = null;
                    }
                }
            }
            else if (msg == "Graveyard")
            {
                if (lobby.LobbyGame.Graveyard.FaceDown)
                {
                    lobby.LobbyGame.Scann(lobby.LobbyGame.Graveyard, msg);
                }
                else
                {
                    var success = lobby.LobbyGame.Attack(lobby.LobbyGame.Graveyard);
                    if (success)
                    {
                        lobby.LobbyGame.Graveyard = null;
                    }
                }
            }
            else if (msg == "Underground")
            {
                if (lobby.LobbyGame.Underground.FaceDown)
                {
                    lobby.LobbyGame.Scann(lobby.LobbyGame.Underground, msg);
                }
                else
                {
                    var success = lobby.LobbyGame.Attack(lobby.LobbyGame.Underground);
                    if (success)
                    {
                        lobby.LobbyGame.Underground = null;
                    }
                }
            }
            else if (msg.Contains("CombatZone"))
            {
                string[] messages = msg.Split(" ");
                int enemyId = int.Parse(messages[1]);
                lobby.LobbyGame.Attack(lobby.LobbyGame.CombatEnemies[enemyId]);
            }

            // Purchase messages
            else if (msg == "Commander")
            {
                lobby.LobbyGame.Buy(lobby.LobbyGame.CommanderDeck[0]);
            }
            else if (msg.Contains("Barrack"))
            {
                string[] messages = msg.Split(" ");
                int barrackId = int.Parse(messages[1]);
                lobby.LobbyGame.Buy(lobby.LobbyGame.Barrack[barrackId]);
            }

            // Action messages
            else if (msg.Contains("Hand"))
            {
                string[] messages = msg.Split(" ");
                int handId = int.Parse(messages[1]);
                if (! (lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].Kill == 0))
                {
                    lobby.LobbyGame.Kill(lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].Hand[handId], "Hand");
                    
                }
                else if (!(lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].Convert == 0))
                {
                    lobby.LobbyGame.Convert(lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].Hand[handId]);
                }
                else
                {
                    lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].Play(lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].Hand[handId]);
                }
            }
            else if (msg.Contains("Activate"))
            {
                string[] messages = msg.Split(" ");
                int activateId = int.Parse(messages[1]);
                if (! (lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].Kill == 0))
                {
                    lobby.LobbyGame.Kill(lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].ActiveCards[activateId], "ActiveCards");
                }
                else if (! (lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].Convert == 0))
                {
                    lobby.LobbyGame.Convert(lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].ActiveCards[activateId]);
                }
                else
                {
                    lobby.LobbyGame.Activate(lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer].ActiveCards[activateId]);
                }
            }
            else if (msg.Contains("Coordinate"))
            {
                string[] messages = msg.Split(" ");
                int coordinateId = int.Parse(messages[1]);
                int from = int.Parse(messages[2]);

                lobby.LobbyGame.Coordinate(lobby.LobbyGame.Players[from], lobby.LobbyGame.Players[lobby.LobbyGame.ActivePlayer], lobby.LobbyGame.Players[from].Hand[coordinateId]);
            }
            else if (msg.Contains("Operations"))
            {
                string[] messages = msg.Split(" ");
                int tryToComplete = int.Parse(messages[1]);

                lobby.LobbyGame.Check(lobby.LobbyGame.Operations[tryToComplete]);
            }

            await _service.UpdateLobby(lobby);
            Console.WriteLine(lobby);

            await Clients.All.SendAsync("updateServerResponse" + lobby.Id, lobby);

        }
    }
}
