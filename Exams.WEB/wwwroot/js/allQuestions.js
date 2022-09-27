let question = button => {
    let element = document.querySelectorAll(`#Amod_${button},#Bmod_${button},#Cmod_${button},#Dmod_${button},#Emod_${button}`);
    let element2 = document.querySelectorAll(`#AAmod_${button},#BBmod_${button},#CCmod_${button},#DDmod_${button},#EEmod_${button}`);
    let hidden = element[0].getAttribute("hidden");
    if (hidden) {
        for (let i = 0; i < element.length; i++) {
            element[i].removeAttribute("hidden");
            element2[i].removeAttribute("hidden");
        }
        let elementAnswer1 = document.getElementById(`Aanswer_${button}`)
        let hidden2 = elementAnswer1.getAttribute("hidden");
        if (!hidden2) {
            changeQuest(button);
        }
    }
    else {
        for (let i = 0; i < element.length; i++) {
            element[i].setAttribute("hidden", "hidden");
            element2[i].setAttribute("hidden", "hidden");
        }
    }
    trig(hidden, button);
}
let trig = (hidden, button) => {
    let buttonDOM = document.getElementById(`mod_${button}`);
    if (hidden) {
        buttonDOM.innerText = "Cevapları Gizle";
    }
    else {
        buttonDOM.innerText = "Cevapları Görüntüle";
    }
}
let resetButtonColor;
let trig2 = (hidden, index) => {
    let buttonDOM = document.getElementById(`changeBtn_${index}`);
    if (hidden) {
        buttonDOM.innerText = "Düzenlemeden Vazgeç";
    }
    else {
        buttonDOM.innerText = "Soruyu Düzenle";
        resetButtonColor.removeAttribute("style", "color:red;");
        document.getElementById(`ChangeForm_${index}`).reset();
    }
}
let changeQuest = prmtr => {
    let elementQuest = document.getElementById(`question_${prmtr}`)
    let elementQuest1 = document.getElementById(`Question_${prmtr}`)
    let elementSaveBtn = document.getElementById(`saveBtn_${prmtr}`)
    let elementAnswer = document.querySelectorAll(`#Aanswer_${prmtr},#Banswer_${prmtr},#Canswer_${prmtr},#Danswer_${prmtr},#Eanswer_${prmtr}`)
    let elementOption = document.querySelectorAll(`#Aoption_${prmtr},#Boption_${prmtr},#Coption_${prmtr},#Doption_${prmtr},#Eoption_${prmtr}`)
    let hidden = elementQuest.getAttribute("hidden");

    if (hidden) {
        elementQuest1.setAttribute("hidden", "hidden");
        elementQuest.removeAttribute("hidden");
        elementSaveBtn.removeAttribute("hidden");
        let trueAnswer = document.getElementById(`trueAnswer_${prmtr}`)
        for (let i = 0; i < elementAnswer.length; i++) {
            elementAnswer[i].removeAttribute("hidden");
            elementOption[i].removeAttribute("hidden");
            if (elementOption[i].innerHTML == trueAnswer.value) {
                elementOption[i].setAttribute("style", "color:red;");
            }
        }
        let element = document.getElementById(`Amod_${prmtr}`);
        let hidden2 = element.getAttribute("hidden");
        if (!hidden2) {
            question(prmtr)
        }
    }
    else {
        elementQuest1.removeAttribute("hidden");
        elementQuest.setAttribute("hidden", "hidden");
        elementSaveBtn.setAttribute("hidden", "hidden");
        for (let i = 0; i < elementAnswer.length; i++) {
            elementAnswer[i].setAttribute("hidden", "hidden");
            elementOption[i].setAttribute("hidden", "hidden");
        }
    }
    trig2(hidden, prmtr)
}
let clickFunc = (opt, prmtr) => {
    let trueAnswer = document.getElementById(`trueAnswer_${prmtr}`)
    let allOption = document.querySelectorAll(`#Aoption_${prmtr},#Boption_${prmtr},#Coption_${prmtr},#Doption_${prmtr},#Eoption_${prmtr}`)
    let option = document.getElementById(`${opt}option_${prmtr}`)
    for (let i = 0; i < allOption.length; i++) {
        if (option == allOption[i]) {
            allOption[i].setAttribute("style", "color:red;");
            resetButtonColor = allOption[i]
        }
        else {
            allOption[i].removeAttribute("style", "color:red;");
        }
    }
    trueAnswer.value = opt;
}
function auto_grow(element) {
    element.style.height = "5px";
    element.style.height = (element.scrollHeight) + "px";
}