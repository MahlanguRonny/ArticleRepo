import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { ArticleService } from 'src/app/services/article.service';

@Component({
  selector: 'app-viewarticles',
  templateUrl: './viewarticles.component.html',
  styleUrls: ['./viewarticles.component.scss']
})
export class ViewarticlesComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

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

  dataSource = new MatTableDataSource();

  ngOnInit(): void {
    this.loadArticles();
  }

  // tslint:disable-next-line: typedef
  loadArticles(): void{
    this.articleService.getAllArticles().subscribe(res => {
      this.dataSource.data = res;
      this.dataSource.paginator = this.paginator;
    });
  }
}
