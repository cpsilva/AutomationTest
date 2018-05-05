import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../views/home/home.component';
import { Item01Component } from '../views/item01/item01.component';
import { Item02Component } from '../views/item02/item02.component';
import { Item03Component } from '../views/item03/item03.component';
import { Item04Component } from '../views/item04/item04.component';
import { Item05Component } from '../views/item05/item05.component';


const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'item01',
    component: Item01Component
  },
  {
    path: 'item02',
    component: Item02Component
  },
  {
    path: 'item03',
    component: Item03Component
  },
  {
    path: 'item04',
    component: Item04Component
  },
  {
    path: 'item05',
    component: Item05Component
  },
  { path: '', component: HomeComponent, pathMatch: 'full' },

  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class RouteModule { }
