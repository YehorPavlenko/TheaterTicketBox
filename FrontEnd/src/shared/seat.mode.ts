import { Hall } from './Hall.model';

export class Seat
{
    Id:number;
    HallId:number;
    Hall:Hall;
    RowNumber:number;
    SeatNumber:number;
}