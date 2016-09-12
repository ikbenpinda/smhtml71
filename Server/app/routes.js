var multer  = require('multer');
var upload = multer({ dest: './downloads' });
module.exports = function(app) {

	// server routes ===========================================================
	// handle things like api calls
	// authentication routes

	// frontend routes =========================================================
	// route to handle all angular requests
	app.get('/', function(req, res) {
		res.render('./public/test');
	});

	/////////FILE UPLOADING========================================================
	var storage = multer.diskStorage({
    destination: function (req, file, callback) {
        callback(null, './server/downloads');
    },
    filename: function (req, file, callback) {
        console.log(file.originalname);
        callback(null, file.originalname + '-' + Date.now());
    }
});
	var upload = multer({ storage: storage }).single('file');
app.post("/fileUpload", function(req, res) //upload.single('file')
{
	if(req.file.originalname == "img"){
		console.log("uploading image");
	}
	else if(req.file.originalname == "vid"){
		console.log("uploading video");
	}
	else{
		console.log("unexpected file");
	}
 upload(req, res, function (err) {
        console.log(req.file);
        if (err) {
            console.log("error");
            console.log(err);
            return res.end("Error uploading file.");
        }
        console.log("File has been received");
        res.end("File is uploaded");
});})
app.get("/test", function(req,res){
console.log("helloo");
res.json({"result": "connected"})
});
};