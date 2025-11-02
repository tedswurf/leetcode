class Solution:
    def mergeAlternately(self, word1: str, word2: str) -> str:
        len_1 = len(word1)
        len_2 = len(word2)

        if (len_1 == 0):
            return word2

        if (len_2 == 0):
            return word1

        if (len_1 == 0 and len_2 == 0):
            return ""

        list_1 = list(word1)
        list_2 = list(word2)

        point_1, point_2 = 0, 0
        is_1 = True

        merged = []

        # swap between word 1 and 2, while incrementing the counter to each one
        while(point_1 < len_1 and point_2 < len_2):
            if (is_1):
                merged.append(list_1[point_1])
                is_1 = False
                point_1 += 1
            else:
                merged.append(list_2[point_2])
                is_1 = True
                point_2 += 1

        # append whatever remaining elements are in either list
        merged.extend(list_1[point_1:])

        merged.extend(list_2[point_2:])

        return "".join(merged)