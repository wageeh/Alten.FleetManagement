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
    public _http: Http;
    public fleeturl: string = "http://localhost:56291/api/clients";
    public vehicleurl: string = "http://localhost:59024/api/tracker";
    public pingurl: string = "http://localhost:59024/api/Ping";
    public selstatus: boolean | null;
    public selvehicles: string = "";


    constructor(http: Http) {
        this._http = http;
        // for listing client list
        http.get(this.fleeturl).subscribe(result => {
            this.clients = result.json() as BusinessClient[];
        }, error => console.error(error));

        // for getting Fleet latest saved status
        http.get(this.vehicleurl).subscribe(result => {
            this.checks = result.json() as FleetManagment[];           
        }, error => console.error(error));
    }

    public filterbystatus(selval: any) {
        this.selstatus = selval;
        this._http.get(this.vehicleurl + "/" + this.selvehicles + "/" + this.selstatus).subscribe(result => {
            this.checks = result.json() as FleetManagment[];
            
        }, error => console.error(error));
    }

    public pingvehicles() {
        this._http.get(this.pingurl).subscribe(result => {
            alert("Pinged successfully");
        }, error => console.error(error));
    }

    public filterbyclient(selval: any) {
        //var clientId = client.Id;
        var curUser = this.clients.filter(value => value.name === selval)[0];
        this.selvehicles = "";
        if (curUser) {
            for (var vehicle of curUser.vehicles) {
                this.selvehicles += vehicle.registrationNumber;
                this.selvehicles += ",";
            }
           
        }
        
        this._http.get(this.vehicleurl + "/" + this.selvehicles + "/" + this.selstatus).subscribe(result => {
            this.checks = result.json() as FleetManagment[];
        }, error => console.error(error));
    }
}

class FleetManagment {
    createdDate: string;
    status: boolean;
    registrationNumber: string;
    StatusOld: boolean;
}

class BusinessClient {
    name: string;
    Id: string;
    vehicles: Array<Vehicle>;
}

class Vehicle {
    Id: string;
    vin: string;
    registrationNumber: string;
}
