int led13 = 13;
int LightValue = 60;
float temp;
int tempPin = 1;

void setup() {
  pinMode(led13, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  int LightSense = analogRead(A0);
  if (LightSense < LightValue) {
    digitalWrite(led13, HIGH);
  }
  else {
    digitalWrite(led13,LOW);
  }
  temp = analogRead(tempPin);
  temp = temp * 0.48828125;
  Serial.print("TEMPERATURE = ");
  Serial.print(temp);
  Serial.print("*C");
  Serial.println();
  if (temp<20) {
    digitalWrite(led13, LOW);
  }
  else {
    digitalWrite(led13, HIGH);
  }
  delay(1000);
}


