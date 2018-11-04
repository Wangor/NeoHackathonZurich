import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { User } from '../../models/user';
import { AngularFireAuth } from 'angularfire2/auth';

/**
 * Generated class for the RegisterPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-register',
  templateUrl: 'register.html',
})
export class RegisterPage {

  user = {} as User;

  constructor(private aFAuth: AngularFireAuth, public navCtrl: NavController, public navParams: NavParams) {
  }

  async Register(user: User){
    try{
      const result = this.aFAuth.auth.signInWithEmailAndPassword(user.email, user.password);
      if(result) {
        this.navCtrl.setRoot('LoadUserPage')
      }
      else{
        this.navCtrl.setRoot('RegisterPage')
      }

    }
    catch(e){
      this.navCtrl.setRoot('RegisterPage')
      
    }
    
  }

  login(){
    this.navCtrl.setRoot('LoginPage');
  }


  ionViewDidLoad() {
    console.log('ionViewDidLoad RegisterPage');
  }

}
