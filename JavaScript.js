function ShowMsg(titulo, texto) {

    document.getElementById("cxFloatMsg").style.display = "block";
    document.getElementById("msgTitulo").innerText = titulo;
    document.getElementById("msgText").innerText = texto;
}

function HideMsg() {
    document.getElementById("cxFloatMsg").style.display = "none";
}