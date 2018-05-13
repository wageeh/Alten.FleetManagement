import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public check: FleetManagment[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get('http://localhost:59024/api/tracker').subscribe(result => {
            this.check = result.json() as FleetManagment[];
            debugger;
        }, error => console.error(error));
    }
}

interface FleetManagment {
    dateFormatted: string;
    status: string;
    //registrationNumber:string
}
