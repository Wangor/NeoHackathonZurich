from boa.interop.Neo.Blockchain import GetHeight, GetHeader
from boa.interop.Neo.Header import GetTimestamp, GetHash, GetNextConsensus  
from boa.interop.Neo.Runtime import Log, Notify,Serialize,Deserialize
from boa.interop.Neo.Storage import Get, Put,Delete, GetContext
from boa.interop.Neo.Runtime import GetTrigger,CheckWitness
from boa.builtins import concat

OWNER = b'#\xba\'\x03\xc52c\xe8\xd6\xe5"\xdc2 39\xdc\xd8\xee\xe9'

def Main(operation,args):
    nargs = len(args)
    if nargs == 0:
        print("No Argumnets given")
        return 0

    if operation == 'save':
        
        
        is_owner = CheckWitness(OWNER)
        if is_owner == True:
            msg = ["you are the owner:", is_owner]
            Notify(msg)
        else:
            msg = ["you are not the owner:", is_owner]
            Notify(msg)
            return 0
        
        context = GetContext()
              
        # This is the storage key
        item_key = args[0]
        item_key0 = args[0]+"hid"
        item_key1 = args[0]+"nid"
        item_key2 = args[0]+"addid"
        item_key3 = args[0]+"citid"
        
        img_url = args[1]
        img_hash = args[2]
        name = args[3]
        address = args[4]
        citizenship = args[5]
        
        

        # Try to get a value for this key from storage
        item_value = Get(context, item_key)
        msg = ["Value read from storage:", img_url,img_hash,name,address,citizenship]
        Notify(msg)
        
        
        # Store the new value
        Put(context, item_key,img_url)
        Put(context, item_key0,img_hash)
        Put(context, item_key1,name)
        Put(context, item_key2,address)
        Put(context, item_key3,citizenship)
       
        
        return True
    elif operation == 'getImgUrl':
        item_key = args[0]
        context = GetContext()
        img_url = Get(context,item_key)

        Notify(img_url)
        
        return (img_url)
        
    elif operation == 'getImgHash':
        
        item_key = args[0]+"hid"
        context = GetContext()
        img_hash = Get(context,item_key)
        Notify(img_hash)
        return (img_hash)
    
    elif operation == 'getName':
        
        item_key = args[0]+"nid"
        context = GetContext()
        name = Get(context,item_key)
        Notify(name)
        return (name)
    
    elif operation == 'getAddress':
        
        item_key = args[0]+"addid"
        context = GetContext()
        address = Get(context,item_key)
        Notify(address)
        return (address)
    
    elif operation == 'getCitizenship':
        
        item_key = args[0]+"citid"
        context = GetContext()
        citizenship = Get(context,item_key)
        Notify(citizenship)
        return (citizenship)
    
    elif operation == 'getinfo':
        item_key = args[0]
        item_key0 = args[0]+"hid"
        item_key1 = args[0]+"nid"
        item_key2 = args[0]+"addid"
        item_key3 = args[0]+"citid"

        context = GetContext()
            
        img_url = Get(context,item_key)
        img_hash = Get(context,item_key)
        name = Get(context,item_key)
        address = Get(context,item_key)
        citizenship = Get(context,item_key)

        msg = concat(item_key,img_url,img_hash,name,address,citizenship)
        
       
        Notify(msg)
        return msg
    elif operation == 'time':

        current_height = GetHeight()
        Notify(current_height)
        current_block = GetHeader(current_height)
        Notify(current_block)
        timestamp = current_block.Timestamp
        Notify(timestamp)
        return timestamp
    
 
    else:
        return 0
    
