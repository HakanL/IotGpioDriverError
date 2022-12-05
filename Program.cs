using System;
using System.Device.Gpio;
using System.Device.Gpio.Drivers;
using System.Threading;

int pin = 17;

using GpioController controller = new(PinNumberingScheme.Logical, new SysFsDriver());

//using GpioController controller = new(PinNumberingScheme.Logical, new LibGpiodDriver());

//using GpioController controller = new(PinNumberingScheme.Logical);

var obj = controller.GetType().GetField("_driver", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
var driver = obj?.GetValue(controller);
Console.WriteLine($"GPIO Controller Driver = {driver?.GetType().Name}");


var gpioButton = new Iot.Device.Button.GpioButton(
    buttonPin: pin,
    gpio: controller,
    pinMode: System.Device.Gpio.PinMode.Input,
    debounceTime: TimeSpan.FromMilliseconds(50));

Console.WriteLine("Gpio initialized");

gpioButton.Press += (s, e) =>
{
    Console.WriteLine("GPIO 17 button pressed");
};

throw new Exception("Test");
