<?php

//=/ Parameter meanings
// lcd_line_1: LCD character display line 1
// lcd_line_2: LCD character display line 2
echo "Line 1: \"".$_GET["lcd_line_1"]."\"<br/>";
echo "Line 2: \"".$_GET["lcd_line_2"]."\"<br/>";
echo "Command: \""."sudo -E python output.py ".$_GET["lcd_line_1"]." ".$_GET["lcd_line_2"]."\"<br/><br/>Output:<br/>";
// shell_exec("sudo -E python output.py ".$_GET["lcd_line_1"]." ".$_GET["lcd_line_2"]);
var_dump(shell_exec("sudo -E python output.py ".$_GET["lcd_line_1"]." ".$_GET["lcd_line_2"]." 2>&1"));

?>
