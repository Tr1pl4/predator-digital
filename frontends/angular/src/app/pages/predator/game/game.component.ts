import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Card } from 'src/app/models/Card';
import { Enemy } from 'src/app/models/Enemy';
import { PlayableSkill } from 'src/app/models/Enums';
import { Lobby } from 'src/app/models/Lobby';
import { Location } from 'src/app/models/Location';
import { Playable } from 'src/app/models/Playable';
import { Player } from 'src/app/models/Player';
import { LobbyService } from 'src/app/services/lobby-service/lobby.service';
import { WebsocketService } from 'src/app/services/websocket-service/websocket.service';

@Component({
    selector: 'app-game',
    templateUrl: './game.component.html',
    styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit, OnDestroy {
    subscription: Subscription = new Subscription();
    imgPrepath = '../../../../';
    portraitPath = '../../../../assets/games-img/portrait.png';
    id: number;
    playerId: number;
    lobby = new Lobby()
    loc: any;
    constructor(
        public websocketService: WebsocketService, 
        private lobbyService: LobbyService, 
        private router: Router, 
        private toastr: ToastrService,) {
        this.id = this.router.getCurrentNavigation()?.extras?.state?.sendId;
        this.lobbyService.getLobbyById(this.id).subscribe(lobbyResult => {
            this.lobby = lobbyResult;
        })
    }

    ngOnInit(): void {
        this.playerId = Number(localStorage.getItem('playerId'));
        localStorage.removeItem('playerId');
        console.log(this.playerId);
        const sub = this.websocketService.broadcastedData.subscribe(res => {
            this.lobby = res;
        });
        this.subscription.add(sub);
        this.websocketService.startConnection();
        this.websocketService.getServerListener(this.id);
        this.websocketService.updateServerListener(this.id);

        setTimeout(() => {
            this.getWebsocket();
        }, 500);
    }
    
    ngOnDestroy() {
        this.lobby.playersNum -= 1;
        this.lobby.lobbyGame.active = false;
        this.updateWebsocket();
        this.subscription.unsubscribe();
        this.websocketService.hubconnection.off("getServerResponse");
        this.websocketService.hubconnection.off("updateServerResponse");

        if (this.lobby.playersNum == 0) {
            this.lobbyService.deleteLobbyById(this.id).subscribe(res =>
            console.log(res)
            );
        }
    }

    getWebsocket() {
        this.websocketService.getServer(this.id);
    }

    updateWebsocket(message = '') {
        if (message.includes('Hand')) {
            const toAdd = message.split(' ')[1];
            if (this.lobby.lobbyGame.activePlayer != this.playerId && !this.lobby.lobbyGame.players[this.playerId].coordinated) {
                message = 'Coordinate ' + toAdd + ' ' + this.playerId;
            }
        }

        this.websocketService.updateServer(this.lobby, message);

        setTimeout(() =>{
            console.log(this.lobby);
        },500);

        setTimeout(() => {
            if (!this.lobby.lobbyGame.active && this.lobby.lobbyGame.result != 0) {
                if (this.lobby.lobbyGame.result > 0) {
                    this.toastr.success('You have won.', 'Congratulations!');
                }
                else {
                    this.toastr.error('You have lost.', 'Better luck next time.');
                }
            }
        })
    }

    displayCard(card: Card) {
        let imgsrc = '';
        if (card != null) {
            imgsrc = this.imgPrepath + card.imagepath;
        }
        else {
            imgsrc = this.imgPrepath + 'assets/games-img/portrait.png';
        }
        return imgsrc;
    }

    displayEnemy(enemy: Enemy) {
        let imgsrc = '';
        if (enemy != null) {
            if (!enemy.faceDown) {
                imgsrc = this.imgPrepath + enemy.imagepath;
            }
            else {
                imgsrc = this.portraitPath;
            }
        }
        else {
            imgsrc = this.portraitPath;
        }
        
        return imgsrc;
    }

    displayLocation(location: Location) {
        let imgsrc = '';
        if (location != null) {
            imgsrc = this.imgPrepath + location.imagepath;
        }
        else {
            imgsrc = this.portraitPath;
        }
        return imgsrc;
    }

    displayPlayer(player: Player) {
        let imgsrc = '';
        if (player != null) {
            imgsrc = this.imgPrepath + player.imagepath;
        }
        else {
            imgsrc = this.portraitPath;
        }
        return imgsrc;
    }

    disableCard(card: Playable) {
        if (this.lobby.lobbyGame.activePlayer == this.playerId) {
            return false;
        }
        else if (!this.lobby.lobbyGame.players[this.playerId].coordinated && 
            card.skills.some(s => s.skill == PlayableSkill.Coordinate)){
                return false;
        }
        return true;
    }

    startGame() {
        this.updateWebsocket('start');
    }

    endGame() {
        this.updateWebsocket('endGame');
    }

    endTurn() {
        this.updateWebsocket('endTurn');
    }
}
