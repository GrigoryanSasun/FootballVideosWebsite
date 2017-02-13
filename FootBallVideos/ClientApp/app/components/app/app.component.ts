import { Component, ViewEncapsulation } from '@angular/core';
import { AnimationService } from '../../services/animation.service';

@Component({
    selector: 'app',
    template: require('./app.component.pug'),
    styles: [require('./app.component.css')],
    encapsulation: ViewEncapsulation.None,
})
export class AppComponent {
    constructor(private animationService: AnimationService) {
        this.animationService = animationService;
    }
}