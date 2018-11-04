import { Component } from '@angular/core';
import { NavController, NavParams, ToastController, LoadingController  } from 'ionic-angular';
import { storage} from 'firebase';
import { Camera, CameraOptions } from '@ionic-native/camera';
import {FirstPage} from '../first/first';
import { AngularFireAuth } from 'angularfire2/auth';
import { AngularFireDatabase, FirebaseObjectObservable, FirebaseListObservable} from "angularfire2/database";
import { Profile } from '../../models/model';
import { TextPage } from '../text/text';
import { LoadUserPage } from '../load-user/load-user';



@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  color: string;
  public buttonClicked: boolean = false;
  public buttonClicked2: boolean = false;
  public buttonClicked3: boolean = false;
  UID : string;
  myRand2: number;

  public profileData: FirebaseObjectObservable<Profile>
  profile = {} as Profile;

  public items: FirebaseListObservable<any[]>;
  loadedRelic: string;
  verify
  myRand



  constructor(private afdatabase: AngularFireDatabase, private aFAuth: AngularFireAuth, private toast: ToastController,
    private camera: Camera, public navCtrl: NavController, public navParams: NavParams, private loadingCtrl: LoadingController) {

      this.color = navParams.get('data');
      console.log(this.navParams.get('data'));

  }

  ionViewDidLoad() {
    

    this.aFAuth.authState.subscribe(data => {
      if(data && data.email && data.uid){


        this.profileData = this.afdatabase.object(`Oustguard-Users/${data.uid}`) 
        this.UID = data.uid;
      }
      else{

      }

    });

  }

  presentLoadingCustom() {


    let loading = this.loadingCtrl.create({
      spinner: 'crescent',
      content: 'Waiting for block',
      duration: 15000
    });

    loading.onDidDismiss(() => {
      console.log('Dismissed loading');
    });

    loading.present();
  }

  next(){

    this.profile.respuesta = "";
    this.profile.porcentaje = "";

    this.aFAuth.authState.take(1).subscribe(auth =>{
      this.afdatabase.object(`Oustguard-Users/${auth.uid}`).update(this.profile)
  })

  this.navCtrl.setRoot('TextPage')

  }

  register(){

    this.profile.respuesta = "";
    this.profile.porcentaje = "";

    this.aFAuth.authState.take(1).subscribe(auth =>{
      this.afdatabase.object(`Oustguard-Users/${auth.uid}`).update(this.profile)
  })

    this.navCtrl.setRoot('LoadUserPage')
  }


  openfirst(){

    
    this.myRand = Math.floor(Math.random()*999)+3;


    this.aFAuth.authState.take(1).subscribe(auth =>{
      this.afdatabase.object(`activar2`).set(this.myRand)
  })

  console.log(this.myRand);


    this.presentLoadingCustom();

    this.buttonClicked2 = !this.buttonClicked2;
    this.buttonClicked3 = !this.buttonClicked3;

    //this.navCtrl.setRoot(FirstPage, {data: this.color})
  }


 async takephoto (){
   //defining camera options
  try {
   const options: CameraOptions = {
     quality: 75,
     targetHeight: 600,
     targetWidth: 600,
     destinationType: this.camera.DestinationType.DATA_URL,
     encodingType: this.camera.EncodingType.JPEG,
     mediaType: this.camera.MediaType.PICTURE,
     correctOrientation: true
   }

       
   this.myRand = Math.floor(Math.random()*99997101)+3;


   this.aFAuth.authState.take(1).subscribe(auth =>{
     this.afdatabase.object(`activar3`).set(this.myRand)
 })

   const result = await this.camera.getPicture(options);
   const image =  `data:image/jpeg;base64,${result}`	;
   //const pictures = storage().ref('pictures/' + this.color);
   const pictures = storage().ref(this.UID + '-Oustguard-' + this.myRand + '-' + this.color);
   pictures.putString(image, 'data_url')
   this.buttonClicked = !this.buttonClicked;
   
  }
  catch (e) {
    console.error(e);
  }
 }
 
}
