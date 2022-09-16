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
    print("<br/>Args: {}<br/>\n".format(len(sys.argv)))  # Debug

    # RGB LED
    if len(sys.argv) > 1:
        hex_code = sys.argv[1]
        print("<br/>\n<br/>\nHex: {}#<br/>".format(hex_code))  # Debug

        # Check hexcode is valid and display
        if len(hex_code) == 6:
            try:
                print("  Red: {0}<br/>\nGreen: {1}<br/>\n Blue: {2}<br/>".format(int(hex_code[0:2], 16), int(hex_code[2:4], 16), int(hex_code[4:6], 16)))  # Debug
                set_colour(int(hex_code[0:2], 16), int(hex_code[2:4], 16), int(hex_code[4:6], 16))
            except ValueError:
                print("  Invalid character/s!<br/>\n    Cannot display colour<br/>\n")  # Debug
                set_colour(0, 0, 0) # Colour: 000000# (Off)
        else:
            print("  Invalid length!<br/>\n    Cannot display colour<br/>\n")  # Debug
            set_colour(0, 0, 0) # Colour: 000000# (Off)

    # LCD character display
    if len(sys.argv) > 2:
        line1 = unpack(sys.argv[2])
        print("<br/>\n<br/>\nLCD:<br/>\n  L1: \"{0}\" (\"{1}\")<br/>".format(line1, sys.argv[2]))  # Debug
        lcd = LCD()
        lcd.text(line1, 1)
    if len(sys.argv) > 3:
        line2 = unpack(sys.argv[3])
        print("  L2: \"{0}\" (\"{1}\")<br/>".format(line2, sys.argv[3]))  # Debug
        lcd.text(line2, 2)

# Set the colour of the RGB LED
def set_colour(red, green, blue):
    pi.set_PWM_dutycycle(red_pin, adjust_value(red))
    pi.set_PWM_dutycycle(green_pin, adjust_value(green))
    pi.set_PWM_dutycycle(blue_pin, adjust_value(blue))

# Invert because of common anode
def adjust_value(colour_value):
    return 255 - colour_value

# Unpacks string to get actual values
def unpack(input):
    input = input.replace("/@a", "&")  # Ampersand
    input = input.replace("/@h", "#")  # Hashtag
    input = input.replace("/@s", " ")  # Space
    input = input.replace("/@0", "")  # Null char
    return input


if __name__ == "__main__":
    main()
