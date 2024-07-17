import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProdutosComponent } from './Components/produtos/produtos.component';
import { ProdutosSugeridosComponent } from './Components/produtos-sugeridos/produtos-sugeridos.component';
import { HomeComponent } from './Components/home/home.component';
import { ProdutoComponent } from './Components/produto/produto.component';
import { DetalheProdutoComponent } from './Components/detalhe-produto/detalhe-produto.component';
import { ListaPedComponent } from './Components/lista-ped/lista-ped.component';
import { MarcarComponent } from './Components/marcar/marcar.component';
import { FormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './Components/header/header.component';
import { FooterComponent } from './Components/footer/footer.component';
import { CatServicosDirective } from './Diretivas/cat-servicos.directive';
import { DetalheProdDirective } from './Diretivas/detalhe-prod.directive';
import { RegistoComponent } from './Components/registo/registo.component';
import { LoginComponent } from './Components/login/login.component';
import { AdmHomeComponent } from './Components/adm-home/adm-home.component';





@NgModule({
  declarations: [
    AppComponent,
    ProdutosComponent,
    ProdutosSugeridosComponent,
    HomeComponent,
    ProdutoComponent,
    DetalheProdutoComponent,
    ListaPedComponent,
    MarcarComponent,
    HeaderComponent,
    FooterComponent,
    CatServicosDirective,
    DetalheProdDirective,
    RegistoComponent,
    LoginComponent,
    AdmHomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    NgxMaterialTimepickerModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
