#include <CapacitiveSensor.h>
#include "MIDIUSB.h"

/*
 * CapitiveSense Library Demo Sketch
 * Paul Badger 2008
 * Uses a high value resistor e.g. 10M between send pin and receive pin
 * Resistor effects sensitivity, experiment with values, 50K - 50M. Larger resistor values yield larger sensor values.
 * Receive pin is the sensor pin - try different amounts of foil/metal on this pin
 */


CapacitiveSensor   oraButt = CapacitiveSensor(4,2);        // 1M resistor between pins 4 & 2, pin 2 is sensor pin, add a wire and or foil if desired
CapacitiveSensor   apButt = CapacitiveSensor(4,6);        // 1M resistor between pins 4 & 6, pin 6 is sensor pin, add a wire and or foil
CapacitiveSensor   baButt = CapacitiveSensor(4,8);        // 1M resistor between pins 4 & 8, pin 8 is sensor pin, add a wire and or foil
CapacitiveSensor   liButt = CapacitiveSensor(4,10);        // 1M resistor between pins 4 & 10, pin 10 is sensor pin, add a wire and or foil

int threshold = 1000;
int touchState = 5;
bool preTouch = false;
bool ifTouch = false;
int note =0;

    
void setup()                    
{
   pinMode(13,OUTPUT);
   oraButt.set_CS_AutocaL_Millis(0xFFFFFFFF);     // turn off autocalibrate on channel 1 - just as an example
   apButt.set_CS_AutocaL_Millis(0xFFFFFFFF);     // turn off autocalibrate on channel 1 - just as an example
   baButt.set_CS_AutocaL_Millis(0xFFFFFFFF);     // turn off autocalibrate on channel 1 - just as an example
   liButt.set_CS_AutocaL_Millis(0xFFFFFFFF);     // turn off autocalibrate on channel 1 - just as an example
   Serial.begin(9600);
}

void loop()                    
{
    long start = millis();
    long ora =  oraButt.capacitiveSensor(30);
    long ap =  apButt.capacitiveSensor(30);
    long ba =  baButt.capacitiveSensor(30);
    long li =  liButt.capacitiveSensor(30);

    if(ora < threshold){
      touchState = 0;
      note = 61;
      }else if(ap < threshold){
       touchState = 1; 
       note = 62;
        }else if(ba < threshold){
          touchState = 2; 
          note = 63;

          }else if(li < threshold){
           touchState = 3;  
           note = 64;

            }else{
            touchState = 5; 
            note =0;
            }
            

    if(touchState == 5){
      ifTouch = false;
     // digitalWrite(13,LOW);
      }else{
        ifTouch = true;
        //digitalWrite(13,HIGH);
        } 

    
    if(preTouch != ifTouch){
      if(ifTouch == true && preTouch == false){
        noteOn(0, note, 64);   // Channel 0, middle C, normal velocity
        MidiUSB.flush();
        digitalWrite(13,HIGH);
        preTouch = ifTouch;
        //Serial.println(note);
        }
        preTouch = ifTouch;
      }else{
        for(int i = 61; i<=64; i++){
          noteOff(0, i, 64);   // Channel 0, middle C, normal velocity
          MidiUSB.flush();
          digitalWrite(13,LOW);
          }
        }    

   Serial.print(ora);        
   Serial.print("\t");         
    Serial.print(ap);        
    Serial.print("\t");
    Serial.print(ba);        
    Serial.print("\t");
    Serial.print(li);        
    Serial.print("\t");
             
    Serial.print(ifTouch);        // check on performance in milliseconds
    Serial.print("\t");                    // tab character for debug windown spacing
    Serial.println(touchState);                  // print sensor output 1

    delay(10);                             // arbitrary delay to limit data to serial port 
}

void noteOn(byte channel, byte pitch, byte velocity) {
  midiEventPacket_t noteOn = {0x09, 0x90 | channel, pitch, velocity};
  MidiUSB.sendMIDI(noteOn);
}

void noteOff(byte channel, byte pitch, byte velocity) {
  midiEventPacket_t noteOff = {0x08, 0x80 | channel, pitch, velocity};
  MidiUSB.sendMIDI(noteOff);
}
