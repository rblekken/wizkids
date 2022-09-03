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
    let text = (event.target as HTMLInputElement).value;
    if(text.length == 0)
      return;
    const response = await fetch(`/api/Prediction?word=${text}&language=${this.language}`);
    const predictionResult = await response.json();
    this.customWords = predictionResult.customWords;
    this.dictionaryWords = predictionResult.dictionaryWords;
  }

  onLanguageChanged(lang:string){
    this.language = lang;
  }

}
