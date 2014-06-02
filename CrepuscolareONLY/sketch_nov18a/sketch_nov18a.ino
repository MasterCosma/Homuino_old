const int sensorValue = 800;  //imposta il valore del sensore
int ledPin = 13; // connettere il LED al pin digitale 5
void setup() { // esegui una sola volta quando il disegno inizia
pinMode(ledPin,OUTPUT); // imposta il piedino 5 come uscita
Serial.begin (9600);  // imposta comunicazione seriale 9600bps
}
void loop() {  //esegui più volte
int sensor = analogRead(A0); // imposta il sensore
if (sensor < sensorValue) {  // registra il valore max del sensore
digitalWrite(ledPin,HIGH);  // imposta il piedino 5 a livello basso
Serial.println("notte");  // stampa "giorno" sul monitor
delay(1000);  //attende 1 secondo
}
else {
digitalWrite(ledPin,LOW);  // imposta il piedino 5 a livello alto
Serial.println("giorno");  // stampa "notte" sul monitor
delay(1000);    // attende 1 secondo
}
}
