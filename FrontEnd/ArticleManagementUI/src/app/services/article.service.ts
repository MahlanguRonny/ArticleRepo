import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Article } from '../models/article/article';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  constructor(private http: HttpClient) { }
  baseApiUrl = environment.articleApi;

  getAllArticles(): Observable<any> {
    return this.http.get<any>(`${this.baseApiUrl}/Article/GetAllArticles`);
  }
}
