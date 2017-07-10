(function () {
  angular.module('bddgen')
    .run(xeditableOptions);

  function xeditableOptions(editableOptions) {
    editableOptions.theme = 'bs3'
  }
})();