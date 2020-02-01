import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { UserService } from 'src/shared/user.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { SignInComponent } from './sign-in/sign-in.component';
import { HomeComponent } from './sessions/home.component';
import { AuthGuard } from './auth/auth.guard';
import { AuthInterceptor } from './auth/auth.interceptor';
import { RepertoryComponent } from './repertory/repertory.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { AddPerformanceComponent } from './add-performance/add-performance.component';
import { AddSessionComponent } from './add-session/add-session.component';
import { BuyTicketComponent } from './buy-ticket/buy-ticket.component';
import { ClickColorDirective } from 'src/shared/click-color.directive';
import { MyTicketsComponent } from './my-tickets/my-tickets.component';




@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent,
    SignInComponent,
    HomeComponent,
    RepertoryComponent,
    NavBarComponent,
    AddPerformanceComponent,
    AddSessionComponent,
    BuyTicketComponent,
    ClickColorDirective,
    MyTicketsComponent,


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [UserService,AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
