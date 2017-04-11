import './polyfills/polyfills';
import './styles/vendor.css';

declare var module: any;

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';

import { BrowserAppModule } from './app/browser-app.module';

// Enable either Hot Module Reloading or production mode
/* tslint:disable */
if (module['hot']) {
    module['hot'].accept();
    module['hot'].dispose(() => { });
} else {
    enableProdMode();
}

platformBrowserDynamic().bootstrapModule(BrowserAppModule);
