(function () {
  "use strict";

  angular.module('bddgen')
    .component('storySelector', {
      templateUrl: '/app/storySelector/storySelector.template.html',
      controller: [StorySelectorController],
      bindings: {
        suite: '='
      }
    });

  function StorySelectorController() {
    var vm = this;
    vm.$onInit = onInit;


    function onInit() {
      vm.activeStory = vm.suite.Stories[0];
    }
  }
})();