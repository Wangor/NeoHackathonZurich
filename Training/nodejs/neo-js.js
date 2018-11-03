var neonjs = require('@cityofzion/neon-js')

self = {};

var Neon = neonjs.default;

const localConfig = {
    name: 'PrivateNet',
    extra: {
      neoscan: 'http://localhost:4000/api/main_net'
    }
  }
 
const privateNet = new neonjs.rpc.Network(localConfig);
Neon.add.network(privateNet);
let neoscan = new neonjs.api.neoscan.instance("PrivateNet");

self.getBalance = async (account) => {

    return neoscan.getBalance(account);
}

module.exports = self;