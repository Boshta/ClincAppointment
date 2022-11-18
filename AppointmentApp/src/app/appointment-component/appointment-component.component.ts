import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { map, tap } from 'rxjs';
import { Appointment } from '../appointment';
import { AppointmentService } from '../appointment.Service';
import { appointmentModel } from '../appointmentModel';

@Component({
  selector: 'app-appointment-component',
  templateUrl: './appointment-component.component.html',
  styleUrls: ['./appointment-component.component.css']
})
export class AppointmentComponentComponent implements OnInit {

  appointmnetForm: FormGroup;
  submitted: boolean;
  appo: Appointment | undefined ;
  appointmentDate: Date | undefined;
  constructor(private appointmentService: AppointmentService) {
    this.appointmnetForm = new FormGroup({
      'patientName': new FormControl(null, [Validators.required]),
      'phone': new FormControl(null, [Validators.required]),
      'note': new FormControl(null, [Validators.required]),
    })
    this.submitted = false;
   }

  ngOnInit(): void {
    
  }

  onSubmit(){
    console.log(this.appointmnetForm.value);
    console.log( this.appointmnetForm.controls['patientName'].value);
    
    const appointment : appointmentModel = {
      PatientName : this.appointmnetForm.controls['patientName'].value,
      Note : this.appointmnetForm.controls['note'].value,
      Phone : this.appointmnetForm.controls['phone'].value
    }

    this.appointmentService.addAppointment(appointment).subscribe({
      next: appoin => {
        this.appo = appoin;
        console.log(this.appo)
        this.submitted = true
        this.appointmentDate = appoin.AppointmentDate
      }
    })
  }

}
