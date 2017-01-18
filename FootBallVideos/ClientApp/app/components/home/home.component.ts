import { Tournaments } from '../../tournaments/tournaments';
import { TournamentsService } from '../../tournaments/tournaments.service';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'home',
    template: require('./home.component.pug'),
    styles: [require('./home.component.css')],
    providers: [TournamentsService],
})
export class HomeComponent implements OnInit {
    errorMessage: string;
    tournaments: Tournaments[];
    mode = 'Promise';
        constructor(private tournamentsService: TournamentsService) { }

    ngOnInit() { this.getTournaments(); }

    getTournaments() {
        this.tournamentsService.getTournaments()
            .then(
            tournaments => this.tournaments = tournaments,
            error => this.errorMessage = <any>error);
    }

  
}
