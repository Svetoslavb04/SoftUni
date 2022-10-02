import { Component, Input, OnInit } from '@angular/core';
import { Theme } from 'src/app/shared/interfaces/theme';

@Component({
  selector: 'app-theme-list-item',
  templateUrl: './theme-list-item.component.html',
  styleUrls: ['./theme-list-item.component.scss']
})
export class ThemeListItemComponent implements OnInit {

  @Input('theme') theme!: Theme;
  
  constructor() { }

  ngOnInit(): void {
  }

}
