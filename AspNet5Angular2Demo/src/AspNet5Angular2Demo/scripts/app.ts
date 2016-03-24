import {Component} from 'angular2/core';
import {Class} from './class';
import {Wowclass} from "./wowclass";
import {Http, HTTP_PROVIDERS, Response} from 'angular2/http';
import 'rxjs/Rx';

@Component({
    selector: 'my-app',
    templateUrl: './testpage.html',
    styleUrls:['mainstyle.css']
})
export class AppComponent {
    
    classes: Array<Wowclass> = [];


    public constructor(
        public http: Http
    ) {
        this.getData();
    }

    getData() {
        this.http.get('http://localhost:11151/api/data').
            map(res => (<Response>res).json())
            .map((classes: Array<any>) => {
                let result: Array<Wowclass> = [];
                if (classes) {
                    classes.forEach(x=> {
                        result.push(
                            new Wowclass(x.id, x.name, x.description)
                        );
                    });
                }
                return result;
            }).subscribe(data => {
                this.classes = data;
                console.log("data ittvan");
            },
            err=> console.log(err)); 
    }

    title = 'World of Warcraft Classes';
    selectedClass: Wowclass;
    

    onSelect(c: Wowclass) { this.selectedClass = c; }

}
var CLASSES: Wowclass[] = [
    new Wowclass(1, 'Warrior', '00'),
    new Wowclass(2, 'Paladin', '00'),
    new Wowclass(3, 'Hunter', '00'),
    new Wowclass(4, 'Rogue', '00'),
    new Wowclass(5, 'Priest', '00'),
    new Wowclass(6, 'Death Knight', '00'),
    new Wowclass(7, 'Shaman', '00'),
    new Wowclass(8, 'Mage', '00'),
    new Wowclass(9, 'Warlock', '00'),
    new Wowclass(10, 'Monk', '00'),
    new Wowclass(11, 'Druid', '00'),
    new Wowclass(12, 'Demon Hunter', '00'),
];