import { Injectable } from '@angular/core';
import { GenericService } from '../GenericService/generic-service';
import { IGenericResponse } from '../../Interfaces/igeneric-response';
import { ITask } from '../../Interfaces/itask';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  constructor(private genericService: GenericService){ 
  }
  public getAll():Promise<IGenericResponse<ITask[]>>{
    return this.genericService.getQuery("tasks/GetAll",1);
  }

  public post(titlee:string):Promise<IGenericResponse<ITask>>{
    let request = {
      title: titlee
    }
    return this.genericService.postBody("tasks/Create",request);
  }

}
