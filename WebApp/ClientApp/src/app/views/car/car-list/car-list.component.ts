import { Component, OnInit } from "@angular/core";
import { CarDto } from "src/app/models/CarDto";
import { CarBodyType } from "src/app/models/enums/CarBodyType";
import { CarService } from "src/app/services/car.service";

@Component({
  selector: "app-car-list",
  templateUrl: "./car-list.component.html",
  styleUrls: ["./car-list.component.css"],
})
export class CarListComponent implements OnInit {
  loading = false;
  cars: CarDto[];
  constructor(private carService: CarService) {}
  ngOnInit() {
    this.getCars();
  }

  getCars() {
    this.loading = true;
    this.carService.getCars().subscribe((result) => {
      this.loading = false;
      this.cars = result;
    });
  }

  getBodyType(bodyType: CarBodyType) {
    if (bodyType === CarBodyType.Hatchback) {
      return "Hatchback";
    } else if (bodyType === CarBodyType.Sedan) {
      return "Sedan";
    }
  }
}
