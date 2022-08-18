#!/usr/bin/env python2.7
import sys, pigpio
import RPi.GPIO as GPIO
from rpi_lcd import LCD


# GPIO setup
GPIO.setwarnings(False)
GPIO.setmode(GPIO.BCM)
GPIO.setup(21, GPIO.OUT)

# Setup
pi = pigpio.pi()  # Connect to local Pi.
red_pin = 12  # Red
pi.set_mode(red_pin, pigpio.OUTPUT)
green_pin = 13  # Blue
pi.set_mode(green_pin, pigpio.OUTPUT)
blue_pin = 19  # Green
pi.set_mode(blue_pin, pigpio.OUTPUT)

# Output
def main():
    # Solid colour LED
    if len(sys.argv) > 1:
        trues = ["1", "on", "high", "true"]
        GPIO.output(21, sys.argv[1].lower() in trues)

    # RGB LED
    if len(sys.argv) > 2:
        hex_code = sys.argv[2]
        set_colour(int(hex_code[0:2], 16), int(hex_code[2:4], 16), int(hex_code[4:6], 16))

    # LCD character display
    if len(sys.argv) > 3:
        lcd = LCD()
        lcd.text(sys.argv[3], 1)
    if len(sys.argv) > 4:
        lcd.text(sys.argv[4], 2)

# Set the colour of the RGB LED
def set_colour(red, green, blue):
    pi.set_PWM_dutycycle(red_pin, adjust_value(red))
    pi.set_PWM_dutycycle(green_pin, adjust_value(green))
    pi.set_PWM_dutycycle(blue_pin, adjust_value(blue))

# Invert because of common anode
def adjust_value(colour_value):
    return 255 - colour_value


if __name__ == "__main__":
    main()
