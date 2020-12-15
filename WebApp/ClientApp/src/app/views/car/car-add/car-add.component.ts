import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { NewCarDto } from "src/app/models/CarDto";
import { CarMake, CarModel } from "src/app/models/CarMake";
import { CarBodyType } from "src/app/models/enums/CarBodyType";
import { CarService } from "src/app/services/car.service";

@Component({
  selector: "app-car-add",
  templateUrl: "./car-add.component.html",
  styleUrls: ["./car-add.component.css"],
})
export class CarAddComponent implements OnInit {
  loading = false;
  carForm: FormGroup;
  submitting = false;
  carMakes: CarMake[];
  selectedCarMake: CarMake;
  selectedCarModel: CarModel;
  model: NewCarDto = {
    make: "",
    model: "",
    engine: "",
    price: "",
    carBodyType: 0,
    numberOfDoors: 5,
    numberOfWheels: 4,
  };
  carBodyTypes = [
    { id: 0, value: "Hatchback" },
    { id: 1, value: "Sedan" },
  ];
  previewImage: any;
  constructor(private router: Router, private carService: CarService) {}

  ngOnInit() {
    this.getCarMakes();
    this.initForm();
    this.onValueChanges();
  }

  getCarMakes() {
    this.loading = true;
    this.carService.getCarMakes().subscribe((res) => {
      this.loading = false;
      this.carMakes = res;
    });
  }

  private initForm() {
    this.carForm = new FormGroup({
      carMake: new FormControl(null, Validators.required),
      carModel: new FormControl(null, Validators.required),
      carBodyType: new FormControl(null, Validators.required),
      carPrice: new FormControl(null, Validators.required),
    });
  }

  onSelectCarMake() {
    let carMake: CarMake = this.carForm.get("carMake").value;
    this.selectedCarMake = carMake;
    this.model.make = carMake.name;
  }

  onSelectCarModel() {
    let carModel: CarModel = this.carForm.get("carModel").value;
    this.selectedCarModel = carModel;
    this.model.model = carModel.name;
    this.model.engine = carModel.engine;
    this.model.numberOfWheels = carModel.numberOfWheels;
  }

  onSelectCarBodyType() {
    let carBodyType: CarBodyType = this.carForm.get("carBodyType").value;
    if (carBodyType === CarBodyType.Sedan) {
      this.model.carBodyType = CarBodyType.Sedan;
      this.model.numberOfDoors = 4;
    } else if (carBodyType === CarBodyType.Hatchback) {
      this.model.carBodyType = CarBodyType.Hatchback;
      this.model.numberOfDoors = 5;
    }
  }

  onChangeCarPrice() {
    let carPrice: string = this.carForm.get("carPrice").value;
    this.model.price = carPrice;
  }

  onValueChanges(): void {
    this.carForm.get("carPrice").valueChanges.subscribe((val) => {
      this.model.price = val;
    });
  }

  onSubmit() {
    this.submitting = true;

    this.carService.addCar(this.model).subscribe(() => {
      this.submitting = false;
      this.router.navigate(["/car"]);
    });
  }

  onSelectFile(event) {
    // called each time file input changes
    if (event.target.files && event.target.files[0]) {
      const file = event.target.files[0];
      this.model.imageUri = file;
      const reader = new FileReader();
      reader.onload = (e) => (this.previewImage = reader.result);
      reader.readAsDataURL(file);
    }
  }
}
