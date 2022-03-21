import { Router } from '@angular/router';
import { ArticleDto } from './../../../../models/article/article';
import { UserDto } from './../../../../models/users/user';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ArticleService } from 'src/app/services/article.service';
import { finalize } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-new-article',
  templateUrl: './new-article.component.html',
  styleUrls: ['./new-article.component.scss']
})
export class NewArticleComponent implements OnInit {
  public newArticleForm: FormGroup;

  constructor(
    public formBuilder: FormBuilder,
    private readonly articleService: ArticleService,
    private readonly router: Router,
    private readonly toast: ToastrService
  ) { }

  public ngOnInit(): void {

    this.newArticleForm = this.formBuilder.group({
      PublisherName: ['', Validators.required],
      EmailAddress: ['', Validators.required, Validators.email],
      ArticleTitle: ['', Validators.required],
      ArticleContent: ['', Validators.required, Validators.minLength(150)],
    });
  }

  onSubmit(): void {
    console.log(JSON.stringify(this.newArticleForm.value.PublisherName));
    const userDto: UserDto = {
      id: 0,
      Email: this.newArticleForm.value.EmailAddress,
      Name: this.newArticleForm.value.PublisherName
    };

    const articleDto: ArticleDto = {
      id: 0,
      content: this.newArticleForm.value.ArticleContent,
      title: this.newArticleForm.value.ArticleTitle,
      userDto
    };

    console.log(this.newArticleForm.value.ArticleContent);
    this.articleService.addNewArticle(articleDto).pipe(
      finalize(() => {
        this.toast.success('Article successfully published');
        this.router.navigate(['/viewarticles']);
      })
    ).subscribe();
  }
}

