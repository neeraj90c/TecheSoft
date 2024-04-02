// login.component.ts
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ServerService } from '../services/server.service';
import { Router } from '@angular/router';
import { LoginRequest } from '../interface/login.interface';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm = new FormGroup({
    group: new FormControl(''),
    date: new FormControl(''),
    userID: new FormControl(''),
    password: new FormControl(''),
  });

  constructor( private serverService: ServerService,private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.bindResponseDate(); 
  }
  bindResponseDate() {
    // Assuming the API response contains the date in ISO format
    const currentDate = new Date().toISOString().split('T')[0]; // Get current date in ISO format
    this.loginForm.get('date')?.setValue(currentDate); // Set the current date to the date field in the form
  }
  onGroupCodeBlur() {
    const groupCode = this.loginForm.get('group')?.value;
    if (groupCode) {
      let data: { bpCode: string; } = {
        bpCode: groupCode
      };

      this.serverService.getGroupCodeDetails(data).subscribe(
        (response: any) => {
          // Bind response date to the date field
          if (response && response.clDate) {
            this.loginForm.get('date')?.setValue(response.clDate.split('T')[0]);
          }
        },
        (error: any) => {
          console.error('Error fetching group code details:', error);
        }
      );
    }
  }
  
  onSubmit() {
    const formData: LoginRequest = {
      groupCode: this.loginForm.get('group')?.value,
      dateToday: new Date().toISOString(),
      userName: this.loginForm.get('userID')?.value,
      userPWD: this.loginForm.get('password')?.value,
      dbName: 'string' // Set the database name accordingly
    };

    this.serverService.login(formData).subscribe(
      (response: any) => {
        // If login successful, navigate to the next page
        if (response.userName == formData.userName ) {
          this.toastr.success('Login successful'); // Display success toastr
          this.router.navigate(['/layout']); // Adjust the route as needed
        } else {
          this.toastr.error('Please check credentials', 'Login Failed'); // Display error toastr
        }
      },
      (error: any) => {
        console.error('Error in login:', error);
        // Handle errors
      }
    );
  }
 
    
}
