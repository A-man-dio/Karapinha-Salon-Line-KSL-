import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { SessaoService } from 'src/app/Serviços/sessao.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  loginForm!: FormGroup;
  
  
  constructor(private fb: FormBuilder,private sessaoService: SessaoService) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
        ]
      ]
    });
  }

  login() {
    if (this.loginForm.invalid) {
      return;
    }

    this.sessaoService.setItem()
    console.log('Formulário válido:', this.loginForm.value);
  }
  
  get email(): FormControl {
    return this.loginForm.get('email') as FormControl;
  }
  get password(): FormControl {
    return this.loginForm.get('password') as FormControl;
  }
  
}
