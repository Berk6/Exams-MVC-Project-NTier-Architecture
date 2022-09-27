function selectAnswer(answerId) {
    let elementAnswer = document.querySelectorAll(`#A_${answerId},#B_${answerId},#C_${answerId},#D_${answerId},#E_${answerId}`)
    let trueAnswer = document.getElementById(`TrueAnswer_${answerId}`)
    for (let i = 0; i < elementAnswer.length; i++) {
        if (elementAnswer[i].value == trueAnswer.value) {
            elementAnswer[i].setAttribute("style", "color:red;");
        }
        else {
            elementAnswer[i].removeAttribute("style", "color:red;");
        }
    }
}
function clickFunc(answerId, value) {
    $(`#TrueAnswer_${answerId}`).val(value);
    selectAnswer(answerId);
}