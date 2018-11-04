
const neoJs = require("../neo-js.js");

module.exports = function(app) {

    app.get('/verify/:ticketId', async function (req, res) {    
        
        try {      

            if (!req.params.ticketId) {
                res.status(400).send({error: "The ticket id value is missing"});    
                return;
            }  

            let result = {
                exist: false,
                address: ""
            };

            let ticketId = req.params.ticketId;    
            let call = await neoJs.validateTicket(ticketId); 

            if (call.result.stack.length > 0) {
                result.exist = true;

                const neonjs  = require('@cityofzion/neon-js');            
                const Neon = neonjs.default;
    
                let myresult = call.result.stack[0].value[0].value; 
                myresult = Neon.u.hexstring2str(myresult);

                result.address = myresult;
            }

            res.json(result);
        }
        catch(ex) {
            res.status(500).send({error: ex.message});    
        }
    });
    
}