import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AppConfigService {

  constructor() { }

  public get apiUrl(): string {
    return environment.apiUrl;
  }

  public get translationUrl(): string{
    return environment.localizationUrl;
  }
}
