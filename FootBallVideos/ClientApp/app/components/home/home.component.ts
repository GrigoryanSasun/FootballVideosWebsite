import { Tournaments } from '../../tournaments/tournaments';
import { TournamentsService } from '../../tournaments/tournaments.service';
import { Teams } from '../../teams/teams';
import { TeamsService } from '../../teams/teams.service';
import { Players } from '../../players/players';
import { PlayersService } from '../../players/players.service';

import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'home',
    template: require('./home.component.pug'),
    styles: [require('./home.component.css')],
    providers: [TournamentsService, TeamsService, PlayersService],
})
export class HomeComponent implements OnInit {
    errorMessage: string;
    tournaments: Tournaments[];
    teams: Teams[];
    players: Players[];
    hideTournamentsDropdown: boolean = true;
    hideClubsDropdown: boolean = true;
    hideTeamsDropdown: boolean = true;

    constructor(private tournamentsService: TournamentsService, private teamsService: TeamsService, private playersService: PlayersService) { }

    ngOnInit() { this.getTournaments(); this.getTeams(); this.getPlayers() }

    getTournaments() {
        this.tournamentsService.getTournaments()
            .then(
            tournaments => this.tournaments = tournaments,
            error => this.errorMessage = <any>error);
    }

    getTeams() {
        this.teamsService.getTeams()
            .then(
            teams => this.teams = teams,
            error => this.errorMessage = <any>error);
    }
    getPlayers() {
        this.playersService.getPlayers()
            .then(
            players => this.players = players,
            error => this.errorMessage = <any>error);
    }
}
