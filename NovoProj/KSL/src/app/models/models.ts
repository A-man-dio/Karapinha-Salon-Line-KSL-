export interface Categoria{
    id:number;
    categoria:string;
}

export interface ProdutosSugeridos{
    categoria: Categoria;
    imagem:string;
}

export interface Navegacao{
    categoria: string;
}