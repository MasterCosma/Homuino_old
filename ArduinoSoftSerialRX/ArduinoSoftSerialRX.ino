#include <SoftEasyTransfer.h>
#include <SoftwareSerial.h>
SoftwareSerial mySerial(10, 11);
char input[5];

//create object
SoftEasyTransfer ET; 

struct RECEIVE_DATA_STRUCTURE{
  //put your variable definitions here for the data you want to receive
  //THIS MUST BE EXACTLY THE SAME ON THE OTHER ARDUINO
  int pressed;
};

//give a name to the group of data
RECEIVE_DATA_STRUCTURE Data;

void setup(){
  mySerial.begin(9600);
  Serial.begin(9600);
  //start the library, pass in the data details and the name of the serial port.
  ET.begin(details(Data), &mySerial);
  pinMode(13, OUTPUT);
}

void loop(){
  //check and see if a data packet has come in. 
  if(ET.receiveData()){
    Serial.println(Data.pressed);
  }
}


