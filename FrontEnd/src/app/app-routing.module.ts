import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignUpComponent } from './sign-up/sign-up.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { HomeComponent } from './sessions/home.component';
import { AuthGuard } from './auth/auth.guard';
import { RepertoryComponent } from './repertory/repertory.component';
import { AddPerformanceComponent } from './add-performance/add-performance.component';
import { AddSessionComponent } from './add-session/add-session.component';
import { BuyTicketComponent } from './buy-ticket/buy-ticket.component';
import { MyTicketsComponent } from './my-tickets/my-tickets.component';




const routes: Routes = [
  {path:'',redirectTo:'login',pathMatch:'full'},
  {path:'registration',component:SignUpComponent},
  {path:'login',component:SignInComponent},
  {path:'repertory',component:RepertoryComponent,canActivate:[AuthGuard]},
  {path:'sessions',component:HomeComponent,canActivate:[AuthGuard]},
  {path:'sessions/:id',component:BuyTicketComponent,canActivate:[AuthGuard]},
  {path:'add-perfromance',component:AddPerformanceComponent,canActivate:[AuthGuard]},
  {path:'add-session',component:AddSessionComponent,canActivate:[AuthGuard]},
  {path:'tickets',component:MyTicketsComponent,canActivate:[AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
