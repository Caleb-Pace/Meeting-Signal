#!/bin/bash
readonly SSID=$(iwgetid -r)
readonly IP=$(hostname -I)
echo $SSID
echo $IP
