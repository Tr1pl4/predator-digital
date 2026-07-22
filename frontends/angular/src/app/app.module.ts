// Angular modules
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

// Self-made modules
import { GamelistModule } from './pages/gamelist/gamelist.module';
import { AuthModule } from './pages/auth/auth.module';
import { PredatorModule } from './pages/predator/predator.module';

// Self-made components
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { NavMenuComponent } from './pages/nav-menu/nav-menu.component';

// Self-made service
import { UserService } from './services/user-service/user.service';
import { AppRoutingModule } from './app-routing.module';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
  ],

  imports: [
    CommonModule,
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    AuthModule,
    PredatorModule,
    GamelistModule
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
