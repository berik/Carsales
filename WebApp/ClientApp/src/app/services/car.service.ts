import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CarDto } from "../models/CarDto";

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
}
