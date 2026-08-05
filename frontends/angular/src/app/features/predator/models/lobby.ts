import { Game } from './game';

export class Lobby {
  id = 0;
  name = 'Init';
  playersNum = 0;
  lobbyGame: Game = new Game();
  movie = 1;
}
