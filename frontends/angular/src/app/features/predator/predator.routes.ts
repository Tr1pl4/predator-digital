import { Routes } from '@angular/router';
import { Lobbies } from './lobbies/lobbies';
import { Game } from './game/game';
import { Gallery } from './gallery/gallery';

export const PREDATOR_ROUTES: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'lobbies' },
  { path: 'lobbies', component: Lobbies },
  { path: 'game/:id', component: Game },
  { path: 'gallery', component: Gallery }
];
