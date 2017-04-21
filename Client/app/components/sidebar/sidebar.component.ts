import { Tournaments } from '../../tournaments/tournaments';
import { TournamentsService } from '../../tournaments/tournaments.service';
import { Teams } from '../../teams/teams';
import { TeamsService } from '../../teams/teams.service';
import { Players } from '../../players/players';
import { PlayersService } from '../../players/players.service';
import { AnimationService } from '../../services/animation.service';
import { Component, OnInit, trigger, state, style, transition, animate } from '@angular/core';
import { ChangeColorsService } from '../../services/change-colors.service';

@Component({
    selector: 'sidebar',
    template: require('./sidebar.component.pug'),
    styles: [String(require('./sidebar.component.scss'))],
    providers: [TournamentsService, TeamsService, PlayersService],
    animations: [
        trigger('animationVisibleInvisible', [
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
            transition('in => up', animate('400ms ease-in-out')),
            transition('up => in', animate('400ms ease-in-out'))
        ]),
    ]
})
export class SideBarComponent implements OnInit {
    errorMessage: string;
    tournaments: Tournaments[];
    teams: Teams[];
    public teamName: string;
    players: Players[];
    hideTournamentsDropdown: boolean = true;
    hideClubsDropdown: boolean = true;
    hidePlayersDropdown: boolean = true;
    hidePlayersList: boolean = true;
    currentTournamentIndex: any = null;
    currentTeamIndex: any = null;
    tournamentClick: boolean = false;
    teamClick: boolean = false;
    teamNameForColors: string = '';
    stylesheetPath: string;
    constructor(private tournamentsService: TournamentsService, private teamsService: TeamsService, private playersService: PlayersService, private animationService: AnimationService, private changeColorsService: ChangeColorsService) {
        this.animationService = animationService; this.changeColorsService = changeColorsService; 
    }

    ngOnInit() { this.getTournaments(); this.getTeams(); }


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
    getPlayers(id: number, teamName: string) {
        this.players = [];
        this.hidePlayersDropdown = false;
        this.playersService.getPlayers(id)
            .then(
            players => this.players = players,
            error => this.errorMessage = <any>error);
        this.hidePlayersList = false;
        this.teamName = teamName;
        //this.teamNameForColors = teamName;
        this.changeColorsService.setValue(this.teamName);
        this.changeColorsService.changeTheme();

    }
    getTeamsByTournamentId(id: number) {
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
    selectedItem(index: number) {
        if (this.tournamentClick == true) {
            this.currentTournamentIndex = index;
            this.tournamentClick = false;
        }
        if (this.teamClick == true) {
            this.currentTeamIndex = index;
            this.teamClick = false;
            
        }
    }

}