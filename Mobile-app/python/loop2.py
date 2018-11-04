import pyrebase
import os

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
