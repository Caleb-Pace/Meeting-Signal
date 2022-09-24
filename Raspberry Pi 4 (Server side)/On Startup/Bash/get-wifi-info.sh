#!/bin/bash
SSID=$(iwgetid -r)
IP=$(hostname -I)
echo $SSID
echo $IP
