import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ArticleDto } from '../models/article/article';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  constructor(private http: HttpClient) { }
  baseApiUrl = environment.articleApi;

  public getAllArticles(): Observable<any> {
    return this.http.get<any>(`${this.baseApiUrl}/Article/GetAllArticles`);
  }

  public addNewArticle(articleDto: ArticleDto): Observable<any> {
    return this.http.post<any>(`${this.baseApiUrl}/Article/PublishArticle`, articleDto);
  }
}
