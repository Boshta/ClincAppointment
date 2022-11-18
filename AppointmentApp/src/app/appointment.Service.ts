import { HttpClient } from "@angular/common/http";
import { createInjectableType } from "@angular/compiler";
import { Injectable } from "@angular/core";
import { map, Observable, observable, take, tap } from "rxjs";
import { Appointment } from "./appointment";
import { appointmentModel } from "./appointmentModel";

@Injectable({providedIn:"root"})
export class AppointmentService{

    appointmentApiUrl = "https://localhost:44386/api/Appointment";
aapp: Appointment | undefined;
    constructor(private httpClient: HttpClient){}

    addAppointment(appointmnet: appointmentModel): Observable<Appointment>{
        return this.httpClient.post<Appointment>(this.appointmentApiUrl, appointmnet)
        // .pipe(
        //     tap(data => {
        //         console.log(data);
        //     })
        // )
    }
    
    handle(date: Date)
    {
        console.log(date);
    }
}