import { Component } from '@angular/core';
import { NavController, LoadingController } from '@ionic/angular';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  constructor(public navCtrl: NavController, private loadingController : LoadingController){
  }

  searchCuscuz(cuscuz : string){
    console.log(cuscuz);

    if(cuscuz == null || cuscuz.trim() == ''){
      return;
    }

    //Chama a Api e retorna os cuscuzes
    this.loadCuscuz(cuscuz);
  }

  //Carrega cuscuzes
  async loadCuscuz(cuscuz : string){
    const loading = await this.loadingController.create({
      spinner: "lines-small",
      duration: 5000,
      message: 'Please wait...',
      translucent: true,
      cssClass: 'cuscuz-class cuscuz-loading'
    });
    return await loading.present();
  }

}
