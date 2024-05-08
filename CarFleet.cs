/*
It can be stipulated that all cars within a car fleet is limited to the speed of the slowest car in the front.
In other words, if there are x number of car fleets, then there are x number of slowest cars.
To extend this idea, a car fleet that is faster than the slowest car in the front of another fleet will catch up to the slower car (given the available distance).

We can figure out the number of rounds it takes (time "t") for each car to reach the target using the formula:
(float)(target - position)/speed

If we pair up the cars to their speed, then sort them by their descending position,
we can then determine if the car in front will be blocked by the car behind it if
the time "t" for the car behind is less than the time "t" for the car in front.

____________ EX 1 ____________
target = 12, position = [10,8,0,5,3], speed = [2,4,1,1,3]
output = 3

1x [12,12,1,6,6] Fleet 1 Arrived
...
7x [12,12,7,12,12] Fleet 2 Arrived
...
12x [12,12,12,12,12] Fleet 3 Arrived

____________ EX 2 ____________
target = 100, position = [0,2,4], speed = [4,2,1]
output = 1

1x [4,4,5]
2x [6,6,6]
...
100x [100,100,100] Fleet 1 Arrived



[{10,2}, {8,4}, {5,1}, {3,3}, {0,1}]
(float)(target - position)/speed
(12-10)/2 = 1
(12-8)/4 = 1
(12-5)/1 = 7
(12-3)/3 = 3
(12-0)/1 = 12

*/

public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        if (position.Length == 1)
        {
            return 1;
        }

        var list = new List<CarPair>();

        for (int i = 0; i < position.Length; i++)
        {
            list.Add(new CarPair(position[i], speed[i]));
        }

        // Order the list from front to back. 
        var orderedCars = list.OrderByDescending(x => x.Position);

        //Console.WriteLine($"Ordered:{Environment.NewLine}{string.Join("," + Environment.NewLine, orderedCars.Select(x => new { x.Position, x.Speed }))}]");

        var init = (target - orderedCars.First().Position) / (double)orderedCars.First().Speed;

        var stack = new Stack<double>();
        stack.Push(init);

        foreach (var car in orderedCars)
        {
            var timeToTarget = (target - car.Position) / (double)car.Speed;
            //Console.WriteLine($"TimeToTarget[{car.Position}, {car.Speed}]={timeToTarget}");

            if (stack.Peek() >= timeToTarget)
            {
                continue;
            }
            else
            {
                stack.Push(timeToTarget);
            }
        }

        return stack.Count;
    }

    
    private class CarPair
    {
        public CarPair(int position, int speed)
        {
            Position = position;
            Speed = speed;
        }

        public int Position { get; set; }
        public int Speed { get; set; }
    }
}