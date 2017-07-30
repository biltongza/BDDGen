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
    var vm = this;

    vm.newPart = newPart;
    vm.removePart = removePart;

    function removePart(index) {
      if (index > -1) {
        vm.behaviour.Parts.splice(index, 1);
      }
    }

    function newPart() {
      vm.behaviour.Parts.push('');
    }
    
  }
})();