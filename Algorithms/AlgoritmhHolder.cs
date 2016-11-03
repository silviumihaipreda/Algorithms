using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strides
{
    public static class AlgorithmHolder
    {
        public static int ComputeNumberOfStrides(int[] steps, int stepsPerStride)
        {
            var strides = 0;
            var length = steps.Length;
            for (int i = 0; i < length; i++)
            {
                strides += steps[i] / stepsPerStride;
                strides += steps[i] % stepsPerStride == 0 ? 0 : 1;
                strides += i == length - 1 ? 0 : 2;
            }

            return strides;
        }

        public static int ComputeSafestPlaceDistance(int numberOfBombs, int[][] bombLocations)
        {
            var distance = 0;

            for (int i = 0; i < 1001; i++)
            {
                for (int j = 0; i < 1001; j++)
                {
                    for (int k = 0; k < 1001; k++)
                    {
                        var pointDistance = int.MaxValue;

                        for (int b = 0; b < numberOfBombs; b++)
                        {
                            if ((bombLocations[b][0] == i) && (bombLocations[b][1] == j) && (bombLocations[b][2] == k))
                                continue;

                            var localDistance = (bombLocations[b][0] - i) ^ 2 + (bombLocations[b][1] - j) ^ 2 + (bombLocations[b][2] - k) ^ 2;
                            if (pointDistance > localDistance)
                            {
                                pointDistance = localDistance;
                            }
                        }

                        if (distance < pointDistance)
                        {
                            distance = pointDistance;
                        }
                    }
                }
            }

            return distance;
        }

        public static byte[] AddRecursive(byte[] f, byte[] s)
        {
            var result = new byte[f.Length];

            result = AddRecursive_Private(f, s, result, f.Length - 1, 0);

            return result;
        }

        private static byte[] AddRecursive_Private(byte[] f, byte[] s, byte[] result, int position, int carry)
        {
            result[position] = (byte)(f[position] + s[position] + carry);

            int resultOfAddition = f[position] + s[position] + carry;

            carry = (resultOfAddition > byte.MaxValue) ? 1 : 0;

            if (position == 0)
            {
                return result;
            }
            else
            {
                return AddRecursive_Private(f, s, result, position - 1, carry);
            }
        }
    }
}
