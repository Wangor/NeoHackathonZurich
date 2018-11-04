import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { LoadUserPage } from './load-user';

@NgModule({
  declarations: [
    LoadUserPage,
  ],
  imports: [
    IonicPageModule.forChild(LoadUserPage),
  ],
})
export class LoadUserPageModule {}
