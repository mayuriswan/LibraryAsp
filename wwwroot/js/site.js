// wwwroot/js/site.js

// ... (other functions or scripts)

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.start().then(function () {
    console.log('Connection to hub established!');
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on('ReceiveMessage', function (username, message) {
    console.log('Message received:', message);

    // Add the message to the container on the page
    var chatContainer = document.getElementById('chat-messages-container');
    var newMessageElement = document.createElement('div');
    newMessageElement.textContent = username + ': ' + message; // Use the username and message text
    chatContainer.appendChild(newMessageElement);
});

function sendMessage(event) {
    event.preventDefault();

    // Retrieve the message from the form
    var messageInput = document.getElementById('message-input');
    var message = messageInput.value;

    // Validate that the message is not empty before sending
    if (message.trim() === '') {
        console.error('Message cannot be empty.');
        return;
    }

    // Retrieve the username from the #chat-form-container element
    var chatFormContainer = document.getElementById('chat-form-container');
    var username = chatFormContainer.getAttribute('data-username');

    // Send the message to the hub
    connection.invoke('SendMessageToAll', username, message).catch(function (err) {
        return console.error(err.toString());
    });

    // Clear the input field after sending the message
    messageInput.value = '';
}

// Function to toggle the chat form
function toggleChatForm() {
    var chatFormContainer = document.getElementById('chat-form-container');
    chatFormContainer.classList.toggle('hidden');
}
