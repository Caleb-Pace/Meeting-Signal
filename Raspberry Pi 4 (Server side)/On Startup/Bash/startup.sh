#!/bin/bash
sudo /bin/bash /var/www/html/start-pigpiod.sh # Start pigpio Daemon for Hardware PWM
readonly SSID=$(iwgetid -r)
readonly IP=$(hostname -I)
sudo /usr/bin/python /var/www/html/output.py 7FFF00 ${SSID// /"/@s"} $IP # Display network info
exit 0
