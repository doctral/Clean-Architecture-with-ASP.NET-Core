import { TranslateLoader } from '@ngx-translate/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppConfigService } from 'src/app/app-config.service';
export class CustomTranslationLoader implements TranslateLoader{
    
    constructor(
        private http: HttpClient,
        private configService: AppConfigService
    ){}

    getTranslation(lang: string): Observable<any>{
        const url = this.configService.translationUrl+lang+'.json';
        return this.http.get(url);
    }
}