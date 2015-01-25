#include "def.h"

#include <functions.h> 

#include <Adafruit_NeoPixel.h>

#if defined(ShortStrip)
    Adafruit_NeoPixel strip = Adafruit_NeoPixel(256, PIN, NEO_GRB + NEO_KHZ800); //Fast update for max. 256 LEDs strips
#else
    Adafruit_NeoPixel strip = Adafruit_NeoPixel(total_led_support, PIN, NEO_GRB + NEO_KHZ800); //Standard update for max. 512 LEDs strips
#endif


int bi = 0;
int i = 0;
int j = 0;
byte R_pixel = 0;
byte G_pixel = 0;
byte B_pixel = 0;
byte R_previous = 0;
byte G_previous = 0;
byte B_previous = 0;
byte isSleep = 0;
#if defined(DoublePixels)
byte big_screen = 1;
#else
byte big_screen = 0;
#endif
int color_sensor_counter=0;

unsigned long lastByteTime, t;
  
void setup() {
  Serial.begin(115200);
  
  pinMode(LED, OUTPUT);  
  
  //TCS3200 Light Sensor Pins
  pinMode(S0,OUTPUT);
  pinMode(S1,OUTPUT); 
  pinMode(S2,OUTPUT);
  pinMode(S3,OUTPUT);
  
  //Check the TCS3200 Light Sensor documentation for S0..S3 
  digitalWrite(S0,HIGH); //S0 High, S1 High for hish speed mode.
  digitalWrite(S1,HIGH);
  digitalWrite(S2,HIGH); //S2 High,S3 Low for Clear sensor mode
  digitalWrite(S3,LOW); 
  
 
  strip.begin();
  strip.show(); // Initialize all pixels to 'off'
  
  Print_Sign(); // Print device name and sensor value
  
  Opening();
}

void ISR_INT1()
{
  color_sensor_counter++;
}

void loop() {
  
  
  t = millis(); //Time Data
  if (Serial.available()>0)    // Serial command received from the PC
                        {
                          
                          int cmd = Serial.read();
                          if (cmd>250) 
                            commands(cmd);
                          else              
                            {
                            if (bi%3 == 0)        
                               R_pixel = cmd;
                            else if (bi%3 == 1)   
                               G_pixel = cmd;
                            else if (bi%3 == 2)   
                               {
                                 B_pixel = cmd;
                                 if (big_screen==0)
                                     strip.setPixelColor((bi/3)-1,R_pixel,G_pixel,B_pixel); //buffer single pixel
                                   else
                                   {
                                     strip.setPixelColor((bi/3)-1,R_pixel,G_pixel,B_pixel); //buffer double pixel for big screens
                                     bi +=3;
                                     strip.setPixelColor((bi/3)-1,R_pixel,G_pixel,B_pixel); 
                                   }
                                   
                               }
                            bi++;     
                            lastByteTime = t;       
                            }                  
                        }
    if((t - lastByteTime) > 1000) {
       
        if (isSleep==0)
          {
          Sleeping();
          isSleep=1;
          }
        
        for (i=0;i<total_led_support;i++) strip.setPixelColor(i,0,0,0);
        strip.show(); // Initialize all pixels to 'off'
      
        Print_Sign();
        lastByteTime = t; // Reset counter
      }
                        
}

// Fill the dots one after the other with a color
void Opening() {

    for (j=0;j<50;j++)  
      {
      for (i=0;i<total_led_support;i++)  
            {
            strip.setPixelColor(i,j,j,j);
           }
      strip.show(); // Initialize all pixels to 'off'
      delay(20);
      }
    for (j=50;j>0;j--)  
      {
      for (i=0;i<total_led_support;i++)  
            {
            strip.setPixelColor(i,j,j,j);
           }
      strip.show(); // Initialize all pixels to 'off'
      delay(20);
      }  
    for (i=0;i<total_led_support;i++) strip.setPixelColor(i,0,0,0);
        strip.show(); // Initialize all pixels to 'off'  
}

void Sleeping(){
 for (j=0;j<250;j++)  
            {
            for (i=0;i<total_led_support;i++)  
                {
                uint32_t pixy = strip.getPixelColor(i); 
                byte Rp = (pixy & 0x00ff0000UL) >> 16;
                byte Gp = (pixy & 0x0000ff00UL) >>  8;
                byte Bp = (pixy & 0x000000ffUL)      ;
                if (Rp>0) Rp--;
                if (Gp>0) Gp--;
                if (Bp>0) Bp--;
                strip.setPixelColor(i,Rp,Gp,Bp);
                }
            strip.show(); // Initialize all pixels to 'off'
            } 
}

void commands(byte cmd)
{
  switch (cmd) {
        case 255:// SET LEDs
          strip.show();
          isSleep=0;
          bi=0; 
          #if defined(DoublePixels)
             big_screen = 1;
          #else
             big_screen = 0;
          #endif
          break;
        case 254:// SET LEDs 2x for big screens
          strip.show();
          isSleep=0;
          bi=0; 
          big_screen = 1;
          break;  

        case 252:// Read Sensors when strip is off
          for (i=0;i<total_led_support;i++)  strip.setPixelColor(i,0,0,0); //Stop all LEDs
          strip.show();
          Print_Sign();
          bi=0;
          break;  
        case 251:// Read Sensors when strip is on
          Print_Sign();
          bi=0;
          break; 

      } 
}

void Print_Sign(void){
  Serial.print("AmbiLED HD v1.0\n"); // Send ACK string to host
  Serial.print(TCS3200_read('A')); // Print Ambient light level
  Serial.print('\n');
  Serial.print(TCS3200_read('R')); // Print Ambient light level
  Serial.print('\n');
  Serial.print(TCS3200_read('G')); // Print Ambient light level
  Serial.print('\n');
  Serial.print(TCS3200_read('B')); // Print Ambient light level,
  Serial.print('\n'); 
}


int TCS3200_read(char read_mode){
   
  int color_count=0; 
  attachInterrupt(1, ISR_INT1, LOW);
  switch (read_mode) {
   case 'A':   
      //Red 
      digitalWrite(S2,HIGH);
      digitalWrite(S3,LOW); 
      color_sensor_counter=0;
      delay(10); 
      color_count=color_sensor_counter; 
      break;
     
   case 'R':   
      //Red 
      digitalWrite(S2,LOW);
      digitalWrite(S3,LOW); 
      color_sensor_counter=0;
      delay(10); 
      color_count=color_sensor_counter; 
      break;
   case 'G':   
      //Red 
      digitalWrite(S2,HIGH);
      digitalWrite(S3,HIGH);
      color_sensor_counter=0;
      delay(10); 
      color_count=color_sensor_counter; 
      break;
   case 'B':   
      //Red 
      digitalWrite(S2,LOW);
      digitalWrite(S3,HIGH); 
      color_sensor_counter=0;
      delay(10); 
      color_count=color_sensor_counter; 
      break;   
  }
 detachInterrupt(1); 
 return color_count;
 }
 
