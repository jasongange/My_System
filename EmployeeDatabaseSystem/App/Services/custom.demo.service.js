(function () {

    'use strict';

    angular.module('mainApp').service('DemoService', DemoService);

    //CustomService.$inject = [];

    function DemoService() {

        var _self = this;

        _self.sample = 'sample';

        _self.speak = function speak(word) {

            var spokenWord = returnSpokenWorkds(word);
            console.log(spokenWord);
            return spokenWord;

        }

        function returnSpokenWorkds(word) {

            var spokenWord = '';

            return spokenWord;
        }

        _self.clearInputText = function clearInputText(elementId, inputType) {

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