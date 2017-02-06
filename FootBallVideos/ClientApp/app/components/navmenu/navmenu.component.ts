import { Component } from '@angular/core';
import { AnimationService } from '../../services/animation.service';

@Component({
    selector: 'nav-menu',
    template: require('./navmenu.component.pug'),
    styles: [require('./navmenu.component.css')],
   
})
export class NavMenuComponent {
    constructor(private animationService: AnimationService) {
        this.animationService = animationService;
    }

    
}
