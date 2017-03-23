import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Players } from './players';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class PlayersService {
    // URL to web api
    private playersUrl = '/api/team/';

    constructor(private http: Http) { }

    getPlayers(id): Promise<Players[]> {
        let playersFullUrl = this.playersUrl + id + '/players';
        return this.http.get(playersFullUrl)
            .toPromise()
            .then(this.extractData)
            .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    private handleError(error: Response | any) {
        // In a real world app, we might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Promise.reject(errMsg);
    }

}
