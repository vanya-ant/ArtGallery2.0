import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';
import {BlogService} from '../../shared/services/blog.service';
import {IArticle} from '../../shared/article';

@Component({
  selector: 'app-article-create',
  templateUrl: './article-create.component.html',
  styleUrls: ['./article-create.component.scss']
})
export class ArticleCreateComponent implements OnInit {

  form: FormGroup;

  article: IArticle;

  constructor(private formBuilder: FormBuilder,
              private blogService: BlogService,
              private router: Router,
              private toastr: ToastrService) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      title: ['', [Validators.required, Validators.minLength(3)]],
      author: ['', [Validators.required, Validators.minLength(3)]],
      date: [Date.now(), [Validators.required]],
      content: ['', [Validators.required, Validators.minLength(3)]],
    });
  }

  async create() {
    this.blogService.createArticle(this.form.value).subscribe(res => {
      this.toastr.success('Successfully created article!');
      this.router.navigate(['blog']);
    });
  }
}
