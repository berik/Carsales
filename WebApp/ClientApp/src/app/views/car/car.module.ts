import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { CarRoutingModule } from "./car-routing.module";
import { CarListComponent } from "./car-list/car-list.component";
import { CarAddComponent } from "./car-add/car-add.component";
import { CarEditComponent } from "./car-edit/car-edit.component";
import { ReactiveFormsModule } from "@angular/forms";

@NgModule({
  declarations: [CarListComponent, CarAddComponent, CarEditComponent],
  imports: [ReactiveFormsModule, CommonModule, CarRoutingModule],
})
export class CarModule {}
