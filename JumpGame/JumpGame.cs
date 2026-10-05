
bool CanJump(int[] nums) {
    switch (nums.Length)
    {
        case 0:
            return false;
        case 1:
            return true;
        default:
            break;
    }


    int mx = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (mx < i)
        {
            return false;
        }
        
        mx = Math.Max(mx, i + nums[i]);
    }

    return true;
}

Console.WriteLine(CanJump([2,3,1,1,4]));
Console.WriteLine(CanJump([3,2,1,0,4]));
Console.WriteLine(CanJump([2]));
Console.WriteLine(CanJump([]));