import { Routes } from '@angular/router';
import { Shell } from './layout/shell/shell';

export const routes: Routes = [
  {
    path: '',
    component: Shell,
    children: [
      {
        path: '',
        loadChildren: () =>
          import('./features/home/home.routes').then((m) => m.HOME_ROUTES)
      },
      {
        path: 'auth',
        loadChildren: () =>
          import('./features/auth/auth.routes').then((m) => m.AUTH_ROUTES)
      },
      {
        path: 'gamelist',
        loadChildren: () =>
          import('./features/gamelist/gamelist.routes').then((m) => m.GAMELIST_ROUTES)
      },
      {
        path: 'predator',
        loadChildren: () =>
          import('./features/predator/predator.routes').then((m) => m.PREDATOR_ROUTES)
      }
    ]
  },
  { path: '**', redirectTo: '' }
];
