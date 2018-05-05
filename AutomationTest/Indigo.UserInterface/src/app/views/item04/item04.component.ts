import { Component, OnInit } from '@angular/core';
import { debug } from 'util';
import { AfterViewInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
  selector: 'app-item04',
  templateUrl: './item04.component.html'
})

export class Item04Component {
  operacao = {
    numero1: 928,
    numero2: 8736,
  };

  model: any = this.operacao;

  constructor() {
  }

  operacoes() {
    this.model.soma = this.soma(this.model);
    this.model.subtracao = this.subtracao(this.model);
  }

  soma(model) {
    return this.model.numero1 + this.model.numero2;
  }

  subtracao(model) {

    if (this.model.numero2 > this.model.numero1) {
      return this.model.numero2 - this.model.numero1;
    } else {
      return this.model.numero1 - this.model.numero2;
    }
    
  }
}
