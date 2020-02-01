import { Hall } from './Hall.model'
import {Performance} from './performance.model'
import { Ticket } from './ticket.model';

export class Session
{
    Id:number;
    Date:Date;
    HallId:number;
    PerformanceId:number;
    Hall:Hall;
    Performance:Performance;
    Tickets:Ticket[]
}