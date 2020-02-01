import { Observable, throwError } from 'rxjs'
import {Injectable} from '@angular/core';
import {HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse} from '@angular/common/http'
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';

@Injectable()
export class AuthInterceptor implements HttpInterceptor
{
    token: string;
    constructor(private nav:Router)
    {
    }
    
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        const params = req.clone(
            {
                setHeaders: {
                    Authorization: 'Bearer ' + localStorage.getItem('userToken')
                },
                url: '' + req.url
            }
        )
        return next.handle(params).pipe(
            catchError((error: HttpErrorResponse) => {
                if (error.status == 401) {
                    localStorage.removeItem('userToken');
                    this.nav.navigate(['/login']);
                }
                return throwError(error);
            })
        );
   
}
}