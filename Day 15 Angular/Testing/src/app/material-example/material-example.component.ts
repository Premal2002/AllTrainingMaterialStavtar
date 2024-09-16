import { Component,ChangeDetectionStrategy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSlideToggleModule } from "@angular/material/slide-toggle";
import {MatCardModule} from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';


@Component({
  selector: 'app-material-example',
  standalone: true,
  imports: [CommonModule,MatSlideToggleModule,MatCardModule,MatFormFieldModule, MatInputModule, MatButtonModule, MatIconModule],
  templateUrl: './material-example.component.html',
  styleUrls: ['./material-example.component.css']
})
export class MaterialExampleComponent {
  hide = true;
}
