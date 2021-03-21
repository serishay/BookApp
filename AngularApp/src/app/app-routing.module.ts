import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Components/users/login/login.component';
import { RegistrationComponent } from './Components/users/registration/registration.component';
import { UsersComponent } from './Components/users/users.component';
import {DashboardComponent} from './Components/dashboard/dashboard.component'
import { SearchComponent } from './Components/search/search.component';
import { AuthGuard } from 'src/guards/auth.guard';
import { FavouriteComponent } from './Components/favourite/favourite.component';
import { RecommendationComponent } from './Components/recommendation/recommendation.component';

const routes: Routes = [
   {path:'',redirectTo:'dashboard',pathMatch:"full"},
  {path:'dashboard',component:DashboardComponent},
  {path:'search',component:SearchComponent},
  {path:'favourite',component:FavouriteComponent,canActivate:[AuthGuard]},
  {path:'recommendation',component:RecommendationComponent,canActivate:[AuthGuard]},
  {path:'users',component:UsersComponent,
  children:[
    {path:'registration',component:RegistrationComponent},
    {path:'login',component:LoginComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
