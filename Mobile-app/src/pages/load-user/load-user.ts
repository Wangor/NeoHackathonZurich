import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { AngularFireDatabase } from "angularfire2/database";
import { HomePage } from '../home/home';
import { Profile } from '../../models/model';
import { AngularFireAuth } from 'angularfire2/auth';
import { TakephotoPage } from '../takephoto/takephoto';

/**
 * Generated class for the LoadUserPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-load-user',
  templateUrl: 'load-user.html',
})
export class LoadUserPage {

  arrData = []
  myInput
  myInput2
  myInput3
  Conteo2 = '0';
  verify2 = '0';
  respuesta = '';
  porcentaje = '';



  profile = {} as Profile;


  constructor(private aFAuth: AngularFireAuth, private afdatabase: AngularFireDatabase,
    public navCtrl: NavController, public navParams: NavParams, private fdb: AngularFireDatabase) {

  }

GoPhoto(color, color1, color2){

  color = color + ' ' + color1 + ' ' + color2;
  
  console.log(color);
  this.navCtrl.setRoot(HomePage, {data: color});




}

btnAddClicked(color){

  this.profile.conteo = this.Conteo2;
  this.profile.verify = this.verify2;
  this.profile.respuesta = this.respuesta;
  this.profile.porcentaje = this.porcentaje;

  this.aFAuth.authState.take(1).subscribe(auth =>{
    this.afdatabase.object(`Oustguard-Not-Verify/${auth.uid}-${this.profile.cedula}`).set(this.profile.conteo)
})


  this.aFAuth.authState.take(1).subscribe(auth =>{
      this.afdatabase.object(`Oustguard-Users/${auth.uid}`).set(this.profile)
        .then(() => this.navCtrl.push(TakephotoPage, {data: color}))
  })

  /**
  const cachedCart = this.fdb.object(`/Orrait/${this.myInput3}/Name`);
  cachedCart.set(this.myInput);


  const cachedCart2 = this.fdb.object(`/Orrait/${this.myInput3}/LastName`);
  cachedCart2.set(this.myInput2);

  const cachedCart3 = this.fdb.object(`/Orrait/${this.myInput3}/Passport`);
  cachedCart3.set(this.myInput3);

  const cachedCart4 = this.fdb.object(`/Orrait/${this.myInput3}/Verify`);
  cachedCart4.set(this.Verify2);

  

  this.fdb.list("/Orrait-" + this.myInput3 + "/").push({Name: this.myInput,
                                                        lastName: this.myInput2});




  this.fdb.list("/Orrait-" + this.myInput3 + "/").push("Names: " + this.myInput);
  this.fdb.list("/Orrait-" + this.myInput3 + "/").push("Last Names: " + this.myInput2);
  this.fdb.list("/Orrait-" + this.myInput3 + "/").push("Passport-number: " + this.myInput3  );

   */
  
}



ionViewDidLoad() {
  console.log('ionViewDidLoad LoadUserPage');
}

}
