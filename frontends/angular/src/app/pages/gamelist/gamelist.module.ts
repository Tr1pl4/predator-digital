import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GamelistComponent } from './gamelist.component';
import { RouterModule } from '@angular/router';
import { GameListRoutes } from './gamelist.routing';



@NgModule({
  declarations: [
    GamelistComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    GameListRoutes
  ]
})
export class GamelistModule { }
