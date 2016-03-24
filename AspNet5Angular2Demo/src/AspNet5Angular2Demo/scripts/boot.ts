import {bootstrap} from 'angular2/platform/browser'
import {AppComponent} from './app'
import {Http, HTTP_PROVIDERS} from 'angular2/http'
import 'rxjs/Rx';
bootstrap(AppComponent, [HTTP_PROVIDERS]);