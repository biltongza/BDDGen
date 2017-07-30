(function () {
  "use strict";

  angular.module('bddgen')
    .component('scenarioList', {
      templateUrl: '/app/scenarioList/scenarioList.template.html',
      controller: ['baseScenario', ScenarioListController],
      bindings: {
        scenarios: '='
      }
    });

  function ScenarioListController(baseScenario) {
    var vm = this;
    vm.$onInit = onInit;

    vm.onScenarioCopied = onScenarioCopied;
    vm.onScenarioDeleted = onScenarioDeleted;
    vm.addScenario = addScenario;

    function onScenarioDeleted(index) {
      if (index > -1) {
        vm.scenarios.splice(index, 1);
      }
    }
    function onScenarioCopied(index) {
      var scenario = vm.scenarios[index];
      var copy = JSON.parse(JSON.stringify(scenario));
      vm.scenarios.push(copy);
    }
    function addScenario() {
      vm.scenarios.push(angular.copy(baseScenario));
    }

    function onInit() {
    }
  }
})();