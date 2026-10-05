#Problem: https://leetcode.com/problems/integer-to-roman/description/?page=1

numerals = [
    (1000, "M"),
    (900, "CM"),
    (500, "D"),
    (400, "CD"),
    (100, "C"),
    (90, "XC"),
    (50, "L"),
    (40, "XL"),
    (10, "X"),
    (9, "IX"),
    (5, "V"),
    (4, "IV"),
    (1, "I")
]
def intToRoman(num: int, check: str):
    result = ""
    for value, symbol in numerals:
        while (num >= value):
            num -= value
            result += symbol
    print(result," ", result == check,"\n")

intToRoman(3749, "MMMDCCXLIX")
intToRoman(58, "LVIII")
intToRoman(1994, "MCMXCIV")