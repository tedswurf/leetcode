/*
The secret here is to use two stacks
One to store all incoming values as they come in.
Second to store the minimum value at the top of the stack.
*/


public class MinStack {
    private Stack<int> stack { get; set; }

    // minStack contains the max number at the bottom
    // with the min number at the top.
    private Stack<int> minStack { get; set; }

    public MinStack() {
        stack = new Stack<int>();
        minStack = new Stack<int>();
    }
    
    public void Push(int val) {
        // if the new value is smaller than the min,
        // add the new smaller number to the top of minStack
        if (minStack.Count == 0 || val <= minStack?.Peek())
        {
            minStack.Push(val);
        }

        stack.Push(val);
    }
    
    public void Pop() {
        var top = stack.Pop();

        // if we remove a number that happens to be the smallest number
        // we need to remove it from minStack.
        if (minStack.Count != 0 && top == minStack.Peek())
        {
            minStack.Pop();
        }
    }
    
    public int Top() {
        return stack.Peek();
    }
    
    public int GetMin() {
        // The top of minStack will always be the min number.
        return minStack.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */