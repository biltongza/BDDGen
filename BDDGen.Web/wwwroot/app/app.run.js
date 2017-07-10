(function () {
  "use strict";
  angular.module('bddgen')
    .run(['editableOptions',xeditableOptions]);

  function xeditableOptions(editableOptions) {
    editableOptions.theme = 'bs3'
  }
})();