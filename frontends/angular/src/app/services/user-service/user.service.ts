import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURL = `${environment.apiBaseUrl}/api/Account/`;

  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(3)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords })

  });

  comparePasswords(fb: FormGroup) {
    let confirmPswrdCtrl = fb.get('ConfirmPassword');
    if (confirmPswrdCtrl!.errors == null || 'passwordMismatch' in confirmPswrdCtrl!.errors) {
      if (fb.get('Password')!.value != confirmPswrdCtrl!.value)
        confirmPswrdCtrl!.setErrors({ passwordMismatch: true });
      else
        confirmPswrdCtrl!.setErrors(null);
    }
  }

  register() {
    var body = {
      UserName: this.formModel.value.UserName,
      Password: this.formModel.value.Passwords.Password
    };
    return this.http.post(this.BaseURL + 'Register', body);
  }

  login(formData) {
    return this.http.post(this.BaseURL + 'Login', formData);
  }
  logout(name) {
    return this.http.post(this.BaseURL + 'Logout',name);
  }
}
