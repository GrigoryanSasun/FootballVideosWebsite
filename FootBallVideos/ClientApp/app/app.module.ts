import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppWrapperComponent } from './components/appwrapper/appwrapper.component';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { SideBarComponent } from './components/sidebar/sidebar.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { AboutUsComponent } from './components/aboutus/about-us.component';
import { FooterComponent } from './components/footer/footer.component';
import { DetailsComponent } from './components/details/details.component';
import { InfiniteScrollModule } from 'angular2-infinite-scroll';
import { AnimationService } from './services/animation.service';
import { ChangeColorsService } from './services/change-colors.service';

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppWrapperComponent,
        AppComponent,
        NavMenuComponent,
        AboutUsComponent,
        ContactsComponent,
        HomeComponent,
        SideBarComponent,
        FooterComponent,
        DetailsComponent
    ],
    providers: [
        AnimationService,
        ChangeColorsService,
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too
        InfiniteScrollModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'about-us', component: AboutUsComponent },
            { path: 'contacts', component: ContactsComponent },
            { path: 'videodetails', component: DetailsComponent },
            { path: '**', redirectTo: 'home' },

        ])
    ]
})
export class AppModule {
   
}
