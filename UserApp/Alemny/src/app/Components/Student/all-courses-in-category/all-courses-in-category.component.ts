import { Component, OnInit } from '@angular/core';
import { ICourse } from 'src/Interfaces/icourse';
import { CourseService } from 'src/Services/course.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-all-courses-in-category',
  templateUrl: './all-courses-in-category.component.html',
  styleUrls: ['./all-courses-in-category.component.css']
})
export class AllCoursesInCategoryComponent implements OnInit {

  CourseList : ICourse[];

  cId : string;

  stageId : number
  

  constructor(private curSer:CourseService,
    private _ActivatedRoute:ActivatedRoute ,) { }

  ngOnInit(): void {

    this.cId =  this._ActivatedRoute.snapshot.params["courseCode"]
    this.stageId = this._ActivatedRoute.snapshot.params["stageId"]

    console.log ('Cousre Code : : ' + this.cId);

     this.curSer.GetCoursesByCodeAndStage(this.cId ,this.stageId ).subscribe(
      (ok) => this.CourseList = ok,
      (err) => console.log(err)
    )

  }

}
