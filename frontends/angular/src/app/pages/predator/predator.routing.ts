import { Routes, RouterModule } from '@angular/router';
import { GalleryComponent } from './gallery/gallery.component';
import { GameComponent } from './game/game.component';
import { PredatorComponent } from './predator.component';
import { PredatorlobbiesComponent } from './predatorlobbies/predatorlobbies.component';

const routes: Routes = [
    {
        path: '',
        component: PredatorComponent,
        children: [
            { path: 'lobbies', component: PredatorlobbiesComponent },
            { path: 'gallery', component: GalleryComponent },
            { path: 'game/:id', component: GameComponent },
            {
                path: '**',
                redirectTo: 'lobbies',
                pathMatch: 'full'
            },
        ]
    },
    {
        path: '**',
        redirectTo: '',
        pathMatch: 'full'
    },
];

export const PredatorRoutes = RouterModule.forChild(routes);
