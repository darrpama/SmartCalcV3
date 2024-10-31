using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using LiveChartsCore.Defaults;
using ReactiveUI;

namespace SmartCalcV3.Models
{
    public class CalcCore
    {
        [DllImport("./CoreLibs/coreCpp.dylib", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern string CalculateWrapper(string expression);
        
        [DllImport("./CoreLibs/coreCpp.dylib", CallingConvention = CallingConvention.Cdecl)]
        private static extern string GetGraphWrapper(string expression, double leftBound, double rightBound);

        [DllImport("./CoreLibs/coreCpp.dylib", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetXArrayWrapper();

        [DllImport("./CoreLibs/coreCpp.dylib", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetYArrayWrapper();

        [DllImport("./CoreLibs/coreCpp.dylib", CallingConvention = CallingConvention.Cdecl)]
        private static extern int FreeArrayMemoryWrapper(IntPtr ptr);
        
        public string Calculate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                expression = "0";
            }
            
            var result = CalculateWrapper(expression);
            Console.WriteLine(result);
            return result;
        }
        
        public List<ObservablePoint> GetGraph(string? expression, double leftBound, double rightBound)
        {
            if (String.IsNullOrWhiteSpace(expression))
            {
                expression = "0";
            }

            var result = GetGraphWrapper(expression, leftBound, rightBound);
            
            if (!string.IsNullOrWhiteSpace(result))
            {
                return new List<ObservablePoint>();
            }
            
            List<double> x = GetVector(GetXArrayWrapper);
            List<double> y = GetVector(GetYArrayWrapper);
            
            var points = new List<ObservablePoint>();
            for (int i = 0; i < x.Count; i++)
            {
                points.Add(new ObservablePoint(x[i], y[i]));
            }

            return points;
        }

        private List<double> GetVector(Func<IntPtr> getVectorWrapper)
        {
            var size = 1001;
            var vectorPtr = getVectorWrapper();
            var vector = new double[size];
            Marshal.Copy(vectorPtr, vector, 0, size);

            FreeArrayMemoryWrapper(vectorPtr);
            return new List<double>(vector);
        }
    }
}