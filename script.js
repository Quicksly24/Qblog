document.addEventListener('DOMContentLoaded', function () {

    const apiBaseUrl = 'http://localhost:5105'

    function getAllPost() {
        const apiEndpoint = '/api/Post';

        fetch(apiBaseUrl + apiEndpoint)
            .then(response => response.json())
            .then(data => displayData(data))
            .catch(error => console.error('Error fetching data:', error));
    }

    function displayData(data) {
        const dataList = document.getElementById('api-data-list');
        dataList.innerHTML = '';

        data.forEach(item => {
            const listItem = document.createElement('li');
            listItem.textContent = `ID: ${item.id}, Title: ${item.title}, Content: ${item.content}`;
            dataList.appendChild(listItem);
        });
    }

    // Trigger the fetch when the page is loaded
    getAllPost();
});
