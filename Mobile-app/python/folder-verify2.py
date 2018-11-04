import glob
import shutil
import os
import google.cloud.storage
import urllib.request
from time import sleep
import pyrebase
import boto3

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

SIMILARITY_THRESHOLD = 1.0
client = boto3.client('rekognition')

with open('Not-Verify2.txt', 'r') as f:

    
    for line in f:
        line = str(line)
        line = line.replace("\n" , "")
        line = line.replace(":0" , "-0")        
        list = line.split("-")
        test = db.child("activar3").get()
        users = test.val()
        
        print(users)
                       
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
        
        print(list[0])
        print(list[1])
        blob = bucket.blob(os.path.basename('%s-Oustguard-%s-%s' % (list[0],users,list[1])))
        blob.make_public()
        print(blob.public_url)

        urllib.request.urlretrieve(blob.public_url, "pass2.jpg")

        name = 'pass2.jpg'

        shutil.move(r"E:\Oustguard\PYTHON\face-id-verification\%s" % name ,
                  r"E:\Oustguard\PYTHON\face-id-verification\Verification\%s" % (list[1]) )

        with open('Verification/%s/Face.jpg' % list[1], 'rb') as source_image:
            source_bytes = source_image.read()


        with open('Verification/%s/pass2.jpg' % list[1], 'rb') as target_image:
            target_bytes = target_image.read()


        try:
            response = client.compare_faces(
                           SourceImage={ 'Bytes': source_bytes },
                           TargetImage={ 'Bytes': target_bytes },
                           SimilarityThreshold=SIMILARITY_THRESHOLD
        )
            for label in response['FaceMatches']:
                result = label['Similarity']
                print(result)
                pprint.pprint(label['Similarity'])

        except:
            
            if result > 80:
                print("yeah")
                db.child("Oustguard-Users").child(list[0]).update({"respuesta": "IT CORRESPONDS TO THE USER"})
                db.child("Oustguard-Users").child(list[0]).update({"porcentaje": result})
                blob = bucket.blob('%s-Oustguard-%s-%s' % (list[0],users,list[1]))
                blob.delete()
                db.child("Oustguard2-Not-Verify").child().remove()
                os.remove('Verification/%s/pass2.jpg' % list[1])
        
            else:
                print("manual check")
                db.child("Oustguard-Users").child(list[0]).update({"respuesta": "ITS NOT THE USER"})
                db.child("Oustguard-Users").child(list[0]).update({"porcentaje": result})
                blob = bucket.blob('%s-Oustguard-%s-%s' % (list[0],users,list[1]))
                blob.delete()
                db.child("Oustguard2-Not-Verify").child().remove()
                os.remove('Verification/%s/pass2.jpg' % list[1])
