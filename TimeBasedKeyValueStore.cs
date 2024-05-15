/*
We require binary search in the Get method to find the largest time slot that is less than or equal to the target timestamp. linear search would be too slow.

The binary search problem at root here is a subproblem of KokoEatingBananas. More specifically Koko needs to find the SMALLEST possible eating speed k.
In this problem, we need to find the LARGEST possible time slot that is less than or equal to the target timestamp.

In essence, we store the value of the largest time slot found so far (aka pivot), and continue searching for a larger time slot
until the left point moves to the end of the list.
If we intially never find a time slot that is less than the target timestamp, we return "" (no solution).
*/

public class TimeMap {
    private readonly Dictionary<string, List<TimeSlot>> timeMap;

    public TimeMap() {
        timeMap = new ();
    }
    
    public void Set(string key, string value, int timeStamp) {
        var timeSlot = new TimeSlot(value, timeStamp);
        //Console.WriteLine($"Add {key}:{timeStamp}");

        if (timeMap.ContainsKey(key))
        {
            timeMap[key].Add(timeSlot);
        }
        else
        {
            timeMap.Add(key, new List<TimeSlot> { timeSlot });
        }
    }
    
    public string Get(string key, int timestamp) {
        if (timeMap.ContainsKey(key))
        {
            //Console.WriteLine($"{Environment.NewLine}Get {key}:{timestamp} within [{string.Join(",", timeMap[key].Select(x => x.TimeStamp))}]");
            var timeSlots = timeMap[key];
            var left = 0;
            var right = timeSlots.Count() - 1;

            var largest = timeSlots[left];
            var found = false;

            while (left <= right)
            {
                var pivot = (left + right)/2;

                var middle = timeSlots[pivot];

                //Console.WriteLine($"mid[{pivot}]={middle.Value}:{middle.TimeStamp} -> largest = {largest.Value}:{largest.TimeStamp}");

                if (middle.TimeStamp < timestamp)
                {
                    // This could be the closest timeslot. Save it for now.
                    largest = middle.TimeStamp > largest.TimeStamp ? middle : largest;
                    found = true;

                    // We should check and see if there are biggest TimeSlots closer to timeStamp.
                    left = pivot + 1;
                }
                else if (middle.TimeStamp > timestamp)
                {
                    right = pivot - 1;
                }
                else
                {
                    return middle.Value;
                }
            }

            return found ? largest.Value : "";
        }
        else
        {
            //Console.WriteLine($"Not Found {key}:{timestamp}");
            return "";
        }
    }

    private class TimeSlot
    {
        public TimeSlot(string value, int timeStamp)
        {
            Value = value;
            TimeStamp = timeStamp;
        }

        public string Value { get; set; }
        public int TimeStamp { get; set; }
    }
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */