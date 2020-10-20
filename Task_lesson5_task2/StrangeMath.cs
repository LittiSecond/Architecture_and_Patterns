using System;


namespace Task_lesson5_task2
{
    // Класс, для которого нужно сделать заместителя
    public class StrangeMath : IMyMath
    {

        public double plus(double d1, double d2) => d1 + d2;
        public double plus(double d1, double d2, double d3) => d1 + d2 + d3;
        public double plus(double d1, double d2, double d3, double d4) => d1 + d2 + d3 + d4;
        public double plus(double d1, double d2, double d3, double d4, double d5) => d1 + d2 + d3 + d4 + d5;
        public double plus(double d1, double d2, double d3, double d4, double d5, double d6) => d1 + d2 + d3 + d4 + d5 + d6;

        public double minus(double d1, double d2) => d1 - d2;
        public double minus(double d1, double d2, double d3) => d1 - d2 - d3;
        public double minus(double d1, double d2, double d3, double d4) => d1 - d2 - d3 - d4;
        public double minus(double d1, double d2, double d3, double d4, double d5) => d1 - d2 - d3 - d4 - d5;
        public double minus(double d1, double d2, double d3, double d4, double d5, double d6) => d1 - d2 - d3 - d4 - d5 - d6;

        public double multiply(double d1, double d2) => d1 * d2;
        public double multiply(double d1, double d2, double d3) => d1 * d2 * d3;
        public double multiply(double d1, double d2, double d3, double d4) => d1 * d2 * d3 * d4;
        public double multiply(double d1, double d2, double d3, double d4, double d5) => d1 * d2 * d3 * d4 * d5;
        public double multiply(double d1, double d2, double d3, double d4, double d5, double d6) => d1 * d2 * d3 * d4 * d5 * d6;

        public double divide(double devidend, double devisor1) => devidend / devisor1;
        public double divide(double devidend, double devisor1, double devisor2) =>
            devidend / devisor1 / devisor2;
        public double divide(double devidend, double devisor1, double devisor2, double devisor3) =>
            devidend / devisor1 / devisor2 / devisor3;
        public double divide(double devidend, double devisor1, double devisor2, double devisor3, double devisor4) =>
            devidend / devisor1 / devisor2 / devisor3 / devisor4;
        public double divide(double devidend, double devisor1, double devisor2, double devisor3, double devisor4, double devisor5) => 
            devidend / devisor1 / devisor2 / devisor3 / devisor4 / devisor5;

        public double find_max(params double[] d_array)
        {
            int length = d_array.Length;
            if (length == 0)
            {
                throw new ArgumentException();
            }
            if (length == 1)
            {
                return d_array[0];
            }
            double max = d_array[0];
            for (int i = 1; i < length; i++)
            {
                double current = d_array[i];
                if (current > max)
                {
                    max = current;
                }
            }
            return max;
        }

    }
}
