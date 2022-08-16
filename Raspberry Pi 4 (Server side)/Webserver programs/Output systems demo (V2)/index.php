<?php

shell_exec("sudo sh ./start-pigpiod.sh");
shell_exec("sudo python output.py ".$_GET["state"]);

?>
