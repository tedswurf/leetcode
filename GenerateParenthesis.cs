/*
Despite the categorization of this question under stack, it is more of a backtracking/Depth First Search problem.
Backtracking (a form of DFS) In backtracking, we search depth-first for solutions, backing up whenever none can be found along a path.
This is done by choosing a likely candidate solution and then testing it. If it's not a solution, we backtrack and try another candidate.
It incrementally builds candidates to the solutions, and abandons a candidate ("backtrack") as soon as it determines that the candidate
cannot possibly be completed to a valid solution.

For this problem, we can use backtracking to generate all possible combinations of n pairs of parentheses.
Only add open parenthesis if numOpen < n
Only add closed parenthesis if numClosed < numOpen
If numOpen == numClosed == n, add the finished parenthesis unit to the container
*/

public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var container = new List<string>();

        BackTrack(container, 0, 0, n, "");

        return container;
    }

    private void BackTrack(List<string> container, int numOpen, int numClosed, int n, string unit)
    {
        if (numOpen == numClosed && numClosed == n)
        {
            //Console.WriteLine($"Adding {unit}");
            container.Add(unit);
            return;
        }

        if (numOpen < n)
        {
            //Console.WriteLine($"{unit}");
            BackTrack(container, numOpen + 1, numClosed, n, $"{unit}(");
        }
        
        if (numClosed < numOpen)
        {
            //Console.WriteLine($"{unit}");
            BackTrack(container, numOpen, numClosed + 1, n, $"{unit})");
        }
    }
}