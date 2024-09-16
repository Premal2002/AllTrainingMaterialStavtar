import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-standalone-comp',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './standalone-comp.component.html',
  styleUrls: ['./standalone-comp.component.css']
})
export class StandaloneCompComponent {

}
