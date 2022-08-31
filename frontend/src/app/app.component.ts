import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  language = "en-GB"
  customWords = [];
  dictionaryWords = []

  async textChanged(event: KeyboardEvent){
    var target = event.target as HTMLInputElement
    console.log(target.value);
    const response = await fetch("/api/Prediction?word="+target.value+"&language="+this.language+"");
    const predictionResult = await response.json();
    console.log(predictionResult);
    this.customWords = predictionResult.customWords;
    this.dictionaryWords = predictionResult.dictionaryWords;
  }
  
  switchLanguage(){
    if(this.language === "en-GB")
      this.language = "da-DK"
    else
      this.language = "en-GB";
  }
}

