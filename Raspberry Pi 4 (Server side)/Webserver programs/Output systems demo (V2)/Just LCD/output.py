#!/usr/bin/env python2.7
import sys
from rpi_lcd import LCD


# Output
def main():
    # LCD character display
    print("Args: {}".format(len(sys.argv)))  # TEMP
    if len(sys.argv) > 1:
        lcd = LCD()
        lcd.text(sys.argv[1], 1)
        print("L1: \"{}\"".format(sys.argv[1]))  # TEMP
    if len(sys.argv) > 2:
        lcd.text(sys.argv[2], 2)
        print("L2: \"{}\"".format(sys.argv[2]))  # TEMP


if __name__ == "__main__":
    main()
