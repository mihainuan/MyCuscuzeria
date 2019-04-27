import { CuscuzService } from 'src/providers/cuscuz.service';
import { UtilService } from 'src/providers/util.service';
import { Component } from '@angular/core';
import { NavController } from '@ionic/angular';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  cuscuzes: any[] = [];
  constructor(public navCtrl: NavController, private utilService: UtilService, private cuscuzService: CuscuzService) {
  }

  searchCuscuz(cuscuz: string) {
    console.log(cuscuz);

    if (cuscuz == null || cuscuz.trim() == '') {
      return;
    }

    //Chama a Api e retorna os cuscuzes
    this.loadCuscuz(cuscuz);
  }

  //Carrega cuscuzes
  async loadCuscuz(cuscuz: string) {

    //Loading Spinner
    let loading = await this.utilService.showLoading(cuscuz);
    loading.present();
    //loading.dismiss();

    //Chama a API
    this.cuscuzService.listarPorCuscuz(cuscuz).then(
      (response) => {
        //Popula o array
        this.cuscuzes = response.json();

        console.log(this.cuscuzes);
        loading.dismiss();
      }
    ).catch(
      (response) => {
        this.utilService.showMessageError(response);
      }
    );

  }

}
