import { Injectable, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/platform-browser';
@Injectable()
export class ChangeColorsService {
    private teamNameForColors;

    constructor( @Inject(DOCUMENT) private document) {}

    setValue(val) {
        this.teamNameForColors=val;
        }
    getValue() {
        return this.teamNameForColors;
    }
    changeTheme() {
        let stylesheetPath = '/Content/themes/' + this.teamNameForColors + '.css'
        this.document.getElementById('theme').setAttribute('href', stylesheetPath);
    }
}