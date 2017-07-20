var i = 0;
function buscarDeNuevo() {
    if (i < 5 ){
        i++
        var referencia = $('body>center>table>tbody>tr>td>table>tbody>tr:nth-child(3)>td:nth-child(2)>table>tbody>tr:nth-child(2)>td>table>tbody>tr>td:nth-child(4)>iframe');
        referencia.ready(function() {
            referencia.contents().find("form")[0].submit();
        });
    }
}


var referencia;
referencia = $('body>center>table>tbody>tr>td>table>tbody>tr:nth-child(3)>td:nth-child(2)>table>tbody>tr:nth-child(2)>td>table>tbody>tr>td:nth-child(4)>iframe');
referencia.ready(function() {    
    referencia.bind("load", buscarDeNuevo);
    referencia.contents().find("form")[0].submit();
});