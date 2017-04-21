import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, JsonpModule } from '@angular/http';
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
//import { ElasticSearchService } from './app/services/elasticsearch.service';

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        NavMenuComponent,
        AboutUsComponent,
        ContactsComponent,
        HomeComponent,
        SideBarComponent,
        FooterComponent,
        DetailsComponent,
        //ElasticComponent,

    ],
    providers: [
        AnimationService,
        ChangeColorsService
        //ElasticSearchService,
    ],
    imports: [
        BrowserModule,
        HttpModule,
        JsonpModule,
        InfiniteScrollModule,
        //Ng2CompleterModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'about-us', component: AboutUsComponent },
            { path: 'contacts', component: ContactsComponent },
            { path: 'videodetails', component: DetailsComponent },
            //{ path: 'elastic', component:ElasticComponent },
            { path: '**', redirectTo: 'home' },

        ])
    ]
})
export class AppModule {

}
