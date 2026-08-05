import { Routes } from '@angular/router';
import { Login } from './login/login';
import { Registration } from './registration/registration';

export const AUTH_ROUTES: Routes = [
  { path: 'login', component: Login },
  { path: 'register', component: Registration },
  { path: '', pathMatch: 'full', redirectTo: 'login' }
];
