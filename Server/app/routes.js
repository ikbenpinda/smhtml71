var multer  = require('multer');
var fs = require('fs');
var dateFormat = require('dateformat');
var now = new Date();
var baseDir = './downloads/'
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
		var name = file.originalname;
		var user = name.substring(0,name.length-4);
		var type = name.replace(user+"_", "");
		if(!fsMapExist(baseDir+user)){
			fs.mkdirSync(baseDir+user);
			fs.mkdirSync(baseDir+user+"/Photo");
			fs.mkdirSync(baseDir+user+"/Video");
		}
		console.log("User: "+ user +", type: "+ type);
		if(type == "img"){
        callback(null, baseDir+user+"/Photo");}
		else
		callback(null, baseDir+user+"/Video");
    },
    filename: function (req, file, callback) {
		var name = file.originalname;
		var user = name.substring(0,name.length-4);
		var type = name.replace(user+"_", "");
		if(type == "img"){
        callback(null, type + '_' + dateFormat(now, "ddmmyyyyhMMss")+".jpg");}
		else
        callback(null, type + '_' + dateFormat(now, "ddmmyyyyhMMss")+".mp4");
    }
});
	//check if map exist
	function fsMapExist(myDir) {
	  try {
		fs.accessSync(myDir);
		return true;
	  } catch (e) {
		return false;
	  }
}
	var upload = multer({ storage: storage }).single('file');
	app.post("/fileUpload", function(req, res){ //upload.single('file')
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

