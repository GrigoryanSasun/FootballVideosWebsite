import { AnimationService } from '../../services/animation.service';
import { ChangeColorsService } from '../../services/change-colors.service';
import { Component } from '@angular/core';
@Component({
    selector: 'nav-menu',
    template: require('./navmenu.component.pug'),
    styleUrls: ['./navmenu.component.scss'],
})
export class NavMenuComponent {
    height = 0;
    constructor(private animationService: AnimationService, private changeColorsService: ChangeColorsService) {
        this.animationService = animationService;
        this.changeColorsService = changeColorsService;
        this.changeColorsService.getValue();
    }
}
