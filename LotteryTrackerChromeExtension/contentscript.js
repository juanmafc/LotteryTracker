$("body").append('Test');

//$("Action").submit($("ultimo"));
/*
console.log("2 vez?");
$('Action').val('TESTING');
console.log("2 vez?");
*/
/*
var referencia = $('#Action');
console.log(referencia);
referencia.attr("value", "LCDTMAB");
$("#form1").submit($("ultimo"));
*/
var referencia;
console.log(referencia);
console.log(document);
//referencia = document.getElementsByTagName("form1");



//referencia = document.getElementsById("/htmlbody/center/table/tbody/tr/td/table/tbody/tr[3]/td[2]/table/tbody/tr[2]/td/table/tbody/tr/td[3]/iframe");
referencia = $('body>center>table>tbody>tr>td>table>tbody>tr:nth-child(3)>td:nth-child(2)>table>tbody>tr:nth-child(2)>td>table>tbody>tr>td:nth-child(4)>iframe');
//referencia.click();

console.log(referencia);
window.clearTimeout(1000);
console.log("Prueba");
var prueba = referencia.contents().find("form")[0];
console.log(prueba);
prueba.submit();
//Hasta aca funciona a veces si y a veces no, debe ser porque no es asincronico

/*
console.log(referencia);
var iframe = referencia[0];
console.log(iframe);
window.clearTimeout(600);
var iframeDocument = iframe.contentWindow.document;
console.log(iframeDocument);
//var buttonAction = iframeDocument;
//console.log(buttonAction);

*/