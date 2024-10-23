import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee.model';
import { Pagination } from '../../models/pagination'; // Import the Pagination model if you haven't already

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {
  employees: Employee[] = [];
  employeeForm: FormGroup;
  showAddForm: boolean = false;
  showEditForm: boolean = false;
  currentEmployeeId: number | null = null;

  constructor(private employeeService: EmployeeService, private fb: FormBuilder) {
    this.employeeForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      userName: ['', Validators.required],
      salary:['', Validators.required]

    });
  }

  ngOnInit(): void {
    this.loadEmployees(); // Load employees on component initialization
  }

  loadEmployees() {
    this.employeeService.getEmployees().subscribe({
        next: (response) => {
            console.log('API Response:', response); // Log the entire response
            this.employees =response.data; // Ensure this is an array
            console.log('Employees:', this.employees); // Log the employees array
        },
        error: (err) => {
            console.error('Error fetching employees', err);
        }
    });
}




  addEmployee() {
    this.showAddForm = true;
    this.showEditForm = false;
    this.currentEmployeeId = null;
    this.employeeForm.reset(); // Reset the form for new entry
  }

  deleteEmployee(id: number) {
    this.employeeService.deleteEmployee(id).subscribe(() => {
      this.loadEmployees(); // Refresh the list after deletion
    });
  }

  editEmployee(employee: Employee) {
    this.showEditForm = true;
    this.showAddForm = false;
    this.currentEmployeeId = employee.id;

    // Populate the form with the selected employee data
    this.employeeForm.patchValue({
      firstName: employee.firstName,
      lastName: employee.lastName,
      userName: employee.userName,
      salary : employee.salary
    });
  }

  onSubmit() {
    if (this.showAddForm) {
      this.employeeService.addEmployee(this.employeeForm.value).subscribe(() => {
        this.loadEmployees(); // Refresh the list after adding
        this.cancel();
      });
    } else if (this.showEditForm && this.currentEmployeeId) {
      this.employeeService.updateEmployee(this.currentEmployeeId, this.employeeForm.value).subscribe(() => {
        this.loadEmployees(); // Refresh the list after updating
        this.cancel();
      });
    }
  }

  cancel() {
    this.showAddForm = false;
    this.showEditForm = false;
    this.currentEmployeeId = null;
    this.employeeForm.reset(); // Reset the form
  }
}
