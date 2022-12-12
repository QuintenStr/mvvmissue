using System;

namespace ImmoWin.ConsoleApp
{
    internal interface IAppartement : IWoning, IComparable<IAppartement>
    {
        byte Verdieping { get; }
    }
}