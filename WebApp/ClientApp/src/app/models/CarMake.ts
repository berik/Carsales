import { VehicleType } from "./enums/VehicleType";

export interface CarMake {
  name: string;
  models: CarModel[];
}

export interface CarModel {
  name: string;
  vehicleType: VehicleType;
  numberOfWheels: number;
  engine: string;
}
