var resultsIframe = $('body>center>table>tbody>tr>td>table>tbody>tr:nth-child(3)>td:nth-child(2)>table>tbody>tr:nth-child(2)>td>table>tbody>tr>td:nth-child(4)>iframe');

var i = 0;
function getPreviousDayResults() {
    if (i < 5 ){
        i++;
        //Save winner numbers
        resultsIframe.contents().find("form")[0].submit();
    }
}

resultsIframe.ready(function() {            
    resultsIframe.bind("load", getPreviousDayResults);
    resultsIframe.contentWindow.location.reload(true);
});