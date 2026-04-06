const IPSTACK_API_KEY = '98425cb5dddb8c3b615aa4ffc38243f5';
let responseSection = document.getElementById('response-section');

async function getData() {
    responseSection.innerHTML = '';
    const ipAddress = document.getElementById('ip').value;

    try {
        const response = await fetch(
        `https://api.ipstack.com/${ipAddress}?access_key=${IPSTACK_API_KEY}`
        );

        const data =  await response.json();
        const table = document.createElement('table');

        for (const key in data) {
            const tr = document.createElement('tr');

            const keyTd = document.createElement('td');
            keyTd.innerHTML = `<strong class='key'>${key.replace('_', ' ').toUpperCase()}:</strong>`;

            const valueTd = document.createElement('td');

            switch (key) {
                case 'location':
                    valueTd.textContent = data[key].country_flag_emoji;
                    break;
                case 'time_zone':
                    valueTd.innerText = data[key].code;
                    break;
                case 'currency':
                    valueTd.innerText = data[key].name;
                    break;
                case 'connection':
                    valueTd.innerText = data[key].isp;
                    break;
                default:
                    valueTd.innerText = data[key];
            }
            
            tr.append(keyTd, valueTd);
            table.appendChild(tr);
        }

        responseSection.append(table);

    } catch (error) {
        console.error(error);
    }
}

document.getElementById('search').addEventListener('click', () => {
    getData();
});
