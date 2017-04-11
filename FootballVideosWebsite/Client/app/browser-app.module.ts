import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ORIGIN_URL } from './shared/constants/baseurl.constant';

import { AppModule } from './app.module';
import { AppComponent } from './components/app/app.component';

export function getOriginUrl() {
  return window.location.origin;
}

@NgModule({
    bootstrap: [AppComponent],
    imports: [
        BrowserModule.withServerTransition({
            appId: 'football-videos' // make sure this matches with your Server NgModule
        }),
        BrowserAnimationsModule,
        // Our Common AppModule
        AppModule
    ],
    providers: [
        {
            provide: ORIGIN_URL,
            useFactory: (getOriginUrl)
        }
    ]
})
export class BrowserAppModule {
}
