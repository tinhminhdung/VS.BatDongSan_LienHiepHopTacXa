function openWindow(filename, winname, width, height) {
    var features, top, left;
    left = (window.screen.width - width) / 2;
    top = (window.screen.height - height) / 2;
    features = "width=" + width + ",height=" + height + ",top=" + top + ",left=" + left;
    void (window.open(filename, winname, features));
    window.location.href = "/";
}

//------------------
//Đạo phật
//App ID:	1380898228816966
//App Secret:	f51ab0451ce4f30a3df5654d38cdd35b(đặt lại)
//https: //developers.facebook.com/apps/
//-------------------

//Su dung cho facebook
//simgiare4g vaf hopnhat

//var appID = "1775909969332531";
var appID = "1775909969332531";
var redirectURL = "http://localhost:22271/Facebook.aspx";  //url se tra lai sau khi dang nhap thanh cong, luu y url nay phai trung khop khi cau hinh app tren facebook
var stateValue = "0";  //ko can thiet
var scope = "email,public_profile"; //day la nhung thong tin mo rong, nhung thong tin basic van dc lay kem theo http://developers.facebook.com/docs/authentication/permissions/
var responseType = "token"; //token or code, default=code
var display = "popup";  //popup,page,touch 
var linkFaceBook = "http://www.facebook.com/dialog/oauth?client_id=" + appID + "&redirect_uri=" + redirectURL + "&state=" + stateValue + "&scope=" + scope + "&response_type=" + responseType + "&display=" + display;


//id,name,first_name,last_name,age_range,link,gender,locale,timezone,updated_time,verified