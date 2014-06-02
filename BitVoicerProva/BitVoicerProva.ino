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
float tempC;
int tempPin = 0;
int maxTempDifference = 4;
int tempDS;
int yesno = 0; // 1 = true      2 = false     0 = null


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
  else if (requested == 2) { // Se è richiesta dal condizionatore
    tempDS = (int) Data.temp;
    tempC = analogRead(tempPin);
    tempC = tempC * 0.48828125;
    if (abs(tempDS-tempC) >= maxTempDifference) {
      Serial.println("ACA"); // "ACA" = Alert : Condizionatore Aria
      Serial.println(abs(tempDS-tempC));
    }
    else {
    }
    requested = 0;
  }
}

void ACACheck() {
  if (yesno == 1) {
    // ACCENDI CONDIZIONATORE
    yesno = 0;
    Serial.println("AOK");
    Serial.flush();
  }
  else if (yesno == 2) {
    // LASCIA INVARIATO IL CONDIZIONATORE
    yesno = 0;
    Serial.println("AOK");
    Serial.flush();
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
  else if (bitVoicer.strData == "CAON") {
    Data.request = 1;
    ETemp.sendData();
    bitVoicer.strData = "";
    requested = 2; // Se richiesta da condizionatore = 2
  }
  else if (bitVoicer.strData == "YCA") {
    yesno = 1;
    ACACheck();
    bitVoicer.strData = "";
  }
  else if (bitVoicer.strData == "NCA") {
    yesno = 2;
    ACACheck();
    bitVoicer.strData = "";
  }
  else
  {
    Serial.println("ERROR:" + bitVoicer.strData);
    bitVoicer.strData = "";
  }
}

