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
    print("<br/>Args: {}<br/>\n".format(len(sys.argv)))  # TEMP - Debug

    # Solid colour LED
    if len(sys.argv) > 1:
        trues = ["1", "on", "high", "true"]
        print("<br/>\n<br/>\nStatus: {0} (\"{1}\")<br/>".format(sys.argv[1].lower() in trues, sys.argv[1]))  # TEMP - Debug
        GPIO.output(21, sys.argv[1].lower() in trues)

    # RGB LED
    if len(sys.argv) > 2:
        hex_code = sys.argv[2]
        print("<br/>\n<br/>\nHex: {0}#<br/>\n  Red: {1}<br/>\nGreen: {2}<br/>\n Blue: {3}<br/>".format(hex_code, int(hex_code[0:2], 16), int(hex_code[2:4], 16), int(hex_code[4:6], 16)))  # TEMP - Debug
        set_colour(int(hex_code[0:2], 16), int(hex_code[2:4], 16), int(hex_code[4:6], 16))

    # LCD character display
    if len(sys.argv) > 3:
        print("<br/>\n<br/>\nLCD:<br/>\n  L1: {}<br/>".format(sys.argv[3]))  # TEMP - Debug
        lcd = LCD()
        lcd.text(sys.argv[3], 1)
    if len(sys.argv) > 4:
        print("  L2: {}<br/>".format(sys.argv[4]))  # TEMP - Debug
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
