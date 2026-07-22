import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../services/user-service/user.service';

@Component({
  selector: 'app-nav-menu', 
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isLoggedIn: boolean;
  currentUserName: string | null;

  logoutModel = {
    UserName: '',
  }

  constructor(private service: UserService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.router.events.subscribe(event => {
      this.currentUserName = localStorage.getItem('name');
      this.isLoggedIn = this.currentUserName != null; 
    })
  }

  onLogout() {
    this.logoutModel.UserName = (localStorage.getItem('name') as string),
    this.service.logout(this.logoutModel).subscribe(
      (res: any) => {
        this.toastr.success('','Logout successful.');
        localStorage.removeItem('token');
        localStorage.removeItem('name');
        window.location.reload();
      },
      err => {
          if (err.status == 441)
              this.toastr.error(err,'Logout Failed!')
              this.toastr.error('Server not running','Logout Failed!')
          console.log(err);
      }
    );
  }

}
