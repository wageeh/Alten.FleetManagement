import { Component, Inject } from '@angular/core';
import { Http, RequestOptions } from '@angular/http';
import { Data } from '@angular/router/src/config';
import { Params } from '@angular/router/src/shared';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {

    // init 
    public checks: FleetManagment[];
    public clients: BusinessClient[];
    //public _http: Http;


    constructor(http: Http) {
        //this._http = http;
        // for listing client list
        http.get('http://localhost:56291/api/clients').subscribe(result => {
            this.clients = result.json() as BusinessClient[];
        }, error => console.error(error));

        // for getting Fleet latest saved status
        http.get('http://localhost:59024/api/tracker').subscribe(result => {
            this.checks = result.json() as FleetManagment[];           
        }, error => console.error(error));
    }

    public filter(selval: any) {
        //var clientId = client.Id;
        var curUser = this.clients.filter(value => value.name === selval)[0];
        

        let requestOptions = new RequestOptions();
        requestOptions.body = curUser.vehicles;
        debugger;

        //http.get('http://localhost:59024/api/tracker', requestOptions).subscribe(result => {
        //    this.checks = result.json() as FleetManagment[];
        //}, error => console.error(error));
    }
}

interface FleetManagment {
    createdDate: string;
    status: boolean;
    registrationNumber: string;
    StatusOld: boolean;
}

interface BusinessClient {
    name: string;
    Id: string;
    vehicles: {
        [key: string]: Vehicle;
    };
}

interface Vehicle {
    Id: string;
    vin: string;
    registrationNumber: string;
}
