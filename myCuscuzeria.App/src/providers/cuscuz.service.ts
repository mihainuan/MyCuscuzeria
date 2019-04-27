import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import { UtilService } from "./util.service";

@Injectable()
export class CuscuzService {
    constructor(public http: Http, public utilService: UtilService){

     }        
        //GET
        listarPorCuscuz(cuscuz: string): Promise<Response> {
          
          let host = this.utilService.obterHostDaApi();
      
          let headers = new Headers();
          headers.append('Content-Type', 'application/json');
      
          return this.http.get(host + 'api/Cuscuzes/Find/' + cuscuz, { headers: headers }).toPromise();
        }
      
        //POST
        adicionar(request: any): Promise<Response> {
      
          let host = this.utilService.obterHostDaApi();
      
          let headers : any = new Headers();
          headers.append('Content-Type', 'application/json');
          headers.append('Authorization', 'Bearer ' + localStorage.getItem('YouLearnToken'));
      
          return this.http.post(host + 'api/Cuscuz/Add',  request, { headers: headers }).toPromise();
        }
}