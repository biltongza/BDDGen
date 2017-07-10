(function () {
  "use strict";
  angular.module('bddgen')
    .component('bddGenerator', {
      templateUrl: 'app/bddGenerator/bddGenerator.template.html',
      controller: ['BddGenAPI', BddGeneratorController]
    });

  function BddGeneratorController(BddGenAPI) {
    const vm = this;

    vm.scenarios = [
      {
        name: 'Scenario 1',
        given: '',
        when: '',
        then: ''
      }
    ];

  }
})();