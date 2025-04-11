using System.Reflection;

namespace CleanArchitecture.Application;

public static class AssemblyReference
{
    public static readonly Assembly AssemblyName = typeof(AssemblyReference).Assembly;
}