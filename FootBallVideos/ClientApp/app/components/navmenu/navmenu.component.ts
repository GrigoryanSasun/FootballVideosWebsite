import { Component } from '@angular/core';

@Component({
    selector: 'nav-menu',
    template: require('./navmenu.component.pug'),
    styles: [require('./navmenu.component.css')]
})
export class NavMenuComponent {
    public isCollapsed = true;
}
