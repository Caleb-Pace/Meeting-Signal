<?php

//=/ Parameter meanings
// lcd_line_1: LCD character display line 1
// lcd_line_2: LCD character display line 2
shell_exec("sudo -E python output.py ".$_GET["lcd_line_1"]." ".$_GET["lcd_line_2"]);

?>
