import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignInComponent } from './Components/user/sign-in/sign-in.component';
import { SignUpComponent } from './Components/user/sign-up/sign-up.component';
import { CreateCourseComponent } from './Components/Course/create-course/create-course.component';
import { SearchCourseResultsComponent } from './Components/search-course-results/search-course-results.component';
import { CourseDetailsComponent } from './Components/course-details/course-details.component';
import { HomeComponent } from './Components/home/home.component';
import { CoursesComponent } from './Components/Course/courses/courses.component';
import { UpdateCourseComponent } from './Components/Course/update-course/update-course.component';
import { ProfileComponent } from './Components/user/profile/profile.component';


const routes: Routes = [
  {path:'UpdateCourse/:CourseCode',component:UpdateCourseComponent},
  { path:'signin' , component:SignInComponent },
  { path:'coursedetails/:CourseCode' , component:CourseDetailsComponent },
  {path:'courses',component:CoursesComponent},
  { path:'signup' , component:SignUpComponent },
  { path:'profile' , component:ProfileComponent },

  {path : 'createcourse' , component : CreateCourseComponent},
  { path:'courses/:StgID/:Sem/:Subject',component:SearchCourseResultsComponent},
  { path:'home',component:HomeComponent},
  
  
  


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
