import { Component, Input, OnInit } from "@angular/core";
import { CarDto } from "src/app/models/CarDto";

@Component({
  selector: "app-car-card",
  templateUrl: "./car-card.component.html",
  styleUrls: ["./car-card.component.css"],
})
export class CarCardComponent implements OnInit {
  @Input() car: CarDto;
  constructor() {}

  ngOnInit() {}
}
