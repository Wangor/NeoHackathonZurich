import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { SplashScreen } from '@ionic-native/splash-screen';
import { StatusBar } from '@ionic-native/status-bar';
import { Camera } from '@ionic-native/camera';
import { AngularFireModule } from 'angularfire2';
import { AngularFireDatabaseModule } from 'angularfire2/database';
import { AngularFireAuthModule } from 'angularfire2/auth';
import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { FirstPage } from '../pages/first/first';
import { Load1Page } from '../pages/load1/load1';
import { TakephotoPage } from '../pages/takephoto/takephoto';



var config = {
  apiKey: "AIzaSyAF35G5dpLS4B0-f9F3eISILjpEwvxdQVE",
  authDomain: "ai-oustguard.firebaseapp.com",
  databaseURL: "https://ai-oustguard.firebaseio.com",
  projectId: "ai-oustguard",
  storageBucket: "ai-oustguard.appspot.com",
  messagingSenderId: "728374409566"
};

@NgModule({
  declarations: [
    MyApp,
    HomePage,
    FirstPage,
    Load1Page,
    TakephotoPage
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(MyApp),
    AngularFireModule.initializeApp(config),
    AngularFireDatabaseModule,
    AngularFireAuthModule

  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    FirstPage,
    Load1Page,
    TakephotoPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    Camera,
    {provide: ErrorHandler, useClass: IonicErrorHandler}
  ]
})
export class AppModule {}
