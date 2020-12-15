import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CarDto, NewCarDto } from "../models/CarDto";
import { CarMake } from "../models/CarMake";

@Injectable({
  providedIn: "root",
})
export class CarService {
  baseApiUrl = "";
  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseApiUrl = baseUrl + "api/Car";
  }

  getCars(): Observable<CarDto[]> {
    return this.http.get<CarDto[]>(`${this.baseApiUrl}`);
  }

  getCarMakes(): Observable<CarMake[]> {
    return this.http.get<CarMake[]>(`${this.baseApiUrl}/GetCarModels`);
  }

  addCar(newCar: NewCarDto): Observable<CarDto> {
    const formData: FormData = new FormData();
    formData.append("make", newCar.make);
    formData.append("model", newCar.model);
    formData.append("engine", newCar.engine);
    formData.append("price", newCar.price);
    formData.append("numberOfDoors", newCar.numberOfDoors.toString());
    formData.append("numberOfWheels", newCar.numberOfWheels.toString());
    formData.append("price", newCar.price);
    formData.append("image", newCar.imageUri);
    formData.append("carBodyType", newCar.carBodyType.toString());
    return this.http.post<CarDto>(`${this.baseApiUrl}/AddCar`, formData);
  }
}
