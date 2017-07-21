
var resultsIframe; 
var i = 0;
var previousDaysCount = 0;

function levantarTodo() {

    console.log("Se entro a levantar todo");
    resultsIframe = $('body>center>table>tbody>tr>td>table>tbody>tr:nth-child(3)>td:nth-child(2)>table>tbody>tr:nth-child(2)>td>table>tbody>tr>td:nth-child(4)>iframe');    
    console.log(resultsIframe);
    console.log("JQuery murio?");

    function getPreviousDayResults() {
        if (i < previousDaysCount ){
            i++;
            //Save winner numbers
            resultsIframe.contents().find("form")[0].submit();
        }
    }
    console.log("Se definio la funcion");
    
    resultsIframe.ready(function() {            
        console.log("Se entro al ready");
        resultsIframe.bind("load", getPreviousDayResults);
        console.log("el bind no explota");
        //console.log(resultsIframe);
        //console.log(resultsIframe[0].contentWindow);
        resultsIframe[0].contentWindow.location.reload(true);
        console.log("el reload?");
    });

    console.log("Se cargo el ready");
}

function mensajesListener(request, sender, sendResponse) {        
    previousDaysCount = request.daysCount;    
    levantarTodo();    
}

chrome.runtime.onMessage.addListener(mensajesListener);