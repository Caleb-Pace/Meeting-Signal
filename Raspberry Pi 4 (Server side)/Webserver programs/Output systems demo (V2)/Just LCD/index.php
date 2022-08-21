<?php

//=/ Parameter meanings
// lcd_line_1: LCD character display line 1
// lcd_line_2: LCD character display line 2
$command = "sudo python output.py ".$_GET["lcd_line_1"]." ".$_GET["lcd_line_2"];
echo "Command: \"".$command."\"<br/><br/>Output:<br/>";
var_dump(shell_exec($command." 2>&1"));

?>
