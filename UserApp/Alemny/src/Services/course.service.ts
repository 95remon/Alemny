import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ICourse } from 'src/Interfaces/icourse';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CourseService {
  constructor(private httpClient: HttpClient) {}

  createCourse(course: ICourse) {
    return this.httpClient.post(`${environment.ApiURl}/Courses`, course);
  }
  searchCourse(StgID : number,Sem : number, Subject : string){
    return this.httpClient.get(`${environment.ApiURl}/Courses/${StgID}/${Sem}/${Subject}`);
  }
}
