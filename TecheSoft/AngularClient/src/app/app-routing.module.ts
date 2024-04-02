import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { LayoutComponent } from './layout/layout.component';

const routes: Routes = [
  {
    path:'login',component:LoginComponent,title:'Tech-Login'
  },
  {
    path:'',redirectTo:'/login',pathMatch:'full'
  },
  {
    path:'layout',component:LayoutComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
