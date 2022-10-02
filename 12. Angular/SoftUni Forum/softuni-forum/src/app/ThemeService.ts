import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map, reduce } from 'rxjs/operators'
import { environment } from "src/environments/environment";
import { ApiTheme } from "./shared/interfaces/ApiTheme";
import { Theme } from "./shared/interfaces/theme";

@Injectable()
export class ThemeService {

    constructor(private http: HttpClient) {

    }

    getThemes(): Observable<Theme[]> {
        const rawThemes = this.http.get(`${environment.API}themes`, {
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                'Access-Control-Allow-Origin': 'http://localhost:4200'
            }
        }).pipe(
            map(themes => {
                themes.forEach(element => {
                    
                });

                return themes;
            })

        );
        return themes as Observable<Theme[]>;

    }
}