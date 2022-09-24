<?php

// Sanitises input and prepares it for shell_exec
function Sanitise($input) {
  $input = str_replace(" ", "/@s", $input);   // Spaces
  $input = str_replace("\\", "\\\\", $input); // Escape character
  $input = str_replace(";", "\\;", $input);   // Command separator
  $input = str_replace(":", "\\:", $input);   // Conditional else
  $input = str_replace("*", "\\*", $input);   // Wildcards - Character Sequence
  $input = str_replace("?", "\\?", $input);   // Wildcards - Single character
  $input = str_replace("[", "\\[", $input);   // Wildcards - Group (Start)
  $input = str_replace("]", "\\]", $input);   // Wildcards - Group (End)
  $input = str_replace("<", "\\<", $input);   // Redirection - Input
  $input = str_replace(">", "\\>", $input);   // Redirection - Output
  $input = str_replace("$", "\\$", $input);   // Varible expression
  $input = str_replace("(", "\\(", $input);   // Evaluate first (Start)
  $input = str_replace(")", "\\)", $input);   // Evaluate first (End)
  $input = str_replace("{", "\\{", $input);   // Expand variable (Start)
  $input = str_replace("}", "\\}", $input);   // Expand variable (End)
  $input = str_replace("|", "\\|", $input);   // Pipe
  $input = str_replace("!", "\\!", $input);   // History, Not and more
  return $input; // Return cleaned input
}


//=/ Parameter
$rgb = empty($_GET["rgb"]) ? "000000" : $_GET["rgb"]; // RGB LED (Empty => off)
$lcd_line_1 = empty($_GET["lcd_line_1"]) ? "/@0" : $_GET["lcd_line_1"]; // LCD character display line 1
$lcd_line_2 = empty($_GET["lcd_line_2"]) ? "/@0" : $_GET["lcd_line_2"]; // LCD character display line 2

//=/ Sanitise input
$rgb = Sanitise($rgb);
$lcd_line_1 = Sanitise($lcd_line_1);
$lcd_line_2 = Sanitise($lcd_line_2);

//=/ Run output.py and show response
$command = "sudo python output.py ".$rgb." ".$lcd_line_1." ".$lcd_line_2;
echo "Command: \"".$command."\"<br/><br/>Output:<br/>";
var_dump(shell_exec($command." 2>&1"));

?>
