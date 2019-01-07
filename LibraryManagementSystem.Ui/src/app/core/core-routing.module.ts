import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { PageNotFoundComponent } from './supporting-components/page-not-found/page-not-found.component';
import { UnauthorizedComponent } from './supporting-components/unauthorized/unauthorized.component';
import { ErrorComponent } from './supporting-components/error/error.component';

const routes: Routes = [
  {path: 'page-not-found', component: PageNotFoundComponent},
  {path: 'unauthorized', component: UnauthorizedComponent},
  {path: 'error', component: ErrorComponent},
  {path: '**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class CoreRoutingModule { }
