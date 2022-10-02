import { Component, Input, OnInit } from '@angular/core';
import { Theme } from 'src/app/shared/interfaces/theme';

@Component({
  selector: 'app-theme-list',
  templateUrl: './theme-list.component.html',
  styleUrls: ['./theme-list.component.scss']
})
export class ThemeListComponent implements OnInit {

  @Input('themes') themes!: Theme[];
  
  constructor() { }

  ngOnInit(): void {
  }

}
