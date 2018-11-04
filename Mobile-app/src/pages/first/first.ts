import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, ToastController } from 'ionic-angular';
import { storage } from 'firebase';
import { Camera, CameraOptions } from '@ionic-native/camera';
import { AngularFireAuth } from 'angularfire2/auth';
import { AngularFireDatabase, FirebaseObjectObservable} from "angularfire2/database";
import { Profile } from '../../models/model';

/**
 * Generated class for the FirstPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-first',
  templateUrl: 'first.html',
})
export class FirstPage {

  color: string;
  public buttonClicked: boolean = false;
  UID : string;
  Passport : string;

  profileData: FirebaseObjectObservable<Profile>
  profile = {} as Profile;

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
        this.toast.create({
          message: `Could not fin authentication details`,
          duration: 3000
        }).present(); 
      }

    });

  }


 async takephoto2 (){
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
  const pictures = storage().ref(this.UID + '-Orrait-ID-' + this.color);
  pictures.putString(image, 'data_url')
 }
 catch (e) {
   console.error(e);
 }
}

}
