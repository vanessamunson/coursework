let screenContent = document.getElementById('screenContent');
const buttonElems = document.getElementsByTagName('button');
const buttons = Array.from(buttonElems);
let equation = '';

const clearScreen = () => {
    equation = '';
    screenContent.innerHTML = '';
}

buttons.forEach((button) => {
    const id = button.id;
    if (id === 'C') {
        document.getElementById(id).addEventListener('click', () => {
            clearScreen();
        }); 
    } else if (id === '=') {
        document.getElementById(id).addEventListener('click', () => {
            const answer = eval(equation);
            screenContent.innerHTML = `${answer}`;
            equation = answer;
        }); 
    } else {
        document.getElementById(id).addEventListener('click', () => {
            equation = equation + id;
            screenContent.innerHTML = `${equation}`;
        }); 
    }
});
