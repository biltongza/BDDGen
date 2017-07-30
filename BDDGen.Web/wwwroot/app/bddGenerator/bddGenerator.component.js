(function () {
  "use strict";
  angular.module('bddgen')
    .component('bddGenerator', {
      templateUrl: 'app/bddGenerator/bddGenerator.template.html',
      controller: ['$location', '$anchorScroll', 'baseScenario', BddGeneratorController]
    });

  function BddGeneratorController($location, $anchorScroll, baseScenario) {
    var vm = this;

    
    vm.suite = {
      Name: 'Test Suite 1',
      Description: 'My first test suite',
      Stories: [
        {
          Name: 'Story 1',
          Description: '',
          Scenarios: [
            baseScenario
          ]
        }
      ]
    }

    vm.activeStory = vm.suite.Stories[0];
    
    

    function scrollToLatest() {
      $location.hash('Scenario' + (vm.activeStory.Scenarios.length - 1));
      return $anchorScroll();
    }

  }
})();