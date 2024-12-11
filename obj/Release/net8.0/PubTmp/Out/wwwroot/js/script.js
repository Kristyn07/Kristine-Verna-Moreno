// #region Navigation layout

var colElement = document.querySelector('.mode');
var justifyElement = document.querySelector('.mode .d-flex');

function detectMobile() {
    return window.innerWidth <= 768; // Considered mobile for screens <= 768px
}
function updateNavOnMobile() {
    if (colElement) {
        colElement.classList.remove('col-2'); // Remove col-2 on mobile
    }
    if (justifyElement) {
        justifyElement.classList.remove('justify-content-end'); // Remove the right-aligned class
        justifyElement.classList.add('justify-content-center'); // Center the content
    }
}

function updateNavOnLargerScreen() {
    if (colElement) {
        colElement.classList.add('col-2'); // Re-add col-2 on larger screens
    }
    if (justifyElement) {
        justifyElement.classList.add('justify-content-end'); // Align to the right for larger screens
        justifyElement.classList.remove('justify-content-center'); // Remove center alignment
    }
}
function updateLayoutBasedOnScreenSize() {
    if (detectMobile()) {
        updateNavOnMobile(); 
    } else {
        updateNavOnLargerScreen(); 
    }
}

window.onload = updateLayoutBasedOnScreenSize;
window.onresize = updateLayoutBasedOnScreenSize;
// #endregion

//#region Color THEME BTN
document.addEventListener('DOMContentLoaded', function () {
    const savedTheme = localStorage.getItem('theme') || 'light';
    document.body.setAttribute('data-bs-theme', savedTheme);

    updateButtonVisibility(savedTheme);

    document.getElementById("toggle-light").addEventListener("click", function () {
        document.body.setAttribute('data-bs-theme', 'dark');
        localStorage.setItem('theme', 'dark');
        updateButtonVisibility('dark');
    });

    document.getElementById("toggle-dark").addEventListener("click", function () {
        document.body.setAttribute('data-bs-theme', 'light');
        localStorage.setItem('theme', 'light');
        updateButtonVisibility('light');
    });
});

function updateButtonVisibility(theme) {
    if (theme === 'dark') {
        document.getElementById("toggle-light").style.display = 'none';
        document.getElementById("toggle-dark").style.display = 'block';
    } else {
        document.getElementById("toggle-light").style.display = 'block';
        document.getElementById("toggle-dark").style.display = 'none';
    }
}
//#endregion

//#region trigger the animation on scroll for LINE on Title
const lines = document.querySelectorAll('.line');

lines.forEach(line => {
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                line.classList.add('animate-line');
            } else {
                line.classList.remove('animate-line');
            }
        });
    }, {
        threshold: 0.1
    });
    observer.observe(line);
});
//#endregion

//#region close nav when clicked outsite
// Get all navigation links inside the #main-nav div
const navLinks = document.querySelectorAll('#main-nav .nav-link');
const mainNav = document.getElementById('main-nav');

// Add a click event listener to each link
navLinks.forEach(link => {
    link.addEventListener('click', () => {
        // Collapse the navbar by removing the 'show' class
        mainNav.classList.remove('show');
    });
});
//#endregion

//#region Submit Form
var submitButton = document.getElementById('submit-btn');
var loading = document.getElementsByClassName('load')[0];

function dissableButton() {
    submitButton.disabled = true; 
    submitButton.style.display = 'none';
    loading.style.display = 'inline-block'; 

}
function enableButton() {
    submitButton.disabled = false; 
    submitButton.style.display = 'inline-block';  
    loading.style.display = 'none'; 

}

function submitForm() {
    event.preventDefault();
    dissableButton();

    var formData = new FormData(document.getElementById('my-contact-form'));

    // Create AJAX request
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/Home/Index", true);
    xhr.onload = function () {
        enableButton();
        if (xhr.status === 200) {//sucess
            document.getElementById('my-contact-form').reset();
            alert("Your message has been sent successfully!");

        } else {//error
            alert("There was an error sending your message. Please try again.");
        }
    };
    xhr.onerror = function () {
        alert("Request failed. Please try again.");
    };
    

    xhr.send(formData);
}

//#endregion



