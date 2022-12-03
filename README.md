# DriveASC

Drive Advanced Servo Control.

![driveasc-1 3_2013-04-02__01](https://user-images.githubusercontent.com/11328666/205463128-6cc020d2-6124-496f-99fa-582852d34d65.png)

## Project Structure

- `src` - source code.
    - `DriveAsc` application for `Kollmorgen S300/700` series.
    - `KeyAsc` to register a DriveAsc application.
- `doc` Incomplete [user manual for v 1.2.2](doc/README.md). In-app macros format definition.
    - `protocol` descriptions of low level commands to manage Kollmorgen servo-control.
- `data` samples from/for digital oscilloscope.

There is a branch with the name `beckhoff-ax2k`. This is an adaptation for `Beckhoff AX2000` series. This series is just a rebranding of the Kollmorgen S700 series. See [Beckhoff AX2000](#beckhoff-ax2000) chapter.

## Kollmorgen S300/700

### 1.3.0 (May 2013)

![driveasc-1 3_2013-04-02__02](https://user-images.githubusercontent.com/11328666/205463131-5cd42e60-cbf7-441f-a3ab-e437bdf0c4f7.png)

- Просмотр .CSV файлов осциллографа Kollmorgen DriveGUI.
- Цифровой, шестиканальный осциллограф.
- Поддержка Windows XP/Vista/7/8 (.NET 4.0)
- Новый графический интерфейс.
- Автоматический контроль подключения/отключения/перезагрузки.
- Многострочный терминал: возможность отправки списка команд.

### 1.2.2 (Sep 2012)

See [user manual for v 1.2.2](doc/README.md).

![main-window_v1 2 2](https://user-images.githubusercontent.com/11328666/205463092-3258ed4f-47b1-47da-9c84-0ebf36efc11c.png)

## Beckhoff AX2000

An experimental adaptation for `Beckhoff AX2000` series servo drives.

> git checkout `beckhoff-ax2k`

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
