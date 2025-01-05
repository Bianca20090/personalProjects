const navLinks = document.getElementById("navLinks");

function showMenu() {
    navLinks.style.right = "0";
}
function hideMenu() {
    navLinks.style.right = "-200px";
}



function toggleSubMenu() {
    const expandedSubMenu = document.querySelector(".mobile-submenu");
    if (expandedSubMenu.style.display === "block") {
        expandedSubMenu.style.display = "none";
    } else {
        expandedSubMenu.style.display = "block";
    }
}


function toggleTable() {
    const blurBackground = document.getElementById('blur-background');
    const iframeContainer = document.getElementById('iframe-container');
    const displayStyle = blurBackground.style.display;

    if (displayStyle === 'none' || displayStyle === '') {
        blurBackground.style.display = 'block';
        iframeContainer.style.display = 'block';
    } else {
        blurBackground.style.display = 'none';
        iframeContainer.style.display = 'none';
    }
}



function showCalculator() {
    const blurBackground = document.getElementById('blur-background');
    const iframeContainerC = document.getElementById('iframe-containerC');
    blurBackground.style.display = 'block';
    iframeContainerC.style.display = 'block';
}

function closeCalculator() {
    const blurBackground = document.getElementById('blur-background');
    const iframeContainerC = document.getElementById('iframe-containerC');
    blurBackground.style.display = 'none';
    iframeContainerC.style.display = 'none';
}

const contactButton = document.querySelector('.buton-1');




//aici pt log in

const conectareSection= document.querySelector('.conectareSection');
const conLinkLog= document.querySelector('.log-link');
const conLinkReg= document.querySelector('.reg-link');

conLinkReg.addEventListener('click', ()=>{
    conectareSection.classList.add('active');
});

conLinkLog.addEventListener('click', ()=>{
    conectareSection.classList.remove('active');
});

const closeIcon = document.getElementById('closeIcon');

closeIcon.addEventListener('click', () => {
    window.location.href = 'home.html';
});

const closeIcon2 = document.getElementById('closeIcon2');

closeIcon2.addEventListener('click', () => {
    window.location.href = 'home.html';
});

function afiseazaFormular() {
    document.getElementById('blur-overlay').style.display = 'block';
    document.getElementById('formular-container').style.display = 'block';
}

function ascundeFormular() {
    document.getElementById('blur-overlay').style.display = 'none';
    document.getElementById('formular-container').style.display = 'none';
}