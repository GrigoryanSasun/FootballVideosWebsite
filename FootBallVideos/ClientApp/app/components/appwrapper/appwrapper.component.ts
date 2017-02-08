import { Component } from '@angular/core';
import { AnimationService } from '../../services/animation.service';
@Component({
    selector: 'appwrapper',
    template: require('./appwrapper.component.pug'),
    styles: [require('./appwrapper.component.css')],
})
export class AppWrapperComponent {
    constructor(private animationService: AnimationService) {
        this.animationService = animationService;
    }
}
