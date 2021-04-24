// TODO
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
'use strict';

const isNullOrWhitespace = value => {

    if (!value)
        return true;

    if ((typeof (value) === 'string' && value.length <= 0))
        return true;

    return false;
}

const isEmailValid = email => {

    if (isNullOrWhitespace(email))
        return false;

    const regex = /^\S+@\S+$/;
    return regex.test(String(email).toLowerCase());
}

const showElement = (element) => {
    element.style = 'display: block;';
}

const hideElement = (element) => {
    element.style = 'display: none;';
}

const showSuccess = (successContent) => {
    showElement(successContent);
    window.scrollTo(0, 0);
}

const showError = (errorContent, message) => {
    if (!isNullOrWhitespace(message)) {
        errorContent.textContent = message;
        showElement(errorContent);
        errorContent.scrollIntoView();
    }
}

const hideError = (errorContent) => {
    errorContent.textContent = '';
    hideElement(errorContent);
}

const showLoadingAndHideMainContent = (loader, mainContent) => {
    showElement(loader);
    hideElement(mainContent);
}

const hideLoader = function (loader, mainContent, hideMainContent = false) {
    hideElement(loader);

    if (!hideMainContent) {
        showElement(mainContent);
    }
}

class contactPage {

    constructor() {

        this.view.btnContactSubmit = document.getElementById('btnContactSubmit');
        this.view.btnResetForm = document.getElementById('btnResetForm');
        this.view.txtName = document.getElementById('txtName');
        this.view.txtEmail = document.getElementById('txtEmail');
        this.view.txtMessage = document.getElementById('txtMessage');
        this.view.chkPrivacy = document.getElementById('chkPrivacy');
        this.view.successContent = document.getElementById('success-content');
        this.view.errorContent = document.getElementById('error-content');
        this.view.loader = document.getElementById('loader');
        this.view.mainContent = document.getElementById('main-content');
        this.view.contactForm = document.getElementById('contact-form');

        const me = this;
        this.view.btnContactSubmit.addEventListener('click', function (event) {

            // Don't follow the link
            event.preventDefault();
            me.sendMessage();

        }, false);

        this.view.btnResetForm.addEventListener('click', function (event) {

            // Don't follow the link
            event.preventDefault();
            me.resetForm();

        }, false);
    }

    view = {}

    async sendMessage() {

        try {

            hideError(this.view.errorContent);
            const message = this.getMessage();

            try {

                this.validateMessage(message);
                showLoadingAndHideMainContent(this.view.loader, this.view.mainContent);

                const result = await fetch(
                    'api/send-contact-message',
                    {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(message)
                    });

                if (!result.ok) {
                    console.error("🐝🐝🐝 ", result);
                    const body = await result.text();
                    throw body || 'Si è verificato un errore non previsto. Sto già indagando!';
                }

                hideLoader(this.view.loader, this.view.mainContent, true);
                showSuccess(this.view.successContent);

            }
            catch (ex) {
                hideLoader(this.view.loader, this.view.mainContent, false);
                showError(this.view.errorContent, ex);
                console.error("🔥🔥🔥 " + ex);
            }

        } catch (genericEx) {
            hideLoader(this.view.loader, this.view.mainContent, false);
            showError(this.view.errorContent, 'Si è verificato un errore non previsto. Sto già indagando!');
            console.error("🔥🔥🔥 " + genericEx);
        }

    }

    resetForm() {
        this.view.contactForm.reset();
        hideElement(this.view.successContent);
        this.view.mainContent.style = ""; // Lo resetto semplicemente a com'era prima, così usa il CSS
        this.view.mainContent.scrollIntoView();
    }

    getMessage() {
        return {
            name: this.view.txtName.value,
            email: this.view.txtEmail.value,
            message: this.view.txtMessage.value,
            privacyAccepted: this.view.chkPrivacy.checked
        }
    }

    validateMessage(message) {

        if (isNullOrWhitespace(message.name))
            throw 'Inserisci per favore il tuo nome';

        if (isNullOrWhitespace(message.email))
            throw 'Inserisci per favore il tuo indirizzo email, così che possa risponderti!';

        if (!isEmailValid(message.email))
            throw 'C\'è qualcosa che non quadra nell\'indirizzo email che hai inserito!';

        if (isNullOrWhitespace(message.message))
            throw 'Inserisci per favore un messaggio, altrimenti non a cosa rispondere!';

        if (!message.privacyAccepted)
            throw 'Non posso inviare il messaggio se non accetti l\'informativa sulla privacy. Grazie!';

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
    }

}

const backToTop = () => {
    document.body.scrollTop = 0; // For Safari
    document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
};