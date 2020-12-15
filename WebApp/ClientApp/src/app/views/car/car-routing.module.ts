import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AuthorizeGuard } from "src/api-authorization/authorize.guard";
import { CarAddComponent } from "./car-add/car-add.component";
import { CarDetailComponent } from "./car-detail/car-detail.component";
import { CarListComponent } from "./car-list/car-list.component";

const routes: Routes = [
  {
    path: "car",
    component: CarListComponent,
    canActivate: [AuthorizeGuard],
  },
  {
    path: "car/new-car",
    component: CarAddComponent,
    canActivate: [AuthorizeGuard],
  },
  {
    path: "car/:id",
    component: CarDetailComponent,
    canActivate: [AuthorizeGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CarRoutingModule {}
