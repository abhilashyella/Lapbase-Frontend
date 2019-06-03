var Login_Page = /** @class */ (function () {
    function Login_Page() {
    }
    Login_Page.prototype.login = function () {
        var a = 0;
        var txtuname = (document.getElementById('txtuname')).value;
        var txtpwd = (document.getElementById('Pwd')).value;
        if (txtuname.length != 0 && txtpwd.length != 0) {
        }
        else {
            alert("Please Enter Username and Password ");
        }
    };
    Login_Page.prototype.openFrgtpswd = function () {
    };
    return Login_Page;
}());
window.onload = function () {
    var bttn = document.getElementById("login");
    var obj = new Login_Page();
    bttn.onclick = function () {
        obj.login();
    };
    var bttfrgtpswd = document.getElementById("frgtpswd");
    bttfrgtpswd.onclick = function () {
        obj.openFrgtpswd();
    };
};
//# sourceMappingURL=Login_page.js.map