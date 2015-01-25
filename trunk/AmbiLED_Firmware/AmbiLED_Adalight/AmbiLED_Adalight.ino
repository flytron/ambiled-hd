#include <Adafruit_NeoPixel.h>

#define PIN 2
#define LED 13

#define total_led_support 512

Adafruit_NeoPixel strip = Adafruit_NeoPixel(total_led_support, PIN, NEO_GRB + NEO_KHZ800);

int i = 0;
int Ri = 0;
int Gi = 0;
int Bi = 0;
int LED_Count = 200;

byte magic1,magic2,magic3,magic4,magic5,magic6;

unsigned long lastByteTime, t;
  
void setup() {
  pinMode(LED, OUTPUT);  
  
  Serial.begin(115200);
  
  strip.begin();
  strip.show(); // Initialize all pixels to 'off'
  
  Serial.print("Ada\n");   

}

void loop() {

  t = millis(); //Time Data
  
  
  if (Serial.available()>0)    // Serial command received
                        {
                          
                          int cmd = Serial.read();
                          
                          magic1 = magic2;
                          magic2 = magic3;
                          magic3 = cmd;
                          
                          if ((magic1 == 'A') && (magic2 == 'd') &&(magic3 == 'a')) { LED_Count = i-3; i=0;} 
                          else{
                              
                              if (i%3 == 0)        Ri = cmd;
                              else if (i%3 == 1)   Gi = cmd;
                              else if (i%3 == 2)   Bi = cmd;
                              i++;
                            
                              if (i%3 == 0)  strip.setPixelColor((i/3)-2,Ri,Gi,Bi); //tek renk
                              if (i == LED_Count) 
                                    {
                                      strip.show();
                                    }
                              lastByteTime = t;
                             }
                         
                        }
    if((t - lastByteTime) > 1000) {
      
       
        for (i=0;i<total_led_support;i++)  strip.setPixelColor(i,0,0,0);
        strip.show(); // Initialize all pixels to 'off'
      
        Serial.print("Ada\n"); // Send ACK string to host
        lastByteTime = t; // Reset counter
      }
                        
}




