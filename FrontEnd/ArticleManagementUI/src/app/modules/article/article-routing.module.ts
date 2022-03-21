import { ViewarticlesComponent } from './components/viewarticles/viewarticles.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewArticleComponent } from './components/new-article/new-article.component';

const routes: Routes = [
  { path: 'viewarticles', component: ViewarticlesComponent },
  { path: 'new-article', component: NewArticleComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ArticleRoutingModule { }
