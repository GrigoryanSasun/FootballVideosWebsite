import { Component } from '@angular/core';
import { ChangeColorsService } from '../../services/change-colors.service';
@Component({
    selector: 'footer',
    template: require('./footer.component.pug'),
    styles: [require('./footer.component.css')]
})
export class FooterComponent {
    
    constructor(private changeColorsService: ChangeColorsService) {
        this.changeColorsService = changeColorsService;
        this.changeColorsService.getValue();
    }
   
}
