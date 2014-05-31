#include <SoftEasyTransfer.h>
#include <SoftwareSerial.h>
#include <avr/wdt.h>

// SEZIONE COMUNICAZIONI
String inString; // Stringa controllo input seriale
String strDataCheck; // Stringa controllo ripetizione azione
char output[6];  // SCRIVERE OUTPUT SU QUESTA STRINGA (sprintf, strcat)
int yesno = 0; // 1 = true      2 = false     0 = null
byte length;
byte type;
int bytesAvailable = 0;
String input;

//SEZIONE TEMPERATURA ATTINY
SoftEasyTransfer ETemp; // Comunicazione ATTiny Temperatura
SoftwareSerial TempComm(10, 11);
int tempDS;
byte requested = 0;  // Indica se la temperatura è richiesta (1) o no (0)
char tempCH[2]; // Temperatura temporanea in char
struct TEMP_STRUCTURE{ // I valori da ricevere dall'ATTinyTemp
  float temp; // Temperatura
  int request; // Richiesta
};
TEMP_STRUCTURE TempData; // Assegno un nome alla struct

// SEZIONE DICHIARAZIONI PIN
int led13 = 13;
int led12 = 12;

//SEZIONE CREPUSCOLARE
const int sensorValue = 420;  //imposta il valore del sensore
int ledCrepuscolo = 13; // connettere il LED al pin digitale 10

//SEZIONE STRINGA SERIALE
char inData[20]; // Allocate some space for the string
char inChar=-1; // Where to store the character read
byte index = 0; // Index into array; where to store the character

//SEZIONE FADE
int brightness = 0;    // Luminosità del LED
int fadeAmount = 5;    // how many points to fade the LED by
int fadestate = 0;

//SEZIONE MILLIS
unsigned long CrepuscoloRefresh = 10000;
unsigned long previousMillis = 0;  

//SEZIONE CONDIZIONATORE
int CondState = 0; // Stato condizionatore :  0 = Spento   1 = Acceso
int SeasonState = 0; // Stagione attuale :  0 = refrigerazione   1 = riscaldamento

void setup() {
  Serial.begin(9600);
  TempComm.begin(9600);
  ETemp.begin(details(TempData), &TempComm);
  pinMode(led13, OUTPUT);
  pinMode(led12, OUTPUT);
  pinMode(ledCrepuscolo, OUTPUT); 
  wdt_enable(WDTO_4S); // Attiva il watchdog su 4 secondi
}




void loop()
{
  unsigned long currentMillis = millis();
  // SEZIONE TEMPERATURA
  if(ETemp.receiveData()){ // In caso di ricezione temperatura
    tempDS = (int) TempData.temp;
    Temp2PC();
  }

  // SEZIONE CREPUSCOLARE
  if(currentMillis - previousMillis > CrepuscoloRefresh) {
    previousMillis = currentMillis;   
    int sensor = analogRead(A0); // imposta il sensore
    if (sensor < sensorValue) {  // registra il valore max del sensore
      digitalWrite(ledCrepuscolo,HIGH);  // imposta il piedino 13 a livello alto
      //Serial.println("CC1");  // stampa "notte" sul monitor
    }
    else {
      digitalWrite(ledCrepuscolo,LOW);  // imposta il piedino 13 a livello basso
      //Serial.println("CC0");  // stampa "giorno" sul monitor
    }
  }

  // SEZIONE SERIALE
  GET();  // Riceve i dati dalla seriale e li valuta
  
  
  wdt_reset(); // Resetta il timer watchdog
}





void GET() {   // Riceve i dati dalla seriale e li confronta
  if (Comp("CAON") == 0) {
    input = "CAON";
    Action();
  }
  if (Comp("CAWI") == 0) {
    input = "CAWI";
    Action();
  }
}

void Action () {  // Controlla il messaggio ricevuto da BitVoicer
  if (input == "Temp")
  {
    TempData.request = 1;  // Byte richiesta attiny
    ETemp.sendData();
    input = "";
    requested = 1; // Se richiesta da bitVoicer = 1
  }
  else if (input == "CAON") { // Richiesta di accendere condizionatore
    // ACCENDI CONDIZIONATORE
    digitalWrite(13, HIGH);
    input = "";
  }
  else if (input == "CAOF") {
    // SPEGNI CONDIZIONATORE
    input = "";
  }
  else if (input == "CAWI") {
    // IMPOSTA RISCALDAMENTO
    SeasonState = 1;
    input = "";
  }
  else if (input == "CASU") {
    // IMPOSTA RAFFREDDAMENTO
    SeasonState = 0;
    input = "";
  }
  else
  {
    Serial.println("ERROR:" + input);
    input = "";
  }
}


void Temp2PC() { // Invia la temperatura al PC
  if (requested == 0) {
    output[0] = 'T';
    sprintf(tempCH, "%d",(int) TempData.temp); // Scrivo temp su array
    strcat(output, tempCH);
    output[3] = 'U';  // Unrequested
    Serial.println(output);  // Scrivila sulla seriale
    memset(output, '\0', 6);
    memset(tempCH, '\0', 2);
    delay(300); // Blocca momentaneamente eventuali messaggi da inviare
  }
  else if (requested == 1)  {
    output[0] = 'T';
    sprintf(tempCH, "%d",(int) TempData.temp);// Scrivo temp su array
    strcat(output, tempCH);
    output[3] = 'R';  // Requested
    Serial.println(output);  // Scrivila sulla seriale
    memset(output, '\0', 6);
    memset(tempCH, '\0', 2);
    requested = 0;
    delay(300); // Blocca momentaneamente eventuali messaggi da inviare
  }
}


char Comp(char* This) {  // FUNZIONE LETTURA STRINGA SERIALE
  while (Serial.available() > 0)
  {
    if(index < 19)
    {
      inChar = Serial.read();
      inData[index] = inChar;
      index++;
      inData[index] = '\0';
    }
  }

  if (strcmp(inData,This)  == 0) {
    for (int i=0;i<19;i++) {
      inData[i]=0;
    }
    index=0;
    return(0);
  }
  else {
    return(1);
  }
}












