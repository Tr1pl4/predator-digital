import { Component, KeyValueDiffers, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Game } from 'src/app/models/Game';
import { Lobby } from 'src/app/models/Lobby';
import { LobbyService } from 'src/app/services/lobby-service/lobby.service';

@Component({
  selector: 'app-predatorlobbies',
  templateUrl: './predatorlobbies.component.html',
  styleUrls: ['./predatorlobbies.component.css']
})
export class PredatorlobbiesComponent implements OnInit {
  isLoggedIn: boolean;
  LobbyList: Lobby[];
  lobbyForm: FormGroup;
  lobbyId = 0;
  differ: any;

  constructor(
    private formbulider: FormBuilder,
    public lobbyService: LobbyService,
    public router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private differs: KeyValueDiffers
  ) {
    this.differ = this.differs.find({}).create();
  }

  ngOnInit() {
    this.isLoggedIn = localStorage.getItem('name') != null;
    this.getLobbies();
    this.lobbyForm = this.formbulider.group({
      movie: ['', [Validators.required, Validators.min(1), Validators.max(2)]]
    });
  }

  getLobbies() {
    this.lobbyService.getLobbies().subscribe(
      res => {
        this.LobbyList = res;
      }
    );
  }

  JoinLobby(id: number) {
    this.lobbyService.getLobbyById(id).subscribe(lobbyResult => {
      if (!lobbyResult.lobbyGame.active && lobbyResult.playersNum < 5) {
      localStorage.setItem('playerId', lobbyResult.playersNum.toString());
      lobbyResult.playersNum += 1;
      this.UpdateLobby(lobbyResult)
      this.router.navigate(["../game/" + lobbyResult.id], { state: { sendId: lobbyResult.id }, relativeTo: this.route });
      }
      else {
        this.toastr.error('Please refresh the list of lobbies.','Failed to join!');
        this.getLobbies();
      }
    });
  }

  PostLobby(lobby: Lobby) {
    if (localStorage.getItem('name') != null) {
      lobby.name = localStorage.getItem('name') + '\'s lobby';
    }
    lobby.lobbyGame = new Game();
    lobby.playersNum = 0;
    this.lobbyService.PostLobby(lobby).subscribe(
      res => {
        this.toastr.success('Lobby Created Successfully.', 'Success!');
        console.log(res);
        this.JoinLobby(res.id);
      },
      err => {
        this.toastr.error('Failed to create Lobby.', 'Failure!');
        console.log(err);
      }
    );
  }
  UpdateLobby(lobby: Lobby) {
    this.lobbyService.updateLobby(lobby).subscribe(() => {
      this.getLobbies();
    },
      err => {
        console.log(err);
      }
    );
  }
  DeleteLobby(id: number) {
    if (confirm('Do you want to delete this lobby?')) {
      this.lobbyService.deleteLobbyById(id).subscribe(() => {
        this.getLobbies();
      },
        err => {
          this.toastr.error('Failed to delete Lobby.', 'Failure!');
          console.log(err);
        }
      );
    }
  }
}
