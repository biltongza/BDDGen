(function () {
  "use strict";
  angular.module('bddgen')
    .component('storyView', {
      templateUrl: '/app/storyView/storyView.template.html',
      controller: [StoryViewController],
      bindings: {
        story: '='
      }
    });

  function StoryViewController() {
    var vm = this;

    vm.$onInit = onInit;

    function onInit() {

    }
  }
})();