#!/bin/bash
[ -z $(ps -eo 'comm' | grep pigpiod) ] && sudo pigpiod start # Check if the PiGPIO daemon is running if not start it
