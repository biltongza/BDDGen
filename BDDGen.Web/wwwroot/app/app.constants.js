(function() {
  "use strict";
  angular.module('bddgen')
    .constant('baseScenario', {
      Name: 'Scenario',
      Behaviours: [
        {
          Type: 'Given',
          Placeholder: 'I am a...',
          Parts: ['']
        },
        {
          Type: 'When',
          Placeholder: 'an event ocurrs...',
          Parts: ['']
        },
        {
          Type: 'Then',
          Placeholder: 'an action should be performed',
          Parts: ['']
        }
      ]
    })
})();