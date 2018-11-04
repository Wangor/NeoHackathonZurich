import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { AngularFireAuth } from 'angularfire2/auth';
import { AngularFireDatabase, FirebaseObjectObservable, FirebaseListObservable} from "angularfire2/database";


/**
 * Generated class for the Load1Page page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-load1',
  templateUrl: 'load1.html',
})
export class Load1Page {

  UID : string;
  myRand2: number;


  public items: FirebaseListObservable<any[]>;
  loadedRelic: string;
  verify
  myRand



  constructor(private afdatabase: AngularFireDatabase, private aFAuth: AngularFireAuth,public navCtrl: NavController, public navParams: NavParams) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad Load1Page');
  }

  Register(){
    this.navCtrl.setRoot('RegisterPage');
  }

  Login(){
    this.navCtrl.setRoot('LoginPage');
  }

  send(){
           
   this.myRand = Math.floor(Math.random()*99997101)+3;


   this.aFAuth.authState.take(1).subscribe(auth =>{
     this.afdatabase.object(`activar4`).set(this.myRand)
 })

  }

}
