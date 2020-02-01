import { Seat } from './seat.mode';
import { Session } from 'protractor';

export class Ticket
{
    Id:number;
    SessionId:number;
    Session:Session
    Status:string;
    Price:number;
    UserProfileId:string;
    Seat:Seat;
}