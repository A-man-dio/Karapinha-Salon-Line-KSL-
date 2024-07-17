import { Directive, HostListener, Input } from '@angular/core';
import { Router } from '@angular/router';


@Directive({
  selector: '[DetalheProd]'
})
export class DetalheProdDirective {
  @Input() prodID: number =0;

  @HostListener('click') detalheProduto() {
    window.scrollTo(0,0);
    this.router.navigate(['/detalheServ']),{
      queryParams: {
        id: this.prodID
      },
    }
  }

  constructor(private router:Router) { }

}
