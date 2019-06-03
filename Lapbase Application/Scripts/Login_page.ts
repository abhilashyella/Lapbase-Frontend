class Login_Page {

    login() {

        var a = 0;

        var txtuname = (<HTMLTextAreaElement>(document.getElementById('txtuname'))).value;

        var txtpwd = (<HTMLTextAreaElement>(document.getElementById('Pwd'))).value;



        if (txtuname.length != 0 && txtpwd.length != 0) {

           
         

        }

        else {

            alert("Please Enter Username and Password ");

        }

    }

  
    openFrgtpswd() {

    }

}



window.onload = () => {

    var bttn = document.getElementById("login");

    var obj = new Login_Page();

    bttn.onclick = function () {

        obj.login();

    }

    var bttfrgtpswd = document.getElementById("frgtpswd");

    bttfrgtpswd.onclick = function () {

        obj.openFrgtpswd();

    }

};