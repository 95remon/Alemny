import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignInComponent } from './Components/user/sign-in/sign-in.component';
import { SignUpComponent } from './Components/user/sign-up/sign-up.component';
import { CreateCourseComponent } from './Components/Course/create-course/create-course.component';
import { SearchCourseResultsComponent } from './Components/search-course-results/search-course-results.component';
import { CoursesComponent } from './Components/Course/courses/courses.component';
import { UpdateCourseComponent } from './Components/Course/update-course/update-course.component';


const routes: Routes = [
  {path:'UpdateCourse/:CourseCode',component:UpdateCourseComponent},
  { path:'signin' , component:SignInComponent },
  { path:'signup1' , component:SignUpComponent },
  {path : 'createcourse' , component : CreateCourseComponent},
  {path:'courses/:StgID/:Sem/:Subject',component:SearchCourseResultsComponent},
  {path :'courses' , component :CoursesComponent }
  
  

];   

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
