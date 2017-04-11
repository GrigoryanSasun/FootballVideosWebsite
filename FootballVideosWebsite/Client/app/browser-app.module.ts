import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppModule } from './app.module';
import { AppComponent } from './components/app/app.component';

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
    ]
})
export class BrowserAppModule {
}
