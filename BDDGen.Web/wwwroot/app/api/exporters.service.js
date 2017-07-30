(function() {
  "use strict";
  angular.module('bddgen.api')
    .factory('ExportersService', ['$resource', ExportersServiceFactory]);

  function ExportersServiceFactory($resource) {
    return $resource('http://localhost:62171/api/exporters');
  }
})();