<?php

shell_exec("sudo sh ./start-pigpiod.sh"); // Start pigpio Daemon for Hardware PWM

//=/ Parameter
$state = empty($_GET["state"]) ? "0" : $_GET["state"]; // Solid colour LED (Empty => off)
$rgb = empty($_GET["rgb"]) ? "000000" : $_GET["rgb"]; // RGB LED (Empty => off)
$lcd_line_1 = empty($_GET["lcd_line_1"]) ? "/@0" : $_GET["lcd_line_1"]; // LCD character display line 1
$lcd_line_2 = empty($_GET["lcd_line_2"]) ? "/@0" : $_GET["lcd_line_2"]; // LCD character display line 2

//=/ Sanitise input
// Spaces not allowed
str_replace(" ", "", $state);
str_replace(" ", "", $rgb);
// Sanitised space
str_replace(" ", "/@s", $lcd_line_1);
str_replace(" ", "/@s", $lcd_line_2);

//=/ Run output.py and show response
$command = "sudo python output.py ".$state." ".$rgb." ".$lcd_line_1." ".$lcd_line_2;
echo "Command: \"".$command."\"<br/><br/>Output:<br/>";
var_dump(shell_exec($command." 2>&1"));

?>
