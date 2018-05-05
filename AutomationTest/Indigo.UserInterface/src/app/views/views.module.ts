import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { Item01Component } from './item01/item01.component';
import { Item02Component } from './item02/item02.component';
import { Item03Component } from './item03/item03.component';
import { Item04Component } from './item04/item04.component';
import { Item05Component } from './item05/item05.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  declarations: [
    HomeComponent,
    Item01Component,
    Item02Component,
    Item03Component,
    Item04Component,
    Item05Component
  ]
})
export class ViewsModule { }
