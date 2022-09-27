window.onload = changeAnswer;
function changeAnswer() {
    let elementAnswer = document.querySelectorAll(`#A,#B,#C,#D,#E`)
    let trueAnswer = document.getElementById(`TrueAnswer`)
    for (let i = 0; i < elementAnswer.length; i++) {
        if (elementAnswer[i].innerHTML == trueAnswer.value) {
            elementAnswer[i].setAttribute("style", "color:red;");
        }
        else {
            elementAnswer[i].removeAttribute("style", "color:red;");
        }
    }
}
function clickFunc(answerId) {
    $("#TrueAnswer").val(answerId);
    changeAnswer();
}