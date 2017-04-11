import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { BrowserModule } from '@angular/platform-browser';
import { NoopAnimationsModule  } from '@angular/platform-browser/animations';

import { AppModule } from './app.module';
import { AppComponent } from './components/app/app.component';


@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule.withServerTransition({
            appId: 'football-videos' // make sure this matches with your Browser NgModule
        }),
        ServerModule,
        NoopAnimationsModule,
        
        // Our Common AppModule
        AppModule 
    ]
})
export class ServerAppModule {
}
