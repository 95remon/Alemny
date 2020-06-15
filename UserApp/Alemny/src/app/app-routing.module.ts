import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignInComponent } from './Components/user/sign-in/sign-in.component';
import { SignUpComponent } from './Components/user/sign-up/sign-up.component';
import { CreateCourseComponent } from './Components/Course/create-course/create-course.component';
import { SearchCourseResultsComponent } from './Components/search-course-results/search-course-results.component';
import { HomeComponent } from './Components/home/home.component';


const routes: Routes = [
  { path:'signin' , component:SignInComponent },
  { path:'signup' , component:SignUpComponent },
  {path : 'createcourse' , component : CreateCourseComponent},
  { path:'courses/:StgID/:Sem/:Subject',component:SearchCourseResultsComponent},
  { path:'home',component:HomeComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
