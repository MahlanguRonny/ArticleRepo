import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ArticleRoutingModule } from './article-routing.module';
import { ViewarticlesComponent } from './components/viewarticles/viewarticles.component';
import { NewArticleComponent } from './components/new-article/new-article.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    ViewarticlesComponent,
    NewArticleComponent,
  ],
  imports: [
    CommonModule,
    ArticleRoutingModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    HttpClientModule
  ]
})
export class ArticleModule { }
