$(document).ready(function(){
    $("button").click(function(){
    	var StartPointNameValue = document.getElementById("StartPointTextBoxID");
    	var EndPointNameValue = document.getElementById("EndPointTextBoxID");

    	$.get("webapi/"+StartPointNameValue.value +"~"+ EndPointNameValue.value+".php", function(data, status){
            $("#XMLResponseArea").text(data);
        });
    });
});