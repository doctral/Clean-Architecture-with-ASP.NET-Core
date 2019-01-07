import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, throwError, of } from 'rxjs';
import { tap } from 'rxjs/operators';

export class ErrorHandlingInterceptor implements HttpInterceptor {
    
    constructor(
        private router: Router
    ) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req)
                .pipe(
                    tap(
                        ()=> {},
                        (error: HttpErrorResponse) =>{
                            const messages = error.error;
                            console.error(messages);
                            switch(error.status){
                                case 400:
                                case 401:
                                case 403:
                                    this.router.navigate(['/unauthorized']);
                                    return of({});
                                default:
                                this.router.navigate(['/error']);
                                    return of({});    
                            }
                        } 
                    )
                );
    }
}