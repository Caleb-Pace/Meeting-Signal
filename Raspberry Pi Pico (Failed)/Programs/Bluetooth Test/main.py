from machine import Pin, UART

uart = UART(0, 9600)  # RX-->GP0; TX-->GP01
LedGPIO = 16
led = Pin(LedGPIO, Pin.OUT)

while True:
    if uart.any():
        command = uart.readline()
        print(command)  # uncomment this line to see the received data
        if command == b'\x31':  # Text '1' = chr(0x31)
            led.on()
            print("ON")
        elif command == b'\x30':  # Text '0' = chr(0x30)
            led.off()
            print("OFF")
