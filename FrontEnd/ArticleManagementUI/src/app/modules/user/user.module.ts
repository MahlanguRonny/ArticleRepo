import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { ViewPublishersComponent } from './components/view-publishers/view-publishers.component';


@NgModule({
  declarations: [
    ViewPublishersComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule
  ]
})
export class UserModule { }
