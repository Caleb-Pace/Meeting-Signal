# !/usr/bin/env python2.7
import pigpio
from time import sleep


# Setup
pi = pigpio.pi()  # Connect to local Pi.
red_pin = 12  # Red
pi.set_mode(red_pin, pigpio.OUTPUT)
green_pin = 13  # Blue
pi.set_mode(green_pin, pigpio.OUTPUT)
blue_pin = 19  # Green
pi.set_mode(blue_pin, pigpio.OUTPUT)

def main():
    set_colour(255, 0, 0)  # Red
    sleep(1)
    set_colour(0, 255, 0)  # Green
    sleep(1)
    set_colour(0, 0, 255)  # Blue
    sleep(1)
    set_colour(255, 255, 255)  # White
    sleep(1)
    set_colour(0, 0, 0)  # Off/Black
    sleep(1)

# Set the colour of the RGB LED
def set_colour(red, green, blue):
    pi.set_PWM_dutycycle(red_pin, adjust_value(red))
    pi.set_PWM_dutycycle(green_pin, adjust_value(green))
    pi.set_PWM_dutycycle(blue_pin, adjust_value(blue))

# Invert because of common anode
def adjust_value(colour_value):
    return 255 - colour_value

# Turn LED off and release resources
def cleanup():
    pi.write(red_pin, 1)
    pi.write(green_pin, 1)
    pi.write(blue_pin, 1)
    pi.stop()  # terminate connection and release resources

if __name__ == "__main__":
    main()
    cleanup()
