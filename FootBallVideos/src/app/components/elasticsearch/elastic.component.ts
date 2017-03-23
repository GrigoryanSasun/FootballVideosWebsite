import { Component } from '@angular/core';
import { ElasticSearchService } from '../../services/elasticsearch.service';
import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';

@Component({
    selector: 'elastic',
    template: require('./elastic.component.pug'),    
    
})
export class ElasticComponent {
       constructor(private _elasticService: ElasticSearchService) {
      
    }
    public CreateData() {
        this._elasticService.CreateData().subscribe(
            error => console.log(error),
            () => console.log('CreateData complete'));
    }

    public CreateIndex() {   
               this._elasticService.CreateIndex().subscribe(
                error => console.log(error),
                () => {
                    console.log('CreateIndex complete');
                   
                });
    }  

    ngOnInit() {
        this._dataService
            .IndexExists()
            .subscribe(data => this.IndexExists = data,
            error => console.log(error),
            () => console.log('IndexExists complete'));
    }
}    

