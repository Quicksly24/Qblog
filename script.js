document.addEventListener('DOMContentLoaded', function () {
    const apiBaseUrl = 'http://localhost:5105';

    function getAllPost() {
        const apiEndpoint = '/api/Post';

        fetch(apiBaseUrl + apiEndpoint)
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                return response.json();
            })
            .then(data => displayData(data))
            .catch(error => console.error('Error fetching data:', error));
    }

    function displayData(data) {
        console.log(data);
        const dataList = document.getElementById('api-data-list');
        dataList.innerHTML = '';

        data.forEach(item => {
            const listItem = document.createElement('li');
            listItem.textContent = `ID: ${item.id}, Username: ${item.username} Title: ${item.title}, Body: ${item.body}`;
            dataList.appendChild(listItem);
        });
    }

    
    getAllPost();
});
