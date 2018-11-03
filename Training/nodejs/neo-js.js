

const neonjs  = require('@cityofzion/neon-js');

let self = {};

const Neon = neonjs.default;

const grpcUrl = "http://10.21.221.37:30333/";

const address = "AK2nJJpJr6o664CWJKi1QRXjqeic2zRp8y";
const publicKey = "031a6c6fbbdf02ca351745fa86b9ba5a9452d785ac4f7fc2b7548ca2a46c4fcf4a";
const contractHash = "a4e6af094a380a2d0b78e8454e00e8fb8d17f0ed";

/*
const localConfig = {
    name: 'PrivateNet',
    extra: {
      neoscan: 'http://10.21.221.46:4000/api/main_net'
    }
  }
 
const privateNet = new neonjs.rpc.Network(localConfig);
Neon.add.network(privateNet);
 
const privateNet = new neonjs.rpc.Network(localConfig);
Neon.add.network(privateNet);
*/  

self.validateTicket = async function(ticketId) {

    const sb = Neon.create.scriptBuilder();
    sb.emitAppCall(contractHash, "query", [Neon.u.str2hexstring(ticketId)]);

    return neonjs.rpc.Query.invokeScript(sb.str).execute(grpcUrl);
}

function register() {

    const sb = Neon.create.scriptBuilder();
   
    sb.emitAppCall(contractHash, "register", [Neon.u.str2hexstring("demo.com"), Neon.u.str2hexstring(address)]);
    const tx = Neon.create.invocationTx(publicKey, {}, {}, sb.str, 1);

    console.log(tx);
}

/*
validateTicket("demo.com").then((res) => {
    if (res.result.stack.length > 0 && res.result.stack[0].value) {
        console.log(true);
    }
    else {
        console.log(false);
    }
});
*/

module.exports = self;