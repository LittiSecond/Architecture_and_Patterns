using System;


namespace Task_lesson5_task2
{
    public class ProxyMath : IMyMath
    {
        private StrangeMath _strangeMath = null;

        public double divide(double devidend, double devisor1)
        {
            if (_strangeMath == null)
            {
                _strangeMath = new StrangeMath();
            }
            return _strangeMath.divide(devidend, devisor1);
        }

        public double minus(double d1, double d2)
        {
            return _strangeMath?.minus(d1, d2) ?? (_strangeMath = new StrangeMath()).minus(d1, d2);  // @_@
        }

        public double multiply(double d1, double d2)
        {
            if (_strangeMath == null) _strangeMath = new StrangeMath();
            return _strangeMath.multiply(d1, d2);
        }

        public double plus(double d1, double d2)
        {
            if (_strangeMath == null)
            {
                _strangeMath = new StrangeMath();
            }
            return _strangeMath.plus(d1, d2);  // эта запись мне нравится больше, чем два других варианта
        }
    }
}
