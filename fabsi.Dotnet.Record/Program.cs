using fabsi.Dotnet.Record;
using System.Runtime.InteropServices;

var dealRecord = new DealDtoRecord(
    Id: 1,
    FullName: "Pink Lady Apfel 1kg 3.99€",
    ProductName: "Pink Lady",
    BasePrice: null,
    DealPrice: 2.00d,
    From: DateTime.UtcNow,
    To: DateTime.UtcNow.AddDays(7),
    Created: DateTime.UtcNow
);

var dealClass = new DealDtoClass
{
    Id = 1,
    FullName = "Pink Lady Apfel 1kg 3.99€",
    ProductName = "Pink Lady",
    BasePrice = null,
    DealPrice = 2.00d,
    From = DateTime.UtcNow,
    To = DateTime.UtcNow.AddDays(7),
    Created = DateTime.UtcNow
};

Console.WriteLine($"Record deal size '{ Marshal.SizeOf<DealDtoRecord>() }'");
Console.WriteLine($"Class deal size '{ Marshal.SizeOf<DealDtoClass>() }'");

namespace fabsi.Dotnet.Record
{
    public record DealDtoRecord(
        int Id,
        string FullName,
        string ProductName,
        double? BasePrice,
        double DealPrice,
        DateTime From,
        DateTime To,
        DateTime Created
    );

    [StructLayout(LayoutKind.Sequential)]
    public class DealDtoClass
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ProductName { get; set; }
        public double? BasePrice { get; set; }
        public double DealPrice { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime Created { get; set; }
    }

    public static class UnmanagedSizeofHelper
    {
        public static unsafe int SizeofType<TType>()
            where TType : unmanaged
        {
            return sizeof(TType);
        }
    }
}