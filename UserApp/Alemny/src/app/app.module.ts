import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignInComponent } from './Components/user/sign-in/sign-in.component';
import { SignUpComponent } from './Components/user/sign-up/sign-up.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CreateCourseComponent } from './Components/Course/create-course/create-course.component';
import { SearchCourseResultsComponent } from './Components/search-course-results/search-course-results.component';
import { TeachersCourseComponent } from './Components/Course/teachers-course/teachers-course.component';

import { NavbarComponent } from './Components/navbar/navbar.component';
import { HomeComponent } from './Components/home/home.component';
import { CoursesComponent } from './Components/Course/courses/courses.component';
import { UpdateCourseComponent } from './Components/Course/update-course/update-course.component';
import { ProfileComponent } from './Components/user/profile/profile.component';

@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    SignUpComponent,
    CreateCourseComponent,
    SearchCourseResultsComponent,
    TeachersCourseComponent,
    NavbarComponent,
    HomeComponent,
    CoursesComponent,
    UpdateCourseComponent,
    ProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule, 
     
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
