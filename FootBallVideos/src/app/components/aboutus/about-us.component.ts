import { Component } from '@angular/core';

@Component({
    selector: 'about-us',
    template: require('./about-us.component.pug')
})
export class AboutUsComponent {
    public currentCount = 0;

    public incrementCounter() {
        this.currentCount++;
    }
}
