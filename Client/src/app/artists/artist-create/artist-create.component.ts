import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {ArtistsService} from '../../shared/services/artists.service';
import {Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-artist-create',
  templateUrl: './artist-create.component.html',
  styleUrls: ['./artist-create.component.scss']
})
export class ArtistCreateComponent implements OnInit {

  options = [
    { name: 'Paintings', value: 'Paintings' },
    { name: 'Photography', value: 'Photography' },
    { name: 'Illustration', value: 'Illustration' },
    { name: 'Sculpture', value: 'Sculpture' },
    { name: 'Prints', value: 'Prints' },
    { name: 'Textile', value: 'Textile' },
    { name: 'Design', value: 'Design' },
    { name: 'Jewelery', value: 'Jewelery' },
  ];

  form: FormGroup;

  constructor(private formBuilder: FormBuilder,
              private artistsService: ArtistsService,
              private router: Router,
              private toastr: ToastrService) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      category: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.minLength(3)]],
      imageUrl: ['', [Validators.required]],
    });
  }

  async create() {
    this.artistsService.createArtist(this.form.value).subscribe(res => {
      this.toastr.success('Successfully created artist!');
      this.router.navigate(['blog']);
    });
  }

  run() {
    const category = document.getElementById('category');
  }
}
