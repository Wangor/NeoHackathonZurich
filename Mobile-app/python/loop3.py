import pyrebase
import os
import urllib.request
import glob
import shutil
import os
import requests

a = 0
nuevo = '3185350307'
config = {
    'apiKey': "AIzaSyAF35G5dpLS4B0-f9F3eISILjpEwvxdQVE",
    'authDomain': "ai-oustguard.firebaseapp.com",
    'databaseURL': "https://ai-oustguard.firebaseio.com",
    'projectId': "ai-oustguard",
    'storageBucket': "ai-oustguard.appspot.com",
    'messagingSenderId': "728374409566"
}
firebase = pyrebase.initialize_app(config)
db=firebase.database()




def stream_handler(post):
    nuevo = ''
    a = 0
    print(post['data'])
    if post['data'] != nuevo:
        a = 0
    if a == 0:
        
        a= 1;
        nuevo = post['data']
        os.system('python create-list2.py')
    else:
        print("fail")
    

my_stream = db.child("activar2").stream(stream_handler, None)


def stream_handler2(post):
    nuevo = ''
    a = 0
    print(post['data'])
    if post['data'] != nuevo:
        a = 0
    if a == 0:
        
        a= 1;
        nuevo = post['data']
        os.system('python create-list.py')
        print("yeah")
    else:
        print("fail")
    

my_stream2 = db.child("activar1").stream(stream_handler2, None)




def stream_handler3(ok):

    urllib.request.urlretrieve("http://10.21.221.56/picturedownload/Download?filename=X1382222", "Face.jpg")
              

    name = '01'
    name2 = 'Face.jpg'

    try:
        # base dir
        _dir = r"E:\Oustguard\PYTHON\face-id-verification\Verification"       

        # creates folder
        _dir = os.path.join(_dir, name)

        # create 'dynamic' dir, if it does not exist
        if not os.path.exists(_dir):
            os.makedirs(_dir)

        shutil.move(r"E:\Oustguard\PYTHON\face-id-verification\%s" % name2 ,
                          r"E:\Oustguard\PYTHON\face-id-verification\Verification\%s" % (name) )


    except:
        print("error")

my_stream3 = db.child("activar4").stream(stream_handler3, None)

