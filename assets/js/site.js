/*jshint esversion: 8 */
'use strict';

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
