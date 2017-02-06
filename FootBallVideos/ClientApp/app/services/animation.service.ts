import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class AnimationService {

    categiriesDesctopState: string = 'in';
    categiriesMobileState: string = 'in';
    public toggleMenu() {
        // 1-line if statement that toggles the value:
        this.categiriesDesctopState = this.categiriesDesctopState === 'out' ? 'in' : 'out';
        this.categiriesMobileState = this.categiriesMobileState === 'up' ? 'in' : 'up';
    }
}
