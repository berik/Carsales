import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { CounterComponent } from "./counter/counter.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { ApiAuthorizationModule } from "src/api-authorization/api-authorization.module";
import { AuthorizeGuard } from "src/api-authorization/authorize.guard";
import { AuthorizeInterceptor } from "src/api-authorization/authorize.interceptor";
import { CarModule } from "./views/car/car.module";
import { CarListComponent } from "./views/car/car-list/car-list.component";
import { CarAddComponent } from "./views/car/car-add/car-add.component";
import { CarEditComponent } from "./views/car/car-edit/car-edit.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    CarModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "counter", component: CounterComponent },
      {
        path: "fetch-data",
        component: FetchDataComponent,
        canActivate: [AuthorizeGuard],
      },
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
        path: "car/:id/edit",
        component: CarEditComponent,
        canActivate: [AuthorizeGuard],
      },
    ]),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
