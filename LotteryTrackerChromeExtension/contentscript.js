
var resultsIframe; 
var i = 0;
var previousDaysCount = 0;

function levantarTodo() {
    
    resultsIframe = $('body>center>table>tbody>tr>td>table>tbody>tr:nth-child(3)>td:nth-child(2)>table>tbody>tr:nth-child(2)>td>table>tbody>tr>td:nth-child(4)>iframe');    
        
    function getPreviousDayResults() {
        if (i < previousDaysCount ){
            i++;
            //Save winner numbers
            resultsIframe.contents().find("form")[0].submit();
        }
    }    
    
    resultsIframe.ready(function() {                    
        resultsIframe.bind("load", getPreviousDayResults);            
        resultsIframe[0].contentWindow.location.reload(true);        
    });    
}

function mensajesListener(request, sender, sendResponse) {        
    previousDaysCount = request.daysCount;    
    levantarTodo();    
}

chrome.runtime.onMessage.addListener(mensajesListener);