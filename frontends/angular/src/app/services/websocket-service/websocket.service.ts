import { Injectable } from "@angular/core";
import * as signalR from '@aspnet/signalr';
import { Subject } from "rxjs";
import { environment } from "src/environments/environment";
import { Lobby } from "../../models/Lobby";


@Injectable({
    providedIn: 'root'
})

export class WebsocketService {
    broadcastedData: Subject<Lobby> = new Subject<Lobby>();
    hubconnection: signalR.HubConnection;

    constructor() {}

    startConnection = () => {
        this.hubconnection = new signalR.HubConnectionBuilder()
        .withUrl(environment.hubUrl, {
            skipNegotiation: true,
            transport: signalR.HttpTransportType.WebSockets
        })
        .build();

        this.hubconnection
        .start()
        .then(() => {
            console.log('Hub Connection Started!');
        })
        .catch(err => console.log('Error while starting connection: ' + err))
    }

    getServer(id : number) {
        this.hubconnection.invoke("getServer",id)
        .catch(err => console.log(err));
    }

    getServerListener(id : number) {
        this.hubconnection.on("getServerResponse" + id, (res) => {
            this.broadcastedData.next(res);
        })
    }

    updateServer(lobby : Lobby, message = '') {
        console.log('message:', message);
        this.hubconnection.invoke("updateServer",lobby, message)
        .catch(err => console.log(err));
    }

    updateServerListener(id: number) {
        this.hubconnection.on("updateServerResponse" + id, (res) => {
            this.broadcastedData.next(res);
        })
    }
}