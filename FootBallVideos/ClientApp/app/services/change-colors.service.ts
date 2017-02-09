import { Injectable, Inject } from '@angular/core';

@Injectable()
export class ChangeColorsService {
    private teamNameForColors;

    constructor() {}

    setValue(val) {
        this.teamNameForColors='';
        var splitedValues=val.split(' ');
        if(splitedValues.length > 1){
            for(var i=0;i<splitedValues.length-1;i++){
             this.teamNameForColors += splitedValues[i]+'-';
        }
         this.teamNameForColors+=splitedValues[splitedValues.length-1];
        } else {
        this.teamNameForColors=val;
        }
}
    getValue() {
        return this.teamNameForColors;
    }
}