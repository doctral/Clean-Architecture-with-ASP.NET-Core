import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class CultureCodeService {

  private lang = 'en-US';
  constructor(private translateService: TranslateService) { 
    this.translateService.setDefaultLang(this.lang);
  }

  setDefaultLocalizationResource(){
    this.setDefaultLang();
    this.translateService.use(this.lang);
  }

  private setDefaultLang(){
    this.lang = this.translateService.getBrowserCultureLang();
    if(this.lang == null){
      this.lang = 'en-US';
    } 
  }

  private setLocalizationResource(lang: string){
    this.lang = lang;
    this.translateService.use(this.lang);
  }
}
