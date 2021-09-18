#include <IRremote.h>

const int RECV_PIN = 3;
int ledPin = 2;

unsigned long curTime;
unsigned long prevTime = 0;
unsigned long difTime;

IRrecv irrecv(RECV_PIN);

decode_results results;

void setup()
{
  Serial.begin(9600);
  irrecv.enableIRIn(); // Start the receiver

  //Turn on IR LED
  pinMode(ledPin, OUTPUT);
  digitalWrite(ledPin, HIGH);
}

void loop() {

//  digitalWrite(ledPin, LOW);
//  delay(15);
//  digitalWrite(ledPin, HIGH);
//  delay(15);

  curTime = millis();

  difTime = curTime - prevTime;
  
  if (irrecv.decode(&results)) {
    difTime = curTime - prevTime;
    //Serial.println(difTime);

//    Serial.print(" - ");
//    Serial.print(curTime);
//    Serial.print(" - ");
    
//    Serial.println(results.value);
    irrecv.resume(); // Receive the next value

    prevTime = curTime;
  }

  
// Super speed!
  if (difTime < 250) {
    Keyboard.release(KEY_DOWN);
    Keyboard.press(KEY_UP);
    Keyboard.press(KEY_B);
  }
// Reg speed
  else if (difTime < 400)
  {
    Keyboard.release(KEY_B);
    Keyboard.release(KEY_DOWN);
    Keyboard.press(KEY_UP);
  }
// Slow
  else
  {
    Keyboard.release(KEY_B);
    Keyboard.release(KEY_UP);
    Keyboard.press(KEY_DOWN);
  }
  


}
