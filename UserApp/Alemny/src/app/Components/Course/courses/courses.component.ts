import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/Services/course.service';
import { Router } from '@angular/router';
import { ICourse } from 'src/Interfaces/icourse';
import { AuthuserService } from '../../../../Services/auth.service';


@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {
  CoursesList:ICourse[];

  constructor(private _CourseService:CourseService,private _Router:Router,private userService : AuthuserService) { }

  ngOnInit(): void {
    
    //this._CourseService.GetAllCourses().subscribe(
      this._CourseService.GetCoursesByUserID(this.userService.userInfo.Id).subscribe(
      res=>{this.CoursesList=res;},
      err=>{console.log(err) ;alert(err)}
    )

  }
  DeleteCourse(courseCode)
  {
    
    this._CourseService.DeleteCourse(courseCode).subscribe(
      res=>{
        this._Router.navigate(['/courses']) ;
        alert("deleted successfully !");
        //alert(res.Id);
      },

      err=>{console.log(err) ;}
    )
  }

}
