import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { CarRoutingModule } from "./car-routing.module";
import { CarListComponent } from "./car-list/car-list.component";
import { CarAddComponent } from "./car-add/car-add.component";
import { ReactiveFormsModule } from "@angular/forms";
import { CarCardComponent } from "./car-card/car-card.component";
import { CarDetailComponent } from './car-detail/car-detail.component';

@NgModule({
  declarations: [CarListComponent, CarAddComponent, CarCardComponent, CarDetailComponent],
  imports: [ReactiveFormsModule, CommonModule, CarRoutingModule],
})
export class CarModule {}
