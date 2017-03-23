import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './app/components/app/app.component';
import { NavMenuComponent } from './app/components/navmenu/navmenu.component';
import { HomeComponent } from './app/components/home/home.component';
import { SideBarComponent } from './app/components/sidebar/sidebar.component';
import { ContactsComponent } from './app/components/contacts/contacts.component';
import { AboutUsComponent } from './app/components/aboutus/about-us.component';
import { FooterComponent } from './app/components/footer/footer.component';
import { DetailsComponent } from './app/components/details/details.component';
import { InfiniteScrollModule } from 'angular2-infinite-scroll';
import { AnimationService } from './app/services/animation.service';
import { ChangeColorsService } from './app/services/change-colors.service';
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
        ChangeColorsService,
        //ElasticSearchService,
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too
        //BrowserModule,
        //HttpModule,
        //JsonpModule,
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
