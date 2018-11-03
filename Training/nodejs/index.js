/* Node.js modules */
var bodyParser = require('body-parser')
var app = require('express')();
var express = require('express');
var path = require('path');


//app.use(app.static(__dirname + '/'));
app.set('views', path.join(__dirname, 'view/scan'));
app.engine('html', require('ejs').renderFile);
app.set('view engine', 'html');
app.use(express.static(path.join(__dirname, 'view/scan')));

app.use( bodyParser.json() );                       // to support JSON-encoded bodies
app.use( bodyParser.urlencoded({extended: true}) ); // to support URL-encoded bodies

require("./routes/endpoints")(app);

const port = 8000;

/* INITIALIZATION OF HTTP SERVER */
app.listen(port, () => {
    console.log("Listening on port: " + port + "...");
});