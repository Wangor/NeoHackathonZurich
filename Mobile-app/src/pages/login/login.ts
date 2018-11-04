import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { User } from '../../models/user';
import { AngularFireAuth } from 'angularfire2/auth';

/**
 * Generated class for the LoginPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-login',
  templateUrl: 'login.html',
})
export class LoginPage {

  user = {} as User;

  constructor(private aFAuth: AngularFireAuth, public navCtrl: NavController, public navParams: NavParams) {
  }

  async Login(user: User){
    try{
      const result = this.aFAuth.auth.signInWithEmailAndPassword(user.email, user.password);
      if(result) {
        this.navCtrl.setRoot('MainPage')
      }

    }
    catch(e){
      console.error(e);
      this.navCtrl.setRoot('LoginPage')
    }
    
  }

  Register(){
    this.navCtrl.setRoot('RegisterPage');
  }


  ionViewDidLoad() {
    console.log('ionViewDidLoad LoginPage');
  }


}
