import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { DetalheProdutoComponent } from './Components/detalhe-produto/detalhe-produto.component';
import { ListaPedComponent } from './Components/lista-ped/lista-ped.component';
import { ProdutoComponent } from './Components/produto/produto.component';
import { MarcarComponent } from './Components/marcar/marcar.component';

const routes: Routes = [
  {path: 'home', component: HomeComponent},//tela inicial
  {path: 'detalheServ', component: DetalheProdutoComponent}, // ao clicar sobre a imagem do servico
  {path: 'marcacoes', component: ListaPedComponent},//itens selecionados para marcar+historico de marcações
  {path: 'produtos', component: ProdutoComponent}, //lista com todos os serviços
  {path: 'addMarcacao', component: MarcarComponent},//dps de clicar em adicionar serviço
  {path: '',redirectTo:'/home', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
