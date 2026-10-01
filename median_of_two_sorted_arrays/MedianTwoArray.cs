using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

int[] nums1 = [2,4];
int[] nums2 = [1,3];

if (nums1.Length > nums2.Length)
{
    var temp = nums1;
    nums1 = nums2;
    nums2 = temp;
}

int m = nums1.Length;
int n = nums2.Length;
int low = 0;
int high = m;

while (low <= high)
{
    int partition1 = (low + high) / 2;
    int partition2 = (m + n + 1) / 2 - partition1;

    double maxLeft1 = (partition1 == 0) ? double.MinValue : nums1[partition1 - 1];
    double minRight1 = (partition1 == m) ? double.MaxValue : nums1[partition1];

    double maxLeft2 = (partition2 == 0) ? double.MinValue : nums2[partition2 - 1];
    double minRight2 = (partition2 == n) ? double.MaxValue : nums2[partition2];

    if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1)
    {
        if ((m + n) % 2 == 0)
        {
            Console.WriteLine((Math.Max(maxLeft1, maxLeft2) + Math.Min(minRight1, minRight2)) / 2.0);
        }
        else
        {
            Console.WriteLine(Math.Max(maxLeft1, maxLeft2));
        }
    }
    else if (maxLeft1 > minRight2)
    {
        high = partition1 - 1;
    }
    else
    {
        low = partition1 + 1;
    }
}
