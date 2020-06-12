import { Component, OnInit } from '@angular/core';
import { ICourse } from 'src/Interfaces/icourse';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CourseService } from 'src/Services/course.service';

@Component({
  selector: 'app-create-course',
  templateUrl: './create-course.component.html',
  styleUrls: ['./create-course.component.css']
})
export class CreateCourseComponent implements OnInit {

  course: ICourse;


  CreateCourse: FormGroup;

  constructor(  private courseSer : CourseService
    ,private FB: FormBuilder) { 
    this.course = {
      Code:'',
      Name: '',
      Description:'',
      MaxDegree: 0,
      MinDegree: 0,
      StageID : '',
      Term : 1

    };
  }

  ngOnInit(): void {
    this.CreateCourse = this.FB.group({
      Code: ['', [Validators.required, Validators.minLength(3)]],
      Name: ['', [Validators.required, Validators.minLength(3)]],
      Desc: ['', [Validators.required, Validators.minLength(3)]],
      MaxDegree: ['', [Validators.required]],
      MinDegree: ['', [Validators.required]],
      Term: ['', [Validators.required, Validators.minLength(6)]],
      StageID: ['', [Validators.required, Validators.minLength(3)]],
     
    });
  }

  createCourse() {
    this.courseSer.createCourse(this.course).subscribe(
      (data: any) => {
        console.log(data);
      },
      (err) => console.log(err)
    );
  }

}
