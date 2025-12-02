using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day1.Models
{
    public class Dial
    {
        public const int MaxPosition = 99;
        public const int MinPosition = 0;
        public int StartingPosition = 50;
        public int CurrentPosition;
        public int ZeroCounter = 0;
        public Dial()
        {
            CurrentPosition = StartingPosition;
        }

        public void Rotate(char direction, int amount)
        {
            if (amount > MaxPosition)
            {
                int remainder = amount % (MaxPosition + 1);
                amount = remainder;
            }
            if (direction == 'L')
            {
                CurrentPosition -= amount;
                if (CurrentPosition < MinPosition)
                {
                    CurrentPosition = MaxPosition + CurrentPosition + 1;
                }
            }
            else if (direction == 'R')
            {
                CurrentPosition += amount;
                if (CurrentPosition > MaxPosition)
                {
                    CurrentPosition = CurrentPosition - MaxPosition - 1;
                }
            }
            if (CurrentPosition == 0)
            {
                ZeroCounter++;
            }
        }

        public void RotateV2(char direction, int amount)
        {
            if(amount > MaxPosition)
            {
                int revolutions = amount / (MaxPosition+1);
                ZeroCounter += revolutions;
                int remainder = amount % (MaxPosition + 1);
                amount = remainder;
            }
            if (direction == 'L')
            {
                int prevPosition = CurrentPosition;
                CurrentPosition -= amount;
                if (CurrentPosition < MinPosition)
                {
                    CurrentPosition = MaxPosition + CurrentPosition + 1;
                    if(CurrentPosition != 0 && prevPosition != 0)
                    {
                        ZeroCounter++;
                    }
                }
            }
            else if (direction == 'R')
            {
                int prevPosition = CurrentPosition;
                CurrentPosition += amount;
                if (CurrentPosition > MaxPosition)
                {
                    CurrentPosition = CurrentPosition - MaxPosition - 1;
                    if (CurrentPosition != 0 && prevPosition != 0)
                    {
                        ZeroCounter++;
                    }
                }
            }
            if (CurrentPosition == 0)
            {
                ZeroCounter++;
            }
        }
    }
}
