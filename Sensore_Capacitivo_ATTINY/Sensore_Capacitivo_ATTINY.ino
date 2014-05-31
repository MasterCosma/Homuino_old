#include <CapacitiveSensor.h>
CapacitiveSensor   cs_4_2 = CapacitiveSensor(0,1); 
int outpin = 2;
int status1;
void setup()                    
{
  pinMode(outpin,OUTPUT);
  cs_4_2.set_CS_AutocaL_Millis(0xFFFFFFFF);
}

void loop()                    
{
  long total1 =  cs_4_2.capacitiveSensor(30);
  if (total1 > 18000) {
    if (status1 == 0) {
      status1 = 1;
      delay(1000);
    }
    else {
      status1 = 0;
      delay(1000);
    }
  }
  if (status1 == 0) {
    digitalWrite(outpin,LOW); // RESISTENZE : 2 O 3 DA 4.7 MEGAOHM
    delay(10);  
  }
  if (status1 == 1) {
    digitalWrite(outpin,HIGH); // RICORDA IL SENSORE AL PIN 2!
    delay(10);
  }
}






