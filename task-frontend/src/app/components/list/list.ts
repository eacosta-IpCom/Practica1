import { Component, OnInit } from '@angular/core';
import {MatTableModule, MatTableDataSource} from '@angular/material/table';
import { ITask } from '../../Interfaces/itask';
import { TaskService } from '../../Services/TaskService/task-service';
import { FormUpdate } from '../form-update/form-update';
import { FormCreate } from '../form-create/form-create';

@Component({
  selector: 'app-list',
  imports: [MatTableModule,FormUpdate, FormCreate],
  templateUrl: './list.html',
  styleUrl: './list.css',
  standalone: true
})
export class List implements OnInit {


  dataSource = new MatTableDataSource<ITask>();

  displayedColumns: string[] = ['NO.', 'Título', 'Completada'];

  constructor(private taskService: TaskService)
  {
  }
  ngOnInit(): void {
    let result = this.taskService.getAll().then(data=>{
      this.dataSource.data=data.payload;
    });
  }
public async loadTasks() {
    try {
      const data = await this.taskService.getAll();
      this.dataSource.data = data.payload;
      console.log('Datos cargados con éxito');
    } catch (error) {
      console.error('Error al cargar la tabla', error);
    }
  }


}
