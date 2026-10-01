using System;
using System.Diagnostics;

double[] nums1 = [1,3,5,7,9,11,13,15,17,19];
double[] nums2 = [2,4,6,8,10,12,14,16,18];

double FindMedianOptimal(double[] shorter, double[] longer)
{
    // Ensure shorter is the smaller array to optimize binary search range
    if (shorter.Length > longer.Length)
    {
        return FindMedianOptimal(longer, shorter);
    }
    
    int m = shorter.Length;
    int n = longer.Length;
    int low = 0, high = m;
    
    while (low <= high)
    {
        // Partition points for both arrays
        int partition1 = (low + high) / 2;
        int partition2 = (m + n + 1) / 2 - partition1;
        
        // Edge cases: if partition is 0, nothing on left. If partition is length, nothing on right.
        double maxLeft1 = (partition1 == 0) ? double.MinValue : shorter[partition1 - 1];
        double minRight1 = (partition1 == m) ? double.MaxValue : longer[partition1];
        
        double maxLeft2 = (partition2 == 0) ? double.MinValue : longer[partition2 - 1];
        double minRight2 = (partition2 == n) ? double.MaxValue : longer[partition2];
        
        // Check if we found the correct partition
        if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1)
        {
            // If total elements are even
            if ((m + n) % 2 == 0)
            {
                return (Math.Max(maxLeft1, maxLeft2) + Math.Min(minRight1, minRight2)) / 2.0;
            }
            // If total elements are odd
            else
            {
                return Math.Max(maxLeft1, maxLeft2);
            }
        }
        // We are too far right in nums1, need to move left
        else if (maxLeft1 > minRight2)
        {
            high = partition1 - 1;
        }
        // We are too far left in nums1, need to move right
        else
        {
            low = partition1 + 1;
        }
    }
    
    throw new ArgumentException("Input arrays are not sorted.");
}

Console.WriteLine(FindMedianOptimal(nums1, nums2));