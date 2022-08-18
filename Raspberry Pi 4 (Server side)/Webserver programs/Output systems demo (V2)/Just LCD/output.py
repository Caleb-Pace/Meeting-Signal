#!/usr/bin/env python2.7
import sys
from rpi_lcd import LCD


# Output
def main():
    # LCD character display
    if len(sys.argv) > 1:
        lcd = LCD()
        lcd.text(sys.argv[1], 1)
    if len(sys.argv) > 2:
        lcd.text(sys.argv[2], 2)


if __name__ == "__main__":
    main()
