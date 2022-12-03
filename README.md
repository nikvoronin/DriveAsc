# DriveASC

Drive Advanced Servo Control.

/// Picture here /

## Project Structure

- `src` - source code.
    - `DriveAsc` application for `Kollmorgen S300/700` series.
    - `KeyAsc` to register a DriveAsc application.
- `doc` Incomplete [user manual for v 1.2.2](doc/README.md). In-app macros format definition.
    - `protocol` descriptions of low level commands to manage Kollmorgen servo-control.
- `data` samples from/for digital oscilloscope.

There is a branch with the name `beckhoff-ax2k`. This is an adaptation for `Beckhoff AX2000` series. This series is just a rebranding of the Kollmorgen S700 series. See [Beckhoff AX2000](#beckhoff-ax2000) chapter.

## Kollmorgen S300/700

1.3.0 (May 2013)

- Просмотр .CSV файлов осциллографа Kollmorgen DriveGUI.
- Цифровой, шестиканальный осциллограф.
- Поддержка Windows XP/Vista/7/8 (.NET 4.0)
- Новый графический интерфейс.
- Автоматический контроль подключения/отключения/перезагрузки.
- Многострочный терминал: возможность отправки списка команд.

1.2.2 (Sep 2012)

/// Picture here /

## Beckhoff AX2000

Experimental adaptation for `Beckhoff AX2000`.

1.3.1 (Oct 2013)

- changed connection speed of the serial port from 38400 to 9600. See `manage\Km.cs`:

```csharp
/// <summary>
/// By default 38400, no parity, 8 bits, 1 stop bit, 300 ms timeout, 80 bytes buffer
/// </summary>
/// <param name="portName"COM-port name></param>
/// <returns>true - if port opened successfully, false - otherwise</returns>
private bool OpenPort(string portName)
{
    try {
        ClosePort();
        _port = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
```

## Credits

- Kudos to Igor Kuryugin for help with servo commands etc.
- [Fugue Icons](http://p.yusukekamiyamane.com/) © 2010 Yusuke Kamiyamane. Under a Creative Commons Attribution 3.0 License
