# !/usr/bin/env python2.7
import RPi.GPIO as GPIO
from time import sleep


# GPIO setup
GPIO.setwarnings(False)
GPIO.setmode(GPIO.BCM)

red_pin = 12  # Red PWM Setup
GPIO.setup(red_pin, GPIO.OUT)  # Set red_pin to output
red_pwm = GPIO.PWM(red_pin, 2000)  # PWM at 2 kHz
red_pwm.start(0)  # Start at 0% duty cycle

green_pin = 13  # Blue PWM Setup
GPIO.setup(green_pin, GPIO.OUT)  # Set green_pin to output
green_pwm = GPIO.PWM(green_pin, 2000)  # PWM at 2 kHz
green_pwm.start(0)  # Start at 0% duty cycle

blue_pin = 19  # Green PWM Setup
GPIO.setup(blue_pin, GPIO.OUT)  # Set blue_pin to output
blue_pwm = GPIO.PWM(blue_pin, 2000)  # PWM at 2 kHz
blue_pwm.start(0)  # Start at 0% duty cycle


def main():
    set_colour(100, 0, 0)  # Red
    sleep(1)
    set_colour(0, 100, 0)  # Green
    sleep(1)
    set_colour(0, 0, 100)  # Blue
    sleep(1)
    set_colour(100, 100, 100)  # White
    sleep(1)
    set_colour(0, 0, 0)  # Off/Black
    sleep(1)

def set_colour(red, green, blue):
    red_pwm.ChangeDutyCycle(adjust_value(red))
    green_pwm.ChangeDutyCycle(adjust_value(green))
    blue_pwm.ChangeDutyCycle(adjust_value(blue))

def adjust_value(colour_value):
    return 100 - colour_value

def cleanup():
    red_pwm.stop()
    green_pwm.stop()
    blue_pwm.stop()
    GPIO.cleanup()

if __name__ == "__main__":
    main()
    cleanup()