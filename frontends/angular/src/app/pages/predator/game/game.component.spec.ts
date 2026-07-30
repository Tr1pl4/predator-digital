import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of, Subject } from 'rxjs';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

import { GameComponent } from './game.component';
import { LobbyService } from 'src/app/services/lobby-service/lobby.service';
import { WebsocketService } from 'src/app/services/websocket-service/websocket.service';
import { Lobby } from 'src/app/models/Lobby';

describe('GameComponent', () => {
  let component: GameComponent;
  let fixture: ComponentFixture<GameComponent>;

  const lobbyServiceMock = {
    getLobbyById: jasmine.createSpy('getLobbyById').and.returnValue(of(new Lobby())),
    deleteLobbyById: jasmine.createSpy('deleteLobbyById').and.returnValue(of(1)),
    updateLobby: jasmine.createSpy('updateLobby').and.returnValue(of({}))
  };

  const routerMock = {
    getCurrentNavigation: jasmine.createSpy('getCurrentNavigation').and.returnValue({
      extras: { state: { sendId: 1 } }
    })
  };

  const toastrMock = {
    success: jasmine.createSpy('success'),
    error: jasmine.createSpy('error')
  };

  const websocketServiceMock = {
    broadcastedData: new Subject<Lobby>(),
    hubconnection: {
      off: jasmine.createSpy('off')
    },
    startConnection: jasmine.createSpy('startConnection'),
    getServerListener: jasmine.createSpy('getServerListener'),
    updateServerListener: jasmine.createSpy('updateServerListener'),
    getServer: jasmine.createSpy('getServer'),
    updateServer: jasmine.createSpy('updateServer')
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GameComponent],
      providers: [
        { provide: LobbyService, useValue: lobbyServiceMock },
        { provide: Router, useValue: routerMock },
        { provide: ToastrService, useValue: toastrMock },
        { provide: WebsocketService, useValue: websocketServiceMock }
      ]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
