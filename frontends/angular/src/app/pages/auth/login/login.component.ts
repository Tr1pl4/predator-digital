import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../../services/user-service/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  formModel = {
    UserName: '',
    Password: ''
  }

  constructor(private service: UserService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      () => {
        localStorage.setItem('name',this.formModel.UserName);
        this.toastr.success('Welcome back ' + this.formModel.UserName + '!', 'Login successful.');
        this.router.navigateByUrl('');
      },
      err => {
        if (err.status == 400 || err.status == 401)
          this.toastr.error('Incorrect username or password.', 'Authentication failed.');
        else if (err.status == 440)
          this.toastr.error('This application does not allow multiple uses of an account at the same time','User: '
           + this.formModel.UserName  +' is already in use.');
        else
          console.log(err);
          this.toastr.error('Server not running','Login failed.');
      }
    );
  }

}
