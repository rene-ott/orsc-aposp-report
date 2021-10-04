import { Injectable } from '@angular/core';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor
} from '@angular/common/http';
import { AuthService } from './services/auth.service';
import { Observable } from 'rxjs';
import { ApiPaths } from './ApiPaths';
@Injectable()
export class ApiKeyInterceptor implements HttpInterceptor {
    constructor(public authService: AuthService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        request = this.setApiKeyHeader(request);
        return next.handle(request);
    }

    private setApiKeyHeader(request: HttpRequest<any>) {
        if (request.url.indexOf(ApiPaths.Authentication) === -1) {
            request = request.clone({
                setHeaders: {
                    "X-API-KEY": this.authService.getApiKey()
                }
            });

            return request;
        }

        return request;
    }
}