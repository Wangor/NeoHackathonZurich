
const neoJs = require("../neo-js.js");

const jeroAddress = "AK2nJJpJr6o664CWJKi1QRXjqeic2zRp8y";
const matthiasAddress = "ALfsjbJLkQXSPEnEXEqJUnfXqGbCko3tpx";

module.exports = function(app) {
       
    app.get('/getBalance/:address', async function (req, res) {    
        
        try {      

            if (!req.params.address) {
                res.status(400).send({error: "The address value is missing"});    
                return;
            }  

            let address = req.params.address;    
            let result = await neoJs.getBalance(address);  
            
            res.send(result);
        }
        catch(ex) {
            res.status(500).send({error: ex.message});    
        }
    });
    
}