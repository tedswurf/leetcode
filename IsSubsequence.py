class Solution:
    def isSubsequence(self, s: str, t: str) -> bool:
        s_len = len(s)
        t_len = len(t)

        if (s_len == 0):
            return True

        if (s_len > t_len or t_len == 0):
            return False

        s_chars = list(s)
        t_chars = list(t)

        s_point, t_point = 0, 0

        while(s_point < s_len and t_point < t_len):
            if (s_chars[s_point] == t_chars[t_point]):
                s_point += 1
                t_point += 1
            else:
                t_point += 1
            #print(f"{s_point}, {t_point}")

    
        #print(f"s_point:{s_point}, s_len:{s_len}")

        return s_point >= s_len
                    