#!/usr/bin/env python2.7
import RPi.GPIO as GPIO
from time import sleep

# GPIO setup
GPIO.setwarnings(False)
GPIO.setmode(GPIO.BCM)
GPIO.setup(21, GPIO.OUT)

# Blink
GPIO.output(21, GPIO.HIGH)
sleep(1)
GPIO.output(21, GPIO.LOW)

print("Done!")
