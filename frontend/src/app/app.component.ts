import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  language:string = "en-GB";
  customWords:string[] = [];
  dictionaryWords:string[] = [];

  async textChanged(event: KeyboardEvent){
    let target = event.target as HTMLInputElement;
    const response = await fetch(`/api/Prediction?word=${target.value}&language=${this.language}`);
    const predictionResult = await response.json();
    this.customWords = predictionResult.customWords;
    this.dictionaryWords = predictionResult.dictionaryWords;
  }

 switchLanguage(){
    if(this.language === "en-GB")
      this.language = "da-DK";
    else
      this.language = "en-GB";
  }
}
