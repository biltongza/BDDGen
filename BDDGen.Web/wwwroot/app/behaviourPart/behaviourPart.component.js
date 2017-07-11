(function () {
  "use strict";
  angular.module('bddgen')
    .component('behaviourPart', {
      templateUrl: '/app/behaviourPart/behaviourPart.template.html',
      controller: BehaviourPartController,
      bindings: {
        behaviour: '='
      }
    });

  function BehaviourPartController() {
    const vm = this;

    vm.newPart = newPart;
    vm.removePart = removePart;

    function removePart(index) {
      if (index > -1) {
        vm.behaviour.parts.splice(index, 1);
      }
    }

    function newPart() {
      vm.behaviour.parts.push('');
    }
  }
})();