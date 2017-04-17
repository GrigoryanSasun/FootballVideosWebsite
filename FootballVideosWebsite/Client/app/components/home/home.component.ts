import { AnimationService } from '../../services/animation.service';
import { ChangeColorsService } from '../../services/change-colors.service';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'home',
    template: require('./home.component.pug'),
    styles: [String(require('./home.component.scss'))],
    providers: [],
})
export class HomeComponent implements OnInit {

    videoImages = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18];
    teamNameForColors: string = '';

    constructor(private animationService: AnimationService, private changeColorsService: ChangeColorsService ) {
        this.animationService = animationService;
        this.changeColorsService = changeColorsService;
        this.changeColorsService.getValue();
    }

    ngOnInit() { }

    

    onScrollDown() {
        let last = this.videoImages[this.videoImages.length - 1];
        for (let i = 0; i < 8; i++) {
            this.videoImages.push(last + i);
        }
    }
}
