# Meeting-Signal
My Year 13 DT Project is the Meeting Signal. It indicates when the user is in a meeting using a physical device.

## Manual
(This will be provided alongside the project)

**Sections**
- [Inital Setup](https://github.com/Caleb-Pace-School/Meeting-Signal/new/main?readme=1#initial-setup) *(Do this one first)*
- [How to connect the Signal](https://github.com/Caleb-Pace-School/Meeting-Signal/new/main?readme=1#how-to-connect-the-signal)
- [Colours!? And what they mean?](https://github.com/Caleb-Pace-School/Meeting-Signal/new/main?readme=1#colours-and-what-they-mean)

---
### Initial Setup
This section will show you how to connect to your Meeting Signal
1. Install the Meeting Signal executable on the device that will be running the meetings
2. Place the Meeting Signal device (Raspberry Pi) in an easily visible location
3. Connect the Raspberry Pi to a monitor, keyboard and mouse
4. Turn it on
5. Connect to the same Wi-Fi network as your meeting device

---
### How to connect the Signal
1. Plug the Signal device in and wait for it to start up
<br/>*Once started; the Signal device will show this message on the LCD*
<br/>![Meeting Signal - Startup.png](Manual%20Images/Meeting%20Signal%20-%20Startup.png)
2. Start the executable on your meeting device
3. Type the IP address provided *(Line 2 of the LCD)* into the executable in the IP textbox
<br/>*The IP textbox is highlighted*
<br/>![GUI - IP textbox highlighted.png](Manual%20Images/GUI%20-%20IP%20textbox%20highlighted.png)
4. Wait for connection (This can take up to 10 seconds)

You are All Set!

---
### Colours!? And what they mean.
The colours indicate the state of the meeting. They will be shown in the GUI and using the RGB LED.

![#7FFF00](Manual%20Images/%237FFF00.png)
**Green/Chartreuse**
<br/>Not connected!

![#000000](Manual%20Images/%23000000.png)
**Black or Off**
<br/>Connected but not meeting

![#FF0000](Manual%20Images/%23FF0000.png)
**Red**
<br/>In a meeting (Webcam off)

![#FF00FF](Manual%20Images/%23FF00FF.png)
**Purple/Magenta/Fuchsia**
<br/>In meeting and webcam is on
