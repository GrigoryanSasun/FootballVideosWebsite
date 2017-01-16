import { Component } from '@angular/core';

@Component({
    selector: 'footer',
    template: require('./footer.component.pug'),
    styles: [require('./footer.component.css')]
})
export class FooterComponent {
    public currentCount = 0;

   
}
