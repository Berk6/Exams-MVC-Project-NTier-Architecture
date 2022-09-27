let cbCheck = parameter => {
    let firstCb = document.getElementById(`${parameter}`)
    let secondCb = document.getElementById(`s${parameter}`)
    if (firstCb.checked == true) {
        secondCb.checked = true
    }
    else {
        secondCb.checked = false
    }
}
let toggle = button => {
    let element = document.getElementById(`a${button}`);
    let buttonDOM = document.getElementById(`${button}`)
    let hidden = element.getAttribute("hidden");
    if (hidden) {
        element.removeAttribute("hidden");
        buttonDOM.innerText = "Teste Girecekleri Gizle";
    } else {
        element.setAttribute("hidden", "hidden");
        buttonDOM.innerText = "Teste Girecekleri Görüntüle";
    }
}
let checkFalse = document.getElementsByClassName("questFalse");
for (var i = 0; i < checkFalse.length; i++) {
    checkFalse[i].checked = false;
}
let question = button => {
    let element = document.getElementById(`All${button}`);
    let buttonDOM = document.getElementById(`${button}`)
    let hidden = element.getAttribute("hidden");

    if (hidden) {
        element.removeAttribute("hidden");
        buttonDOM.innerText = "Soruları Gizle";
    } else {
        element.setAttribute("hidden", "hidden");
        buttonDOM.innerText = "Soruları Görüntüle";
        for (var i = 0; i < checkFalse.length; i++) {
            checkFalse[i].checked = false;
        }
    }
}
let test = button => {
    document.getElementById(`t${button}`).checked = true;
}