import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PageNotFoundComponent } from './supporting-components/page-not-found/page-not-found.component';
import { UnauthorizedComponent } from './supporting-components/unauthorized/unauthorized.component';
import { ErrorComponent } from './supporting-components/error/error.component';
import { HTTP_INTERCEPTORS, HttpClientModule, HttpClient } from '@angular/common/http';
import { ErrorHandlingInterceptor } from './http-interceptors/error-handling.interceptor';
import { TranslateModule, TranslateLoader, MissingTranslationHandler } from '@ngx-translate/core';
import { CustomMissingTranslationHandler, CustomTranslationLoader } from './translation';
import { CoreRoutingModule } from './core-routing.module';
import { AppConfigService } from '../app-config.service';
import { CultureCodeService } from './translation/culture-code.service';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    CoreRoutingModule,
    TranslateModule.forChild({
      loader:{provide: TranslateLoader, useClass: CustomTranslationLoader, deps:[HttpClient, AppConfigService]},
      missingTranslationHandler:{provide: MissingTranslationHandler, useClass: CustomMissingTranslationHandler},
      useDefaultLang:false
    }),
  ],
  providers:[
    CultureCodeService
  ],
  declarations: [PageNotFoundComponent, UnauthorizedComponent, ErrorComponent]
})
export class CoreModule { }
