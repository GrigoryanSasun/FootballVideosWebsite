import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map'
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ElasticSearchService {
    // URL to web api
    private actionUrl = '/api/FootballVideosElasticsearch/';

    constructor(private http: Http) { }

    public CreateIndex = (): Observable<Response> => {
        let url = this.actionUrl + "createindex";
        return this.http.get(url).map((response: Response) => <any>response.json());
    };
    public CreateData = (): Observable<any> => {
        let url = this.actionUrl + "createdata";
        return this.http.get(url).map((response: Response) => <any>response.json());
    };
    public IndexExists = (): Observable<any> => {
        let url = this.actionUrl + "indexexists";
        return this.http.get(url).map((response: Response) => <any>response.json());
    }   
}