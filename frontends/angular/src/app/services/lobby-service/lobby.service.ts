import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Lobby } from '../../models/Lobby';

@Injectable({
  providedIn: 'root'
})
export class LobbyService {

  constructor(private http: HttpClient) { }

  readonly url = `${environment.apiBaseUrl}/api/Lobbies/`;

  getLobbies(): Observable<Lobby[]> {
    return this.http.get<Lobby[]>(this.url);
  }

  PostLobby(lobbyData: Lobby): Observable<Lobby> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Lobby>(this.url, lobbyData, httpHeaders);
  }
  updateLobby(lobby: Lobby): Observable<Lobby> {
    const httpHeaders = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Lobby>(this.url +  lobby.id, lobby, httpHeaders);
  }
  deleteLobbyById(id: number) {
    return this.http.delete<number>(this.url + id);
  }
  getLobbyById(id: number): Observable<Lobby> {
    return this.http.get<Lobby>(this.url + id);
  }
}
