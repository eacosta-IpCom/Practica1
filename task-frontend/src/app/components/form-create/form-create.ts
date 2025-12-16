import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import { TaskService } from '../../Services/TaskService/task-service';

@Component({
  selector: 'app-form-create',
  imports: [MatFormFieldModule, MatInputModule, FormsModule, ReactiveFormsModule, MatButtonModule],
  templateUrl: './form-create.html',
  styleUrl: './form-create.css',
  standalone: true
})
export class FormCreate {

    public formCount: FormGroup = new FormGroup({
    title: new FormControl('',[Validators.required,Validators.minLength(4)])
  });
  constructor (private taskService:TaskService ){}

  public OnClicCreate(){
    
    let title = this.formCount.controls["title"].value; //Se extrea el valor
    this.taskService.post(title);  
  }


}
