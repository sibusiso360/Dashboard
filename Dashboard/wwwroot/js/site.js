
function updateModalValues(id,name)
{
    var ID = document.getElementById("0");
    var NAME = document.getElementById("1");

    ID.setAttribute("Value", id);
    NAME.setAttribute("Value", name);
}


function UsersUpdateModalValues(id, FirstName, LastName, Gender, PhoneNumber, Email)
{
    var ID = document.getElementById("NewUserid");
    var FIRSTNAME = document.getElementById("NewUserFirstName");
    var LASTNAME = document.getElementById("NewUserLastName");
    var GENDER = document.getElementById("NewUserGender");
    var PHONE = document.getElementById("NewUserPhoneNumber"); 
    var EMAIL = document.getElementById("NewUserEmail"); 

    ID.setAttribute("Value", id);
    FIRSTNAME.setAttribute("Value", FirstName);
    LASTNAME.setAttribute("Value", LastName);
    GENDER.setAttribute("Value", Gender);
    PHONE.setAttribute("Value", PhoneNumber);
    EMAIL.setAttribute("Value", Email);
}

