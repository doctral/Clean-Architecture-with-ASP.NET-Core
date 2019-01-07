import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorHandlingInterceptor } from './core/http-interceptors/error-handling.interceptor';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    CoreModule
  ],
  providers: [
    //{provide: HTTP_INTERCEPTORS, useClass: ErrorHandlingInterceptor, multi:true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
