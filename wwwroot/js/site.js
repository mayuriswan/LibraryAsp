﻿// wwwroot/js/site.js




// D'autres fonctions ou scripts pertinents peuvent être ajoutés ici

// Dans votre script JavaScript
function sendMessage(event) {
    // Implémentez la logique d'envoi du message ici
    event.preventDefault(); // Assurez-vous d'annuler le comportement par défaut du formulaire si nécessaire
    console.log('Message sent!');
}



// Dans votre script JavaScript
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.start().then(function () {
    console.log('Connection to hub established!');
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on('ReceiveMessage', function (message) {
    console.log('Message received:', message);

    // Ajouter le message au conteneur sur la page
    var chatContainer = document.getElementById('chat-container');
    var newMessageElement = document.createElement('div');
    newMessageElement.textContent = message.text; // Utilisez le texte du message ici
    chatContainer.appendChild(newMessageElement);
});