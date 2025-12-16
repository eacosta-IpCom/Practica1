import { Component, OnInit } from '@angular/core';
import {MatTableModule, MatTableDataSource} from '@angular/material/table';
import { ITask } from '../../Interfaces/itask';
import { TaskService } from '../../Services/TaskService/task-service';

@Component({
  selector: 'app-list',
  imports: [MatTableModule],
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


}
