import { Injectable } from '@angular/core';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class AnimationService {

    categiriesDesctopState: string = 'in';
    categiriesMobileState: string = 'in';
    searchTabletState: string = 'in';
    public toggleMenu() {
        this.categiriesDesctopState = this.categiriesDesctopState === 'out' ? 'in' : 'out';
        this.categiriesMobileState = this.categiriesMobileState === 'up' ? 'in' : 'up';
    }
    public toggleSearch() {
        this.searchTabletState = this.searchTabletState === 'up' ? 'in' : 'up';
    }
}
