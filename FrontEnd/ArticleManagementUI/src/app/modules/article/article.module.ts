import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ArticleRoutingModule } from './article-routing.module';
import { ViewarticlesComponent } from './components/viewarticles/viewarticles.component';
import { NewArticleComponent } from './components/new-article/new-article.component';



@NgModule({
  declarations: [
    ViewarticlesComponent,
    NewArticleComponent,
  ],
  imports: [
    CommonModule,
    ArticleRoutingModule
  ]
})
export class ArticleModule { }
