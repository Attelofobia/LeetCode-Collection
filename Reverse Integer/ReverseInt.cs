//Problem: https://leetcode.com/problems/reverse-integer/description/?page=1
void reverseInt(int x)
{
    bool isNegativ = x < 0;
    string str = Math.Abs((long)x).ToString();
    string reversedStr = new(str.Reverse().ToArray());
    if (int.TryParse(reversedStr, out int result))
    {
        result = isNegativ ? result * -1 : result;
        Console.WriteLine(result);
    }
    else
    {
        Console.WriteLine(0);
    }

}
reverseInt(-123);
reverseInt(123);
reverseInt(1534236469);