import { Component } from '@angular/core';
import { ChangeColorsService } from '../../services/change-colors.service';
@Component({
    selector: 'footer',
    template: require('./footer.component.pug'),
    styleUrls: ['./footer.component.scss']
})
export class FooterComponent {
    
    constructor(private changeColorsService: ChangeColorsService) {
        this.changeColorsService = changeColorsService;
        this.changeColorsService.getValue();
    }
   
}
