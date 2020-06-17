import { Component, OnInit } from '@angular/core';
import { IChapter } from 'src/Interfaces/ichapter';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthuserService } from 'src/Services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { CourseService } from 'src/Services/course.service';
import { ICourse } from 'src/Interfaces/icourse';
import { ChapterService } from 'src/Services/chapter.service';

@Component({
  selector: 'app-chapter',
  templateUrl: './chapter.component.html',
  styleUrls: ['./chapter.component.css']
})
export class ChapterComponent implements OnInit {
  ChaptersList:IChapter[];
  chapter: IChapter;
  CourseCode:string;
  course:ICourse;
  ChapterForm: FormGroup;
  constructor(
    private user: AuthuserService,
    private route: Router,
    private FB: FormBuilder,
    private _ActivatedRoute:ActivatedRoute ,
    private _courseSer : CourseService,
    private _chapterSer : ChapterService


  ) {
    this.chapter = {
      ID:0,
      Name: '',
      Description:'',
      CourseCode:this._ActivatedRoute.snapshot.params["CourseCode"]
    };
   }
  
  ngOnInit(): void {
    this.ChapterForm = this.FB.group({
      Name:['', [Validators.required, Validators.minLength(3)]],
      Description: ['', [Validators.required, Validators.minLength(3)]]
    });
    this.CourseCode = this._ActivatedRoute.snapshot.params["CourseCode"];

    this._courseSer.GetCourseByCode(this.CourseCode)
    .subscribe(
     res => {
       this.course = res,
         console.log(res)
       },
       err => console.log(err)
      )
     //this.chapter.CourseCode=this.course.Code;

     this._chapterSer.GetChaptersByCourseCode(this._ActivatedRoute.snapshot.params["CourseCode"]).subscribe(
      res => {
        this.ChaptersList = res,
          console.log(res)
        },
        err => console.log(err)
     );
     
  }

  addChapter(Name:string,Description:string) {
    this._chapterSer.createChapter(this.chapter).subscribe
     (
       succ=>{
        this._chapterSer.GetChaptersByCourseCode(this._ActivatedRoute.snapshot.params["CourseCode"]).subscribe(
          res => {
            this.ChaptersList = res,
              console.log(res)
            },
            err => console.log(err)
         );
       },
       err=>alert(err)
     )
  }

  changeChapterID(chapter:IChapter){
    this._chapterSer.ChapterInfo=chapter;
    this._chapterSer.changeChapter(chapter.ID.toString());
    //  this._chapterSer.currentMessage.subscribe(
    //    response=>
    //   { //this.AllProductsCount =response.toString();
    //    });

  }


  
}

