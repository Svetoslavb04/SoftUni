import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { Theme } from './shared/interfaces/theme';
import { ThemeService } from './ThemeService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'softuni-forum';
  themes: Theme[] = [];

  constructor(private themeService: ThemeService) {

  }

  ngOnInit() {
    this.themeService.getThemes().subscribe(themes => this.themes = themes);
  }
}
