<?php

shell_exec("sudo sh ./start-pigpiod.sh"); // Start pigpio Daemon for Hardware PWM

//=/ Parameter meanings
// lcd_line_1: LCD character display line 1
// lcd_line_2: LCD character display line 2
$state = empty($_GET["state"]) ? $_GET["state"] : "0"; // Solid colour LED (Empty => off)
$rgb = empty($_GET["rgb"]) ? $_GET["rgb"] : "000000"; // RGB LED (Empty => off)
shell_exec("sudo python output.py ".$state." ".$rgb." ".$_GET["lcd_line_1"]." ".$_GET["lcd_line_2"]);

?>
