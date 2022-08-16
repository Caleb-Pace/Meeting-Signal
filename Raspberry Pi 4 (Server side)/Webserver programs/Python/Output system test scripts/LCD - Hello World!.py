#!/usr/bin/env python2.7
from rpi_lcd import LCD
from time import sleep


lcd = LCD()

lcd.text("Hello", 1)
lcd.text("World!", 2)

sleep(3)

lcd.clear()
