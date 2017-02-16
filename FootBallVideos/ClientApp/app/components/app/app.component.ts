import { Component, ViewEncapsulation } from '@angular/core';

@Component({
    selector: 'app',
    template: require('./app.component.pug'),
    styles: [require('./app.component.css')],
    encapsulation: ViewEncapsulation.None,
})
export class AppComponent {
  
}