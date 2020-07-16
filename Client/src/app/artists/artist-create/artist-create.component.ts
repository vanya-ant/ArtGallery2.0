import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {

  }

  create() {

  }

  run() {
    const category = document.getElementById('category');

  }
}
