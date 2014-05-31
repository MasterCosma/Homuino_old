#include <SoftEasyTransfer.h>  //Libreria interpretazione dati
#include <OneWire.h>           //Libreria connessione sensore
#include <DallasTemperature.h> //Libreria lettura sensore
#include <SoftwareSerial.h>    //Libreria trasferimento dati
#define SENSOR_PIN 0           //Pin sensore

SoftwareSerial SoftSerial (3, 4); // PIN 3 TX, PIN 4 RX
OneWire sensorwire(SENSOR_PIN);
DallasTemperature sensor(&sensorwire);
SoftEasyTransfer ETComm;

struct DATA_STRUCTURE   //Qui dentro i dati da inviare/leggere
{
  float temp; // Temperatura
  int request; // Byte di richiesta
};

DATA_STRUCTURE Data; // Assegnazione nome struct

unsigned long previousMillis = 0; // millis precedente
unsigned long interval = 30000; // Intervallo invio dati

void setup()
{
  SoftSerial.begin(9600);
  ETComm.begin(details(Data), &SoftSerial);
  pinMode(1, OUTPUT); // Power LED
  pinMode(2, OUTPUT); // Comm LED
  sensor.begin();
  Blink(1, 2); // Show it's alive
  Blink(2, 2); // Show it's alive
  analogWrite(1, 125); //Power status LED
}

void loop()
{
  unsigned long currentMillis = millis();
  if (currentMillis - previousMillis > interval) // Invio dati ogni intervallo
  {
    previousMillis = currentMillis;
    sensor.requestTemperatures();
    Data.temp = sensor.getTempCByIndex(0);
    ETComm.sendData();
    Blink(2, 3);
  }
  if (ETComm.receiveData())   // In caso di richiesta temperatura
  {
    if (Data.request != 0)
    {
      sensor.requestTemperatures();
      Data.temp = sensor.getTempCByIndex(0);
      Data.request = 0;
      ETComm.sendData();
      Blink(2, 3);
    }
    else {
      Data.temp = 0;
      Data.request = 0;
      return;
    }
  }
}

void Blink (byte pin, int times)  // Funzione blink
{
  for(int i = times; i > 0; i--)
  {
    digitalWrite(pin, HIGH);
    delay(200);
    digitalWrite(pin, LOW);
    delay(200);
  }
}

