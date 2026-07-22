import { NgModule } from '@angular/core';
import { PredatorComponent } from './predator.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GalleryComponent } from './gallery/gallery.component';
import { GameComponent } from './game/game.component';
import { PredatorRoutes } from './predator.routing';
import { CommonModule } from '@angular/common';
import { PredatorlobbiesComponent } from './predatorlobbies/predatorlobbies.component';



@NgModule({
  declarations: [
    PredatorComponent,
    GalleryComponent,
    GameComponent,
    PredatorlobbiesComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PredatorRoutes
  ]
})
export class PredatorModule { }
