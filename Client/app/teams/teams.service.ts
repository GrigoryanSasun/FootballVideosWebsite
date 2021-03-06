﻿import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
//import { Headers, RequestOptions } from '@angular/http';
import { Teams } from './teams';
import 'rxjs/add/operator/toPromise';
import { ORIGIN_URL } from '../shared/constants/baseurl.constant';

@Injectable()
export class TeamsService {
    // URL to web api
    private teamsUrl = `${this.baseUrl}/api/team/`;

    constructor(private http: Http, @Inject(ORIGIN_URL) private baseUrl: string) { }

    getTeams(): Promise<Teams[]> {
        return this.http.get(this.teamsUrl)
            .toPromise()
            .then(this.extractData)
            .catch(this.handleError);
    }

    private extractData(res: Response) {
        //let body = res.json();
        return res.json() || [];
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
