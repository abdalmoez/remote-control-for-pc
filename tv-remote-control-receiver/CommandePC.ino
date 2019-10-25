/* 
   Reception infrarouge 
*/

#include <IRremote.h>

int broche_reception = 11; // broche 11 utilisée 
IRrecv reception_ir(broche_reception); // crée une instance 
decode_results decode_ir; // stockage données reçues

void setup() 
{ 
  Serial.begin(9600); 
  reception_ir.enableIRIn(); // démarre la réception 
}

void loop() 
{ 
  if (reception_ir.decode(&decode_ir)) 
  { 
    Serial.println(decode_ir.value, HEX); 
    reception_ir.resume(); // reçoit le prochain code 
  } 
}
