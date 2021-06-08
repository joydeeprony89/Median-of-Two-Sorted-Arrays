using System;

namespace Median_of_Two_Sorted_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            //var nums1 = new int[] { 23, 26, 31, 35 };
            //var nums2 = new int[] { 3, 5, 7, 9, 11, 16 };
            var nums1 = new int[] { 1, 2 };
            var nums2 = new int[] { 3, 4 };
            Console.WriteLine(p.FindMedianSortedArrays(nums1, nums2));
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;
            if (n > m)
                FindMedianSortedArrays(nums2, nums1);
            int start = 0, end = n;
            while (start <= end)
            {
                int partitionx = (start + end) / 2;
                int partitiony = (n + m + 1) / 2 - partitionx;
                int maxLeftX = partitionx == 0 ? int.MinValue : nums1[partitionx - 1];
                int maxLeftY = partitiony == 0 ? int.MinValue : nums2[partitiony - 1];

                int minRightX = partitionx == n ? int.MaxValue : nums1[partitionx];
                int minRightY = partitiony == m ? int.MaxValue : nums2[partitiony];

                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {
                    if ((n + m) % 2 == 0)
                    {
                        double add = (double)(Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY));
                        double avg = add / 2;
                        return avg;
                    }
                    else
                    {
                        return (double)Math.Max(maxLeftX, maxLeftY);
                    }
                }
                else if (maxLeftX > minRightY) end = partitionx - 1;
                else start = partitionx + 1;
            }

            return 0.00000;
        }
    }
}
