document.getElementById('calculate-button').addEventListener('click', () => {
    const income = Number(document.getElementById('income').value);
    const tax = document.getElementById('tax');
    let output = '';

    if (income > 0 && income <= 9275) {
        output = (income * 0.10).toFixed(2);
    } else if (income > 9275 && income <= 37650) {
        output = (927.50 + (income - 9275) * 0.15).toFixed(2);
    } else if (income > 37650 && income <= 91150) {
        output = (5183.75 + (income - 37650) * 0.25).toFixed(2);
    } else if (income > 91150 && income <= 190150) {
        output = (18558.75 + (income - 91150) * 0.28).toFixed(2);
    } else if (income > 190150 && income <= 413350) {
        output = (46278.75 + (income - 190150) * 0.33).toFixed(2);
    } else if (income > 413350 && income <= 415050) {
        output = (119934.75 + (income - 413350) * 0.35).toFixed(2);
    } else if (income > 415050) {
        output = (120529.75 + (income - 415050) * 0.396).toFixed(2);
    } else {
        output = 'error';
    }

    tax.value = output;
});
