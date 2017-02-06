import { AnimationService } from '../../services/animation.service';
import { Component, OnInit, trigger, state, style, transition, animate} from '@angular/core';

@Component({
    selector: 'home',
    template: require('./home.component.pug'),
    styles: [require('./home.component.css')],
    providers: [],
})
export class HomeComponent implements OnInit {
    
    videoImages = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18]; 

    constructor(private animationService: AnimationService) {
        this.animationService = animationService;
    }

    ngOnInit() {  }
    
    onScrollDown() {
        let last = this.videoImages[this.videoImages.length - 1];
        for (let i = 0; i < 8; i++) {
            this.videoImages.push(last + i);
        }
    }
}
