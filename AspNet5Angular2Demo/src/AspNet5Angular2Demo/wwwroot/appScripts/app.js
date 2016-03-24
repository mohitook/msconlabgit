var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('angular2/core');
var wowclass_1 = require("./wowclass");
var http_1 = require('angular2/http');
require('rxjs/Rx');
var AppComponent = (function () {
    function AppComponent(http) {
        this.http = http;
        this.classes = [];
        this.title = 'World of Warcraft Classes';
        this.getData();
    }
    AppComponent.prototype.getData = function () {
        var _this = this;
        this.http.get('http://localhost:11151/api/data').
            map(function (res) { return res.json(); })
            .map(function (classes) {
            var result = [];
            if (classes) {
                classes.forEach(function (x) {
                    result.push(new wowclass_1.Wowclass(x.id, x.name, x.description));
                });
            }
            return result;
        }).subscribe(function (data) {
            _this.classes = data;
            console.log("data ittvan");
        }, function (err) { return console.log(err); });
    };
    AppComponent.prototype.onSelect = function (c) { this.selectedClass = c; };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: './testpage.html',
            styleUrls: ['mainstyle.css']
        }), 
        __metadata('design:paramtypes', [http_1.Http])
    ], AppComponent);
    return AppComponent;
})();
exports.AppComponent = AppComponent;
var CLASSES = [
    new wowclass_1.Wowclass(1, 'Warrior', '00'),
    new wowclass_1.Wowclass(2, 'Paladin', '00'),
    new wowclass_1.Wowclass(3, 'Hunter', '00'),
    new wowclass_1.Wowclass(4, 'Rogue', '00'),
    new wowclass_1.Wowclass(5, 'Priest', '00'),
    new wowclass_1.Wowclass(6, 'Death Knight', '00'),
    new wowclass_1.Wowclass(7, 'Shaman', '00'),
    new wowclass_1.Wowclass(8, 'Mage', '00'),
    new wowclass_1.Wowclass(9, 'Warlock', '00'),
    new wowclass_1.Wowclass(10, 'Monk', '00'),
    new wowclass_1.Wowclass(11, 'Druid', '00'),
    new wowclass_1.Wowclass(12, 'Demon Hunter', '00'),
];
//# sourceMappingURL=app.js.map