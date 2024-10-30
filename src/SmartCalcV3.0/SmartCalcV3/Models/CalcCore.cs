using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using ReactiveUI;

namespace SmartCalcV3.Models
{
    public class CalcCore
    {
        [DllImport("./CoreLibs/coreCpp.dylib", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern string CalculateWrapper(string expression);
        
        [DllImport("./include/coreCpp.dylib", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GetGraphWrapper(string expression, double leftBound, double rightBound);

        [DllImport("./include/coreCpp.dylib", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetXArrayWrapper();

        [DllImport("./include/coreCpp.dylib", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetYArrayWrapper();

        [DllImport("./include/coreCpp.dylib", CallingConvention = CallingConvention.Cdecl)]
        private static extern int FreeArrayMemoryWrapper(IntPtr ptr);
        
        public string Calculate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                expression = "0";
            }

            try
            {
                var result = CalculateWrapper(expression);
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        
        public static void GetGraph(string? expression, double leftBound, double rightBound)
        {
            if (String.IsNullOrWhiteSpace(expression))
            {
                expression = "0";
            }

            GetGraphWrapper(expression, leftBound, rightBound);
            List<double> x = GetVector(GetXArrayWrapper);
            List<double> y = GetVector(GetYArrayWrapper);
            foreach (var x_var in x)
            {
                Console.WriteLine(x_var);
            }
        }

        private static List<double> GetVector(Func<IntPtr> getVectorWrapper)
        {
            var size = 1000;
            var vectorPtr = getVectorWrapper();
            var vector = new double[size];
            Marshal.Copy(vectorPtr, vector, 0, size);

            FreeArrayMemoryWrapper(vectorPtr);
            return new List<double>(vector);
        }
    }
}