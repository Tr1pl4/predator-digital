import { Routes, RouterModule } from '@angular/router';
import { GamelistComponent } from './gamelist.component';

const routes: Routes = [
    {
        path: '',
        component: GamelistComponent,
    },
];

export const GameListRoutes = RouterModule.forChild(routes);
