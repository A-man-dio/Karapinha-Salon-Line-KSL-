import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-registo',
  templateUrl: './registo.component.html',
  styleUrls: ['./registo.component.css']
})
export class RegistoComponent implements OnInit {
  
  registerForm!: FormGroup;
  invalidRPass: boolean = false;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      nome: [
        '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.pattern('[a-zA-Z].*'),
        ],
      ],
      contacto: [
        '',
        [
          Validators.required,
          Validators.min(900000000),
        ],
      ],
      username:[
        '',
        [
          Validators.required,
          Validators.minLength(2),
        ],
      ],
      BI:[
        '',
        [
          Validators.required,
          Validators.minLength(5),
        ],
      ],
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
        ]
      ],
      rpassword: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
        ]
      ]
    });

    
    this.registerForm.get('rpassword')?.valueChanges.subscribe(() => {
      this.invalidRPass = this.registerForm.get('password')?.value !== this.registerForm.get('rpassword')?.value;
    });
  }

  registar() {
    if (this.registerForm.invalid) {
      return;
    }

    
    console.log('Formulário válido:', this.registerForm.value);
  }

  get nome(): FormControl {
    return this.registerForm.get('nome') as FormControl;
  }
  get contacto(): FormControl {
    return this.registerForm.get('contacto') as FormControl;
  }
  get username(): FormControl {
    return this.registerForm.get('username') as FormControl;
  }
  get bi(): FormControl {
    return this.registerForm.get('BI') as FormControl;
  }
  get email(): FormControl {
    return this.registerForm.get('email') as FormControl;
  }
  get password(): FormControl {
    return this.registerForm.get('password') as FormControl;
  }
  get rpassword(): FormControl {
    return this.registerForm.get('rpassword') as FormControl;
  }
}
