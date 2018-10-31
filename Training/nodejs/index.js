var neonjs = require('@cityofzion/neon-js')


var Neon = neonjs.default;

const address = "AK2nJJpJr6o664CWJKi1QRXjqeic2zRp8y";

const config = {
    name: 'PrivateNet',
    extra: {
      neoscan: 'http://localhost:4000/api/main_net'
    }
  }
 
const privateNet = new neonjs.rpc.Network(config);
Neon.add.network(privateNet);

let ns = new neonjs.api.neoscan.instance("PrivateNet");
ns
    .getBalance(address)
    .then(res => {
        console.log(res)
    })
    .catch( (ex) => { console.log(ex) });
