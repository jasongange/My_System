(function () {

    'use strict';

    angular.module('mainApp').factory('CustomService', CustomService);

    //CustomService.$inject = [];

    function CustomService() {

        var spokenWord = '';

        var customServices = {
            clearInputText: clearInputText,
            speak: speak
        };
        return customServices;

        //private function
        function returnSpokenWorkds(word) {

            return spokenWord;
        }
        function speak(word) {
            var spokenWord = returnSpokenWorkds(word);
            console.log(spokenWord)
            return spokenWord;
        }
        function clearInputText(elementId, inputType) {

            var element = angular.element(document.querySelector(elementId));

            element.find(':input').each(function () {

                switch (inputType) {

                    case 'text':
                        $(this).val('');
                    case 'password':
                        $(this).val('');
                }
            });
        }
    }
})();