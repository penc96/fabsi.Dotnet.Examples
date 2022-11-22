
using Microsoft.VisualBasic;
using System.Threading.Channels;

var oneMeterHdmiCable = new Cable(100, IsoCableType.Hdmi);
var twoMeterHdmiCable = new Cable(200, IsoCableType.Hdmi);

var threeMeterHdmiCable = oneMeterHdmiCable + twoMeterHdmiCable;

Console.WriteLine($"Adding '{oneMeterHdmiCable}' and '{twoMeterHdmiCable}'. Results in '{threeMeterHdmiCable}'");

enum IsoCableType
{
    Hdmi,
    DisplayPort,
    UsbC,
    UsbA
}

class Cable
{
    public int Length { get; set; }
    public IsoCableType CableType { get; set; }

    public Cable(int length, IsoCableType type)
    {
        Length = length;
        CableType = type;
    }

    public static Cable? operator +(Cable c1, Cable c2)
    {
        if (c1.CableType != c2.CableType)
            throw new Exception("=== THUNDER === THE CABLES ARE DESTROYED ===");
        return new Cable(c1.Length + c2.Length, c1.CableType);
    }

    public override string ToString()
    {
        return $"Cable '{CableType}' with length of '{Length}' cm";
    }
}