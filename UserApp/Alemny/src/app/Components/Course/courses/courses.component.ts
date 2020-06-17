import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/Services/course.service';
import { Router } from '@angular/router';
import { ICourse } from 'src/Interfaces/icourse';
import { AuthuserService } from '../../../../Services/auth.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css'],
})
export class CoursesComponent implements OnInit {
  CoursesList: ICourse[];
  CourseCount:number;

  constructor(
    private _CourseService: CourseService,
    private _Router: Router,
    private userService: AuthuserService,
    private modalService :NgbModal ,
  ) {}

  ngOnInit(): void {
    console.log(this.userService.userInfo);
    //this._CourseService.GetAllCourses().subscribe(
      this._CourseService.GetCoursesByUserID(localStorage.getItem('userId')).subscribe(
      res=>{
        this.CoursesList=res;
        this.CourseCount=this.CoursesList.length;
      },
      err=>{console.log(err) ;alert(err)}
    )
  
  }

  DeleteCourse(courseCode) {
    this._CourseService.DeleteCourse(courseCode).subscribe(
      (res) => {
        alert('deleted successfully !');
        this._Router.navigate(['/courses']);
        //alert(res.Id);
      },

      (err) => {
        console.log(err);
      }
    );
  }

  deleteProduct(content, courseCode){

    //this._prodServe.getProduct(pid).subscribe((res)=>{

      this.modalService.open(content ).result.
      then((ok)=> {
        let deletedProd = this.CoursesList.find(prod=>prod.Code == courseCode)
       
        const index = this.CoursesList.indexOf(deletedProd)
  
        this.CoursesList.splice(index,1)

        this._CourseService.DeleteCourse(courseCode).subscribe(
          (res) => {
            alert('deleted successfully !');
            this._Router.navigate(['/courses']);
            //alert(res.Id);
          },
    
          (err) => {
            console.log(err);
          }
        );


        
      
      },
      (cancel)=>
      {
        console.log(cancel)
      }
      )
    
    }
  }
