import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GamelistComponent } from './pages/gamelist/gamelist.component';
import { HomeComponent } from './pages/home/home.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'gamelist', component: GamelistComponent },
    { path: 'predator', loadChildren: () => import('./pages/predator/predator.module').then(m => m.PredatorModule) },
    { path: 'auth', loadChildren: () => import('./pages/auth/auth.module').then(m => m.AuthModule) },
    {
      path: '**',
      redirectTo: '',
      pathMatch: 'full'
    },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
