
function updateModalValues(id,name)
{
    var ID = document.getElementById("0");
    var NAME = document.getElementById("1");

    ID.setAttribute("Value", id);
    NAME.setAttribute("Value", name)

    console.log(ID, name);

}
