#include <BitVoicer11.h>

//Istanza della classe BitVoicer
BitVoicerSerial bvSerial = BitVoicerSerial();

int pinR = 3;
int pinY = 5;
int pinG = 6;
int blinkDelay = 250;
int sequenceDir = 0;
int lightLevel = 0;
String inString, strDataCheck;

void setup()
{
  //Inizia la comunicazione seriale
  Serial.begin(9600);
  //Imposta i pin
  pinMode(pinR, OUTPUT);
  pinMode(pinY, OUTPUT);
  pinMode(pinG, OUTPUT);
}

void loop()
{
  bvSerial.getData();
  if (bvSerial.strData == "")
  {
    return;  // Esce dal ciclo se non ci sono dati in entrata o se nessuna operazione è in corso
  }
  if (strDataCheck == bvSerial.strData) {
    inString = "";
  }
  else {
    strDataCheck = bvSerial.strData;
    inString = bvSerial.strData;
    CheckString();  // Controlla il contenuto della stringa per inviare il codice adatto per il software gestione
  }
  SetLEDs();  // Imposta i LED a seconda del comando inserito
}

void CheckString() {
  if (inString == "wake") {
    Serial.println("11Wake");
    Serial.flush();
  }
  if (inString == "sleep") {
    Serial.println("11Slee");
    Serial.flush();
  }
  if (inString == "blink") {
    Serial.println("11Blin");
    Serial.flush();
  }
}

void SetLEDs () {
  if (bvSerial.strData == "wake")
  {
    digitalWrite(pinR, LOW);
    digitalWrite(pinY, LOW);
    digitalWrite(pinG, LOW);
    digitalWrite(pinR, HIGH);
    digitalWrite(pinY, HIGH);
    digitalWrite(pinG, HIGH);
    delay(200);
    digitalWrite(pinR, LOW);
    digitalWrite(pinY, LOW);
    digitalWrite(pinG, LOW);
    delay(200);
    digitalWrite(pinR, HIGH);
    digitalWrite(pinY, HIGH);
    digitalWrite(pinG, HIGH);
    delay(200);
    digitalWrite(pinR, LOW);
    digitalWrite(pinY, LOW);
    digitalWrite(pinG, LOW);
    delay(200);
    digitalWrite(pinR, HIGH);
    digitalWrite(pinY, HIGH);
    digitalWrite(pinG, HIGH);
    delay(200);
    digitalWrite(pinR, LOW);
    digitalWrite(pinY, LOW);
    digitalWrite(pinG, LOW);
    bvSerial.strData = "";
    lightLevel = 0;
  }
  else if (bvSerial.strData == "sleep")
  {
    digitalWrite(pinR, LOW);
    digitalWrite(pinY, LOW);
    digitalWrite(pinG, LOW);
    digitalWrite(pinR, HIGH);
    digitalWrite(pinY, HIGH);
    digitalWrite(pinG, HIGH);
    delay(200);
    digitalWrite(pinR, LOW);
    digitalWrite(pinY, LOW);
    digitalWrite(pinG, LOW);
    delay(200);
    digitalWrite(pinR, HIGH);
    digitalWrite(pinY, HIGH);
    digitalWrite(pinG, HIGH);
    delay(200);
    digitalWrite(pinR, LOW);
    digitalWrite(pinY, LOW);
    digitalWrite(pinG, LOW);
    bvSerial.strData = "";
    lightLevel = 0;
  }
  else if (bvSerial.strData == "RH")
  {
    digitalWrite(pinR, HIGH);
    bvSerial.strData = "";
    lightLevel = 255;
  }
  else if (bvSerial.strData == "RL")
  {
    digitalWrite(pinR, LOW);
    bvSerial.strData = "";
    lightLevel = 0;
  }
  else if (bvSerial.strData == "YH")
  {
    digitalWrite(pinY, HIGH);
    bvSerial.strData = "";
    lightLevel = 255;
  }
  else if (bvSerial.strData == "YL")
  {
    digitalWrite(pinY, LOW);
    bvSerial.strData = "";
    lightLevel = 0;
  }
  else if (bvSerial.strData == "GH")
  {
    digitalWrite(pinG, HIGH);
    bvSerial.strData = "";
    lightLevel = 255;
  }
  else if (bvSerial.strData == "GL")
  {
    digitalWrite(pinG, LOW);
    bvSerial.strData = "";
    lightLevel = 0;
  }
  else if (bvSerial.strData == "blink")
  {
    digitalWrite(pinR, HIGH);
    digitalWrite(pinY, HIGH);
    digitalWrite(pinG, HIGH);
    delay(blinkDelay);
    digitalWrite(pinR, LOW);
    digitalWrite(pinY, LOW);
    digitalWrite(pinG, LOW);
    delay(blinkDelay);
    lightLevel = 255;
  }
  else if (bvSerial.strData == "BF")
  {
    blinkDelay = 100;
    bvSerial.strData = "blink";
    lightLevel = 255;
  }
  else if (bvSerial.strData == "BFF")
  {
    switch (blinkDelay)
    {
    case 500:
      blinkDelay = 250;
      break;
    case 250:
      blinkDelay = 100;
      break;
    default:
      break;
    }
    bvSerial.strData = "blink";
    lightLevel = 255;
  }
  else if (bvSerial.strData == "BS")
  {
    blinkDelay = 500;
    bvSerial.strData = "blink";
    lightLevel = 255;
  }
  else if (bvSerial.strData == "BSS")
  {
    switch (blinkDelay)
    {
    case 100:
      blinkDelay = 250;
      break;
    case 250:
      blinkDelay = 500;
      break;
    default:
      break;
    }
    bvSerial.strData = "blink";
    lightLevel = 255;
  }
  else if (bvSerial.strData == "sequence")
  {
    if (sequenceDir == 0)
    {
      digitalWrite(pinR, HIGH);
      delay(250);
      digitalWrite(pinR, LOW);
      digitalWrite(pinY, HIGH);
      delay(250);
      digitalWrite(pinY, LOW);
      digitalWrite(pinG, HIGH);
      delay(250);
      digitalWrite(pinG, LOW);
    }
    else
    {
      digitalWrite(pinG, HIGH);
      delay(250);
      digitalWrite(pinG, LOW);
      digitalWrite(pinY, HIGH);
      delay(250);
      digitalWrite(pinY, LOW);
      digitalWrite(pinR, HIGH);
      delay(250);
      digitalWrite(pinR, LOW);
    }
    lightLevel = 255;
  }
  else if (bvSerial.strData == "revert")
  {
    if (sequenceDir == 0)
    {
      sequenceDir = 1;
    }
    else
    {
      sequenceDir = 0;
    }
    bvSerial.strData = "sequence";
    lightLevel = 255;
  }
  else if (bvSerial.strData == "ALLON")
  {
    digitalWrite(pinR, HIGH);
    digitalWrite(pinY, HIGH);
    digitalWrite(pinG, HIGH);
    bvSerial.strData = "";
    lightLevel = 255;
  }
  else if (bvSerial.strData == "ALLOFF")
  {
    digitalWrite(pinR, LOW);
    digitalWrite(pinY, LOW);
    digitalWrite(pinG, LOW);
    bvSerial.strData = "";
    lightLevel = 0;
  }
  else if (bvSerial.strData == "brighter")
  {
    if (lightLevel < 255)
    {
      lightLevel += 85;
      analogWrite(pinR, lightLevel);
      analogWrite(pinY, lightLevel);
      analogWrite(pinG, lightLevel);
    }
    bvSerial.strData = "";
  }
  else if (bvSerial.strData == "darker")
  {
    if (lightLevel > 0)
    {
      lightLevel -= 85;
      analogWrite(pinR, lightLevel);
      analogWrite(pinY, lightLevel);
      analogWrite(pinG, lightLevel);
    }
    bvSerial.strData = "";
  }
  else
  {
    Serial.println("ERROR:" + bvSerial.strData);
    bvSerial.strData = "";
  }
}
