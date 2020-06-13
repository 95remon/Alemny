import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ILesson } from 'src/Interfaces/ilesson';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LessonService {

  constructor(private httpClient: HttpClient) { }
  createLesson(lesson: ILesson) {
    return this.httpClient.post(`${environment.ApiURl}/Lessons`,lesson);
  }

}
