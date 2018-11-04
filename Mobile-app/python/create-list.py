# Imports the Google Cloud client library
from google.cloud import storage
import os

from firebase import firebase
firebase = firebase.FirebaseApplication('https://ai-oustguard.firebaseio.com/', None)
result = firebase.get('/Oustguard-Not-Verify', None)

data = str(result)
data = data.replace("{", "")
data = data.replace("}", "")
data = data.replace("'", "")
data = data.replace(", ", ",")
data = data.replace(" ", "")
number = len(data.split(','))

num = int(number)

list = data.split(",")



print (num)
print (data)

open('Not-Verify.txt', 'w').close()

with open('Not-Verify.txt', 'a') as f:
    for x in range(len(list)):
        f.write(list[x])
        f.write("\n")


os.system('python folder-verify.py')    
