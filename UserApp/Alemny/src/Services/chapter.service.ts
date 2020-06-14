import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IChapter } from 'src/Interfaces/ichapter';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ChapterService {

  constructor(private httpClient: HttpClient) { }
  createChapter(chapter: IChapter) {
    return this.httpClient.post(`${environment.ApiURl}/Chapters`,chapter);
  }

}
