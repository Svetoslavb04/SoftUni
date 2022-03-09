import { displayNav } from './navbar.js'

let containerDiv = document.getElementById('container');
let homeSection = document.getElementById('home-page');


export function displayHome() {
    displayNav();
    
    containerDiv.appendChild(homeSection);
}