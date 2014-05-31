#include <BitVoicer11.h>  // Classe BitVoicer
#include <SoftEasyTransfer.h>
#include <SoftwareSerial.h>
SoftwareSerial TempComm(10, 11);

//Istanza della classe BitVoicer
BitVoicerSerial bitVoicer = BitVoicerSerial();
SoftEasyTransfer ETemp; 
String inString; // Stringa controllo input seriale
String strDataCheck; // Stringa controllo ripetizione azione
byte requested = 0;  // Indica se la temperatura è richiesta (1) o no (0)
char output[6];  // SCRIVERE OUTPUT SU QUESTA STRINGA
char temp[2];


struct DATA_STRUCTURE{
  float temp;
  int request;
};

DATA_STRUCTURE Data;

void setup()
{
  //Inizia la comunicazione seriale
  Serial.begin(9600);
  TempComm.begin(9600);
  ETemp.begin(details(Data), &TempComm);
}

void loop()
{
  // SEZIONE TEMPERATURA
  if(ETemp.receiveData()){ // In caso di ricezione temperatura
    Temp2PC();
  }

  // SEZIONE BITVOICER
  bitVoicer.getData(); // Ricevi dati da BitVoicer
  if (bitVoicer.strData == "")   // Esce dal ciclo se non ci sono dati in entrata o se nessuna operazione è in corso
  {
    return;
  }
  if (strDataCheck == bitVoicer.strData) { // se strDataCheck == strData allora stesso comando precedente => inString = ""
    inString = "";
  }
  else {
    strDataCheck = bitVoicer.strData;  // Altrimenti = strData
    inString = bitVoicer.strData;
    CheckString(); // Richiamo funzione controllo
  }
  Action();  // Esegue una determinata azione quando riceve un comando
}

void CheckString() {   // Controlla il contenuto della stringa per inviare il codice adatto per il software gestione

}

void Temp2PC() {
  if (requested == 0) {
    output[0] = 'T';
    sprintf(temp, "%d",(int) Data.temp); // Scrivo temp su array
    strcat(output, temp);
    output[3] = 'U';  // Unrequested
    Serial.println(output);  // Scrivila sulla seriale
    memset(output, '\0', 6);
    memset(temp, '\0', 2);
    delay(300);
  }
  else if (requested == 1)  {
    output[0] = 'T';
    sprintf(temp, "%d",(int) Data.temp);// Scrivo temp su array
    strcat(output, temp);
    output[3] = 'R';  // Requested
    Serial.println(output);  // Scrivila sulla seriale
    memset(output, '\0', 6);
    memset(temp, '\0', 2);
    requested = 0;
    delay(300);
  }
}

void Action () {
  if (bitVoicer.strData == "Temp")
  {
    Data.request = 1;
    ETemp.sendData();
    bitVoicer.strData = "";
    requested = 1; // Se richiesta da bitVoicer = 1
  }
  else
  {
    Serial.println("ERROR:" + bitVoicer.strData);
    bitVoicer.strData = "";
  }
}


