import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { ArticleService } from 'src/app/services/article.service';
import { MatGridList } from '@angular/material/grid-list';
import { Tile } from 'src/app/utils/utils';

@Component({
  selector: 'app-viewarticles',
  templateUrl: './viewarticles.component.html',
  styleUrls: ['./viewarticles.component.scss']
})
export class ViewarticlesComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  public articles: Array<Tile> = [];
  public initialData: Array<Tile> = [];

  constructor(
    private readonly router: Router,
    private readonly articleService: ArticleService,
  ) { }

  displayedColumns = [
    'Id',
    'Title',
    'Content',
    'UserId',
  ];

  page = 0;
  size = 5;


  ngOnInit(): void {
    this.loadArticles({ pageIndex: this.page, pageSize: this.size });
  }

  // tslint:disable-next-line: typedef
  loadArticles(obj: any): void {
    let index = 0;
    const startingIndex = obj.pageIndex * obj.pageSize;
    const endingIndex = startingIndex + obj.pageSize;

    this.articleService.getAllArticles().subscribe(res => {
      const items = res;

      for (const item of items) {
        this.initialData.push(
          {
            border: '3px double skyblue',
            cols: 2,
            title: item.title,
            rows: 1,
            content: item.content
          });
      }

      this.articles = this.initialData.filter(() => {
        index++;
        return (index > startingIndex && index <= endingIndex) ? true : false;
      });
    });
  }
}
