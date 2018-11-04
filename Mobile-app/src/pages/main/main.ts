import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, ToastController } from 'ionic-angular';
import { AngularFireAuth } from 'angularfire2/auth';
/**
 * Generated class for the MainPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-main',
  templateUrl: 'main.html',
})
export class MainPage {

  constructor(private aFAuth: AngularFireAuth, private toast: ToastController,
     public navCtrl: NavController, public navParams: NavParams) {
  }

  Verify(){
    this.navCtrl.setRoot('TextPage');
  }


  ionViewDidLoad() {
    console.log('ionViewDidLoad MainPage');


    this.aFAuth.authState.subscribe(data => {
      if(data && data.email && data.uid){

      }
      else{

      }

    });
  
  }

}
