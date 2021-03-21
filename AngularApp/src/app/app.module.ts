import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {ReactiveFormsModule,FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UsersComponent } from './Components/users/users.component';
import { RegistrationComponent } from './Components/users/registration/registration.component';
import { UserService } from './Services/user.service';
import { LoginComponent } from './Components/users/login/login.component';
import { HeaderComponent } from './Components/header/header.component';
import { FooterComponent } from './Components/footer/footer.component';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { SearchService } from './Services/search.service';
import { SearchComponent } from './Components/search/search.component';
import { FavouriteComponent } from './Components/favourite/favourite.component';
import { RecommendationComponent } from './Components/recommendation/recommendation.component';

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    RegistrationComponent,
    LoginComponent,
    HeaderComponent,
    FooterComponent,
    DashboardComponent,
    SearchComponent,
    FavouriteComponent,
    RecommendationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [UserService,SearchService,  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
