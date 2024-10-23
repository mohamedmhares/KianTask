import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { EmployeeComponent } from './components/employee/employee.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HomeComponent } from './components/home/home.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';


@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    NavBarComponent,
    HomeComponent
    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CarouselModule.forRoot(),


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
