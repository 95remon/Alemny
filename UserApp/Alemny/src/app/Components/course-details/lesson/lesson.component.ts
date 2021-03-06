import { Component, OnInit, Input } from '@angular/core';
import { AuthuserService } from 'src/Services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ChapterService } from 'src/Services/chapter.service';
import { IChapter } from 'src/Interfaces/ichapter';
import { LessonService } from 'src/Services/lesson.service';
import { ILesson } from 'src/Interfaces/ilesson';

@Component({
  selector: 'app-lesson',
  templateUrl: './lesson.component.html',
  styleUrls: ['./lesson.component.css']
})

export class LessonComponent implements OnInit {
  
  LessonsList : ILesson[];
  lesson: ILesson;
  ChapterID:number;
  Chapter:IChapter;
  LessonForm: FormGroup;
  constructor(
    private user: AuthuserService,
    private route: Router,
    private FB: FormBuilder,
    private _ActivatedRoute:ActivatedRoute ,
    public _chapterSer : ChapterService,
    public _lessonSer : LessonService
  ) { 
    this.lesson = {
      ID:0,
      Name: '',
      Description:'',
      ChapterID:this._chapterSer.ChapterInfo.ID
    };
  }
  ngOnInit(): void {
    this.LessonForm = this.FB.group({
      Name:['', [Validators.required, Validators.minLength(3)]],
      Description: ['', [Validators.required, Validators.minLength(3)]]
    });
    
    // alert(this._chapterSer.ChapterInfo.ID);
    
    // this._lessonSer.GetLessonsByChapter(this._chapterSer.ChapterInfo.ID).subscribe
    // (
    //   data=>{
    //     console.log(data);
    //     this.LessonsList=data;
    //   }
    // )
    this._chapterSer.currentMessage.subscribe(
    response=>
    { 
      //this.AllProductsCount =response.toString();
      this._lessonSer.GetLessonsByChapter(parseInt(response)).subscribe
    (
      data=>{
        console.log(data);
        this.LessonsList=data;
        this.lesson.ChapterID=this._chapterSer.ChapterInfo.ID;
      }
    );
    });

  }

  // ViewThisChapter(chapterID:number){
  //   this._lessonSer.GetLessonsByChapter(chapterID).subscribe
  //   (
  //     data=>{
  //       console.log(data);
  //       this.LessonsList=data;
  //     }
  //   );
  // }

  addLesson(Name:string,Description:string) {
    this._lessonSer.createLesson(this.lesson).subscribe
     (
       succ=>{
        this._lessonSer.GetLessonsByChapter(this.lesson.ChapterID).subscribe(
          res => {
            this.LessonsList = res,
              console.log(res)
            },
            err => console.log(err)
         );
       },
       err=>alert(err)
     )
  }

  

}
