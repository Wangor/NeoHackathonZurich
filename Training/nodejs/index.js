/* Node.js modules */
var bodyParser = require('body-parser')
var app = require('express')();

app.use( bodyParser.json() );                       // to support JSON-encoded bodies
app.use( bodyParser.urlencoded({extended: true}) ); // to support URL-encoded bodies

require("./routes/endpoints")(app);

const port = 8000;

/* INITIALIZATION OF HTTP SERVER */
app.listen(port, () => {
    console.log("Listening on port: " + port + "...");
});