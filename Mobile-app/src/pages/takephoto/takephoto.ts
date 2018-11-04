import { Component } from '@angular/core';
import { NavController, NavParams, ToastController, IonicPage  } from 'ionic-angular';
import { storage} from 'firebase';
import { Camera, CameraOptions } from '@ionic-native/camera';
import { AngularFireAuth } from 'angularfire2/auth';
import { AngularFireDatabase, FirebaseObjectObservable} from "angularfire2/database";
import { Profile } from '../../models/model';



/**
 * Generated class for the TakephotoPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-takephoto',
  templateUrl: 'takephoto.html',
})
export class TakephotoPage {

  color: string;
  public buttonClicked: boolean = false;
  public buttonClicked2: boolean = false;
  UID : string;

  profileData: FirebaseObjectObservable<Profile>
  profile = {} as Profile;
  myRand: number;


  constructor(private afdatabase: AngularFireDatabase, private aFAuth: AngularFireAuth, private toast: ToastController,
    private camera: Camera, public navCtrl: NavController, public navParams: NavParams) {

      this.color = navParams.get('data');
      console.log(this.navParams.get('data'));


  }



  ionViewDidLoad() {
    

    this.aFAuth.authState.subscribe(data => {
      if(data && data.email && data.uid){


        this.profileData = this.afdatabase.object(`Orrait-Profiles/${data.uid}`) 
        this.UID = data.uid;
      }
      else{
      }

    });

  }

  
  openfirst(){

    this.myRand = Math.floor(Math.random()*999)+3;


    this.aFAuth.authState.take(1).subscribe(auth =>{
      this.afdatabase.object(`activar1`).set(this.myRand)
  })

  this.navCtrl.setRoot('LoginPage');
  console.log(this.myRand);
  }

  openfirst2(){

    this.navCtrl.setRoot('LoadUserPage')

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

   const result = await this.camera.getPicture(options);
   const image =  `data:image/jpeg;base64,${result}`	;
   //const pictures = storage().ref('pictures/' + this.color);
   const pictures = storage().ref(this.UID + '-Oustguard-' + this.color);
   pictures.putString(image, 'data_url')
   this.buttonClicked = !this.buttonClicked;
   
  }
  catch (e) {
    console.error(e);
  }
 }




}
