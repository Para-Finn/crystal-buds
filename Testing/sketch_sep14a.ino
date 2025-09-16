const int buttonPin = 4;

const int redPin = 10;
const int greenPin = 9;
const int bluePin = 8;

int buttonState = 0;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(redPin, OUTPUT);
  pinMode(greenPin, OUTPUT);
  pinMode(bluePin, OUTPUT);

  pinMode(buttonPin, INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  buttonState = digitalRead(buttonPin);

  if(buttonState == HIGH){
    Serial.println("HelloGodot!");
  }

  if(Serial.read() == '1'){
    analogWrite(redPin, 139);
    analogWrite(greenPin, 0);
    analogWrite(bluePin, 139);

    delay(10000);

    analogWrite(redPin, 0);
    analogWrite(greenPin, 0);
    analogWrite(bluePin, 0);
  }
}
