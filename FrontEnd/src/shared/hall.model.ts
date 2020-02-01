import { Seat } from './seat.mode';

export class Hall
{
    Id:number;
    Name:string;
    NumberOfSeats:number;
    NumberOfRows:number;
    NumberOfSeatsInRow:number;
    Seats:Seat[]
}