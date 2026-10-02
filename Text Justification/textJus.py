#Problem: https://leetcode.com/problems/text-justification/description/

def seperateIntoLines(words: list[str], maxWidth: int) -> list[str]:
    lines: list[str] = []
    line_str: str = ""
    current_length: int = 0

    for word in words:
        # Check if adding this word (plus space if line isn't empty) exceeds maxWidth
        space_needed = 1 if line_str else 0
        
        if current_length + space_needed + len(word) <= maxWidth:
            if line_str:
                line_str += " "
                current_length += 1
            line_str += word
            current_length += len(word)
        else:
            # 1. Append the finished line to the array
            lines.append(line_str)
            
            # 2. Start a new line with the current word
            line_str = word
            current_length = len(word)

    # Don't forget to append the final line after the loop ends!
    if line_str:
        lines.append(line_str)

    return lines

def fillOutEmptySpace(lines: list[str], maxWidth: int) -> list[str]:
    for i, line in enumerate(lines):
        line_words = line.split()
        cnt_words = len(line_words)
        
        # Handle the last line or a line with only 1 word (Left-Justified)
        if i == len(lines) - 1 or cnt_words == 1:
            # Join words with single spaces and pad remaining spaces to the right
            justified_line = " ".join(line_words)
            justified_line += " " * (maxWidth - len(justified_line))
        
        # Middle lines with more than 1 word (Fully Justified)
        else:
            missing_spaces = maxWidth - len(line)  # spaces still needed beyond current single-space line
            spaces_per_gap = missing_spaces // (cnt_words - 1)
            extra_spaces = missing_spaces % (cnt_words - 1)
            
            justified_line = ""
            for idx, word in enumerate(line_words):
                justified_line += word
                
                # Add extra spaces behind every word except the last one
                if idx < cnt_words - 1:
                    # 1 base space + evenly distributed missing spaces
                    spaces_to_add = 1 + spaces_per_gap
                    
                    # Distribute leftover spaces from left to right
                    if idx < extra_spaces:
                        spaces_to_add += 1
                        
                    justified_line += " " * spaces_to_add

        # Crucial step: save the justified line back into the array
        lines[i] = justified_line

    return lines

def fullJustify(words: list[str], maxWidth: int) -> list[str]:
    lines = seperateIntoLines(words, maxWidth)
    return fillOutEmptySpace(lines, maxWidth)

words = ["This", "is", "an", "example", "of", "text", "justification."]
maxWidth = 10
lines = fullJustify(words, maxWidth)
for line in lines:
    print(line, len(line), "\n")