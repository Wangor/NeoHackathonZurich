
const neoJs = require("../neo-js.js");

const jeroAddress = "AK2nJJpJr6o664CWJKi1QRXjqeic2zRp8y";
const matthiasAddress = "ALfsjbJLkQXSPEnEXEqJUnfXqGbCko3tpx";

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
            
            if (call.result.stack.length > 0 && call.result.stack[0].value) {
                result.exist = true;
                result.address = call.result.stack[0].value;
            }

            res.json(result);
        }
        catch(ex) {
            res.status(500).send({error: ex.message});    
        }
    });
    
}