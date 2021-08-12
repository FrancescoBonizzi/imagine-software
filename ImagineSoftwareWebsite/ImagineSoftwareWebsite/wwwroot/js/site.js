/*jshint esversion: 8 */
'use strict';

const isNullOrWhitespace = value => {

    if (!value)
        return true;

    if ((typeof (value) === 'string' && value.length <= 0))
        return true;

    return false;
};

const showElement = (element) => {
    element.style = 'display: block;';
};

const hideElement = (element) => {
    element.style = 'display: none;';
};

const showSuccess = (successContent) => {
    showElement(successContent);
};

const showError = (errorContent, message) => {
    if (!isNullOrWhitespace(message)) {
        errorContent.textContent = message;
        showElement(errorContent);
        window.scrollBy(0, 100);
    }
};

const hideError = (errorContent) => {
    errorContent.textContent = '';
    hideElement(errorContent);
};

const showLoadingAndHideMainContent = (loader, mainContent) => {
    showElement(loader);
    hideElement(mainContent);
    window.scrollTo(0, 100);
};

const hideLoader = function (loader, mainContent, hideMainContent = false) {
    hideElement(loader);

    if (!hideMainContent) {
        showElement(mainContent);
    }
};

const initializeBackToTopButton = () => {

    const btnBackToTop = document.getElementById('btnBackToTop');

    window.onscroll = () => {
        if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
            btnBackToTop.classList.add('back-to-top-button-visible');
        } else {
            btnBackToTop.classList.remove('back-to-top-button-visible');
        }
    };

};

const backToTop = () => {
    document.body.scrollTop = 0; // For Safari
    document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
};

const isElementInViewport = (el) => {

    const rect = el.getBoundingClientRect();
    return (
        (rect.top <= 0 && rect.bottom >= 0)
        || (rect.bottom >= (window.innerHeight || document.documentElement.clientHeight) && rect.top <= (window.innerHeight || document.documentElement.clientHeight))
        || (rect.top >= 0 && rect.bottom <= (window.innerHeight || document.documentElement.clientHeight))
    );

};

const initializeImagesAnimations = () => {

    const callback = function (entries) {

        entries.forEach(entry => {

            if (entry.isIntersecting) {
                entry.target.classList.add("is-visible");
            } else {
                entry.target.classList.remove("is-visible");
            }

        });

    };

    const observer = new IntersectionObserver(callback);
    const targets = document.querySelectorAll(".show-on-scroll");

    targets.forEach(function (target) {
        observer.observe(target);
    });

};
