(function () {
  "use strict";
  angular.module('bddgen')
    .component('bddGenerator', {
      templateUrl: 'app/bddGenerator/bddGenerator.template.html',
      controller: ['BddGenAPI', '$location', '$anchorScroll', BddGeneratorController]
    });

  function BddGeneratorController(BddGenAPI, $location, $anchorScroll) {
    var vm = this;
    vm.addScenario = addScenario;
    vm.removeScenario = removeScenario;
    vm.copyScenario = copyScenario;
    vm.baseScenario = {
      name: 'Scenario',
      behaviours: [
        {
          type: 'Given',
          placeholder: 'I am a...',
          parts: ['']
        },
        {
          type: 'When',
          placeholder: 'an event ocurrs...',
          parts: ['']
        },
        {
          type: 'Then',
          placeholder: 'an action should be performed',
          parts: ['']
        }
      ]
    };

    vm.scenarios = [
      vm.baseScenario
    ];

    function addScenario() {
      vm.scenarios.push(angular.copy(vm.baseScenario));
      scrollToLatest();
    }

    function removeScenario(index) {
      if (index > -1) {
        vm.scenarios.splice(index, 1);
      }
    }

    function copyScenario(index) {
      var scenario = vm.scenarios[index];
      vm.scenarios.push(JSON.parse(JSON.stringify(scenario)));
      scrollToLatest();
    }

    function scrollToLatest() {
      $location.hash('Scenario' + (vm.scenarios.length - 1));
      return $anchorScroll();
    }

  }
})();