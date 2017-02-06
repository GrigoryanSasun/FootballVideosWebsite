import { Tournaments } from '../../tournaments/tournaments';
import { TournamentsService } from '../../tournaments/tournaments.service';
import { Teams } from '../../teams/teams';
import { TeamsService } from '../../teams/teams.service';
import { Players } from '../../players/players';
import { PlayersService } from '../../players/players.service';
import { AnimationService } from '../../services/animation.service';
import { Component, OnInit, trigger, state, style, transition, animate} from '@angular/core';

@Component({
    selector: 'home',
    template: require('./home.component.pug'),
    styles: [require('./home.component.css')],
    providers: [TournamentsService, TeamsService, PlayersService],
    animations: [
        trigger('categoriesVisibleInvisible', [
            state('in', style({
                transform: 'translate3d(0, 0, 0)'
            })),
            state('out', style({
                transform: 'translate3d(-100%, 0, 0)'
            })),
            state('up', style({
                transform: 'translate3d(0, -100%, 0)'
            })),
            transition('in => out', animate('100ms ease-in-out')),
            transition('out => in', animate('100ms ease-in-out')),
            transition('in => up', animate('300ms ease-in-out')),
            transition('up => in', animate('300ms ease-in-out'))
        ]),
    ]
})
export class HomeComponent implements OnInit {
    errorMessage: string;
    tournaments: Tournaments[];
    teams: Teams[];
    teamName: string;
    players: Players[];
    hideTournamentsDropdown: boolean = true;
    hideClubsDropdown: boolean = true;
    hidePlayersDropdown: boolean = true;
    hidePlayersList: boolean = true;
    currentTournamentIndex: number = null;
    currentTeamIndex: number = null;
    tournamentClick: boolean = false;
    teamClick: boolean = false;
   
    videoImages = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18]; 

    constructor(private tournamentsService: TournamentsService, private teamsService: TeamsService, private playersService: PlayersService, private animationService: AnimationService) {
        this.animationService = animationService;
    }

    ngOnInit() { this.getTournaments(); this.getTeams() }
    
    
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
    getPlayers(id, teamName) {
        this.players = [];
        this.hidePlayersDropdown = false;
        this.playersService.getPlayers(id)
            .then(
            players => this.players = players,
            error => this.errorMessage = <any>error);
        this.hidePlayersList = false;
        this.teamName = teamName;
    }
    getTeamsByTournamentId(id) {
        this.hidePlayersList = true;
        this.hidePlayersDropdown = true
        this.teamClick = false;
        this.currentTeamIndex = null;
        this.teams = [];
        this.hideClubsDropdown = false;
        this.tournamentsService.getTeamsByTournamentId(id)
            .then(
            teams => this.teams = teams,
            error => this.errorMessage = <any>error);
    }
    selectedItem(index) {
        if (this.tournamentClick == true) {
            this.currentTournamentIndex = index;
            this.tournamentClick = false;
        }
        if (this.teamClick == true) {
            this.currentTeamIndex = index;
            this.teamClick = false;
        }
    }
    onScrollDown() {
        let last = this.videoImages[this.videoImages.length - 1];
        for (let i = 0; i < 8; i++) {
            this.videoImages.push(last + i);
        }
    }
}
