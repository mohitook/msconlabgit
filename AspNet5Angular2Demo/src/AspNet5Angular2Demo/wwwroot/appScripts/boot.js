var browser_1 = require('angular2/platform/browser');
var app_1 = require('./app');
var http_1 = require('angular2/http');
var router_1 = require('angular2/router');
require('rxjs/Rx');
browser_1.bootstrap(app_1.AppComponent, [router_1.ROUTER_PROVIDERS, http_1.HTTP_PROVIDERS]);
//# sourceMappingURL=boot.js.map