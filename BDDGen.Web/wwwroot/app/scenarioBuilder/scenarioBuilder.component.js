(function () {
  "use strict";

  angular.module('bddgen')
    .component('scenarioBuilder', {
      templateUrl: '/app/scenarioBuilder/scenarioBuilder.template.html',
      bindings: {
        scenario: '=',
        scenarioIndex: '<',
        onScenarioCopied: '=',
        onScenarioDeleted: '='
      },
      controller: [ScenarioBuilderController]
    });

  function ScenarioBuilderController() {
    var vm = this;
    vm.$onInit = onInit;

    function onInit() {
 
    }
  }
})();