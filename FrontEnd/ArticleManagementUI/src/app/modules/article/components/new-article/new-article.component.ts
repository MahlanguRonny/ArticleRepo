import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-new-article',
  templateUrl: './new-article.component.html',
  styleUrls: ['./new-article.component.scss']
})
export class NewArticleComponent implements OnInit {
  public newArticleForm: FormGroup;

  constructor(
    public formBuilder: FormBuilder,
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
  }

}
