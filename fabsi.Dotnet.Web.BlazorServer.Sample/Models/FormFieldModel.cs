using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace fabsi.Dotnet.UI.Blazor.Server.Sample.Models;

public class FormFieldModel
{
    public string Name { get; set; } = string.Empty;
    public Func<string, bool> Validate { get; set; } = null!;
}