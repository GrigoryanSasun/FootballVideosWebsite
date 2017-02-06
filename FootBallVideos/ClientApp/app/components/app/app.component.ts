import { Component } from '@angular/core';
import { AnimationService } from '../../services/animation.service';
@Component({
    selector: 'app',
    template: require('./app.component.pug'),
    styles: [require('./app.component.css')],
})
export class AppComponent {
    constructor(private animationService: AnimationService) {
        this.animationService = animationService;
    }
}
