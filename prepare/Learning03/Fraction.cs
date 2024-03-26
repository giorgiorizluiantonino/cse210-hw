
using System;
public class Fraction
{
    private int _top;
    private int _bottom;

        public Fraction() 
        {
            _top = 1;
            _bottom = 1; 
            
        }

        public Fraction(int number)
        {
            _top = number;
            _bottom = 1;
        }

        public Fraction(int top, int bottom)
        {
            _top = top;
            _bottom = bottom;
        }

        public String GetFractionString()
    
        {
            string letter = $"{_top}/{_bottom}";
            return letter;
        }

        public double GetDecimalValue()
        {
            return (double)_top / (double)_bottom;
        }
}