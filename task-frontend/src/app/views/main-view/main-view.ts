import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import { List } from '../../components/list/list';
import { FormCreate } from "../../components/form-create/form-create";




@Component({
  selector: 'app-main-view',
  imports: [MatToolbarModule, MatButtonModule, List, FormCreate],
  templateUrl: './main-view.html',
  styleUrl: './main-view.css',
  standalone: true
})
export class MainView {

}
