import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialExampleComponent } from './material-example/material-example.component';
import { MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { MatIcon, MatIconModule } from '@angular/material/icon';
import {MatTableModule} from '@angular/material/table';
import { TableComponent } from './table/table.component';


@NgModule({
  declarations: [
    
    
  
    // TableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialExampleComponent,
    AppComponent,
   
   
  ],
  providers: [],
  // bootstrap: [AppComponent]
})
export class AppModule { }
