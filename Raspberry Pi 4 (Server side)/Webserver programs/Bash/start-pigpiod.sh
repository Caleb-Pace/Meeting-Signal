#!/bin/bash
[ -z $(ps -eo 'comm' | grep pigpiod) ] && sudo pigpiod start
