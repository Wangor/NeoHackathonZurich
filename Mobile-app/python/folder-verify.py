import glob
import shutil
import os
import google.cloud.storage
import urllib.request
from time import sleep
import pyrebase

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


os.environ["GOOGLE_APPLICATION_CREDENTIALS"]="E:/Oustguard/PYTHON/face-id-verification/AI-Oustguard-5a9baca3ca23.json"


with open('Not-Verify.txt', 'r') as f:

    
    for line in f:
        line = str(line)
        line = line.replace("\n" , "")
        line = line.replace(":0" , "-0")        
        list = line.split("-")
                       
        # base dir
        _dir = r"E:\Oustguard\PYTHON\face-id-verification\Verification"       

        # creates folder
        _dir = os.path.join(_dir, list[1])

        # create 'dynamic' dir, if it does not exist
        if not os.path.exists(_dir):
            os.makedirs(_dir)

        # Create a storage client.
        storage_client = google.cloud.storage.Client()

        # TODO (Developer): Replace this with your Cloud Storage bucket name.
        bucket_name = 'ai-oustguard.appspot.com'
        bucket = storage_client.get_bucket(bucket_name)

        blob = bucket.blob(os.path.basename('%s-Oustguard-%s' % (list[0],list[1])))
        blob.make_public()
        print(blob.public_url)

        urllib.request.urlretrieve(blob.public_url, "Face.jpg")

        name = 'Face.jpg'

        shutil.move(r"E:\Oustguard\PYTHON\face-id-verification\%s" % name ,
                  r"E:\Oustguard\PYTHON\face-id-verification\Verification\%s" % (list[1]) )

        blob = bucket.blob('%s-Oustguard-%s' % (list[0],list[1]))
        blob.delete()
        db.child("Oustguard-Not-Verify").child().remove()
        







        

     
