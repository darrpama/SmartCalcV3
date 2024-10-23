using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SmartCalcV3.Models
{
    public class CalcCore
    {
        [DllImport("CoreLibs/SmartCalc2.a", CallingConvention = CallingConvention.Cdecl)]
        public static extern string CalculateExpression(StringBuilder expression);
    }
}