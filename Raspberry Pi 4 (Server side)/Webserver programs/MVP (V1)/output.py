#!/usr/bin/env python2.7
import sys
import RPi.GPIO as GPIO


# GPIO setup
GPIO.setwarnings(False)
GPIO.setmode(GPIO.BCM)
GPIO.setup(21, GPIO.OUT)

# Output
trues = ["1", "on", "high", "true"]
GPIO.output(21, sys.argv[1].lower() in trues)
