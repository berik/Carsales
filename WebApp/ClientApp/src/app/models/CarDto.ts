import { CarBodyType } from "./enums/CarBodyType";
import { VehicleType } from "./enums/VehicleType";

export interface CarDto {
  id: string;
  created: string;
  make: string;
  model: string;
  engine: string;
  numberOfDoors: number;
  numberOfWheels: number;
  vehicleType: VehicleType;
  carBodyType: CarBodyType;
}

export interface NewCarDto {
  make: string;
  model: string;
  engine: string;
  numberOfDoors: number;
  numberOfWheels: number;
  carBodyType: CarBodyType;
}
