import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';  // Importing the map operator
import { Employee } from '../models/employee.model';
import { Pagination } from '../models/pagination';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl = 'https://localhost:7050/api/Employee'; // Base URL for your API

  constructor(private http: HttpClient) {}

  getEmployees(): Observable<any> { // Change to any if you want to handle response directly
    return this.http.get<any>(`${this.apiUrl}/all`);
}
  // Fetch a single employee by ID
  getEmployeeById(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.apiUrl}/${id}`);
  }

  // Add a new employee
  addEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(this.apiUrl, employee);
  }

  // Update an existing employee
  updateEmployee(id: number, employee: Employee): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, employee);
  }

  // Delete an employee by ID
  deleteEmployee(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
