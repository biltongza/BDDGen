(function() {
  "use strict";

  angular.module('bddgen.api')
    .factory("ExportService", ['$resource', ExportServiceFactory]);


  function ExportServiceFactory($resource) {
    return $resource('http://localhost:62171/api/export');
  }
})();