using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_C_Sharp_Advanced.Exercises
{
    public static class StacksAndQueues
    {
        /// <summary>
        /// 01. Basic Stack Operations
        /// </summary>
        public static void BasicStackOperations()
        {
            var commands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = commands[0];
            var s = commands[1];
            var x = commands[2];

            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            var smallest = 0;

            while (stack.Count > 0)
            {
                if (x == stack.Peek())
                {
                    Console.WriteLine("true");
                    return;
                }

                var current = stack.Pop();

                if (smallest > current || smallest == 0)
                {
                    smallest = current;
                }
            }

            Console.WriteLine(smallest);
        }

        /// <summary>
        /// 02. Basic Queue Operations
        /// </summary>
        public static void BasicQueueOperations()
        {
            var commands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = commands[0];
            var s = commands[1];
            var x = commands[2];

            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            var smallest = 0;

            while (queue.Count > 0)
            {
                if (x == queue.Peek())
                {
                    Console.WriteLine("true");
                    return;
                }

                var current = queue.Dequeue();

                if (smallest > current || smallest == 0)
                {
                    smallest = current;
                }
            }

            Console.WriteLine(smallest);
        }

        /// <summary>
        /// 03. Maximum and Minimum Element
        /// </summary>
        public static void MaximumAndMinimumElement()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var bufferStack = new Stack<int>();
            int? max = null;
            int? min = null;

            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var command = commands.FirstOrDefault();

                switch (command)
                {
                    case 1: stack.Push(commands[1]); break;
                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        max = CalculateMax(stack, bufferStack, max);
                        break;
                    case 4:
                        min = CalculateMin(stack, bufferStack, min);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stack));

            static int? CalculateMax(Stack<int> stack, Stack<int> bufferStack, int? max)
            {
                while (stack.Count > 0)
                {
                    var currentVal = stack.Pop();

                    if (max == null || currentVal > max)
                    {
                        max = currentVal;
                    }

                    bufferStack.Push(currentVal);
                }

                while (bufferStack.Count > 0)
                {
                    stack.Push(bufferStack.Pop());
                }

                Console.WriteLine(max);
                return max;
            }

            static int? CalculateMin(Stack<int> stack, Stack<int> bufferStack, int? min)
            {
                while (stack.Count > 0)
                {
                    var currentVal = stack.Pop();

                    if (min == null || currentVal < min)
                    {
                        min = currentVal;
                    }

                    bufferStack.Push(currentVal);
                }

                while (bufferStack.Count > 0)
                {
                    stack.Push(bufferStack.Pop());
                }

                Console.WriteLine(min);
                return min;
            }
        }

        /// <summary>
        /// 04. Fast Food 80/100
        /// </summary>
        public static void FastFood()
        {
            var quantity = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToList();
            var queue = new Queue<int>();
            var biggestOrder = 0;

            foreach (var order in orders)
            {
                queue.Enqueue(order);
            }

            while (queue.Count > 0)
            {
                if (queue.Peek() <= quantity)
                {
                    var currentOrder = queue.Dequeue();

                    if (currentOrder > biggestOrder)
                    {
                        biggestOrder = currentOrder;
                    }

                    quantity -= currentOrder;
                }
                else
                {
                    Console.WriteLine(biggestOrder);
                    Console.WriteLine("Orders left: " + string.Join(" ", queue));
                    return;
                }
            }

            Console.WriteLine(biggestOrder);
            Console.WriteLine("Orders complete");
        }

        /// <summary>
        /// 05. Fashion Boutique
        /// </summary>
        public static void FashionBoutique()
        {
            var boxInput = Console.ReadLine().Split().Select(int.Parse).ToList();
            var rackCapacity = int.Parse(Console.ReadLine());

            var box = new Queue<int>();

            foreach (var cloth in boxInput)
            {
                box.Enqueue(cloth);
            }

            var racks = 0;
            var sum = 0;

            while (box.Count > 0)
            {
                var currentCloth = box.Peek();

                if (sum + currentCloth <= rackCapacity)
                {
                    sum += box.Dequeue();
                }
                else
                {
                    racks++;
                    sum = 0;
                }
            }

            if (sum > 0)
            {
                racks++;
            }

            Console.WriteLine(racks);
        }

        /// <summary>
        /// 06. Songs Queue
        /// </summary>
        public static void SongsQueue()
        {
            var initialSongs = Console.ReadLine().Split(", ").ToList();
            var playlist = new Queue<string>(initialSongs);

            while (playlist.Count > 0)
            {
                var command = Console.ReadLine();

                if (command == "Play")
                {
                    playlist.Dequeue();
                }
                else if (command.StartsWith("Add"))
                {
                    var song = command.Substring(4).Trim();

                    if (playlist.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        playlist.Enqueue(song);
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", playlist));
                }
            }

            Console.WriteLine("No more songs!");
        }

        /// <summary>
        /// 08. Balanced Parenthesis
        /// </summary>
        public static void BalancedParenthesis()
        {
            string input = Console.ReadLine();
            Stack<char> parenthesStack = new Stack<char>();
            foreach (var symbol in input)
            {
                if (parenthesStack.Any())
                {
                    char check = parenthesStack.Peek();
                    if (check == '{' && symbol == '}')
                    {
                        parenthesStack.Pop();
                        continue;
                    }
                    else if (check == '[' && symbol == ']')
                    {
                        parenthesStack.Pop();
                        continue;
                    }
                    else if (check == '(' && symbol == ')')
                    {
                        parenthesStack.Pop();
                        continue;
                    }
                }
                parenthesStack.Push(symbol);
            }
            Console.WriteLine(!parenthesStack.Any() ? "YES" : "NO");
        }

        /// <summary>
        /// 09. Simple Text Editor
        /// </summary>
        public static void SimpleTextEditor()
        {
            var n = int.Parse(Console.ReadLine());
            var str = "";

            var commands = new Stack<(int type, string stringVal)>();

            for (int i = 0; i < n; i++)
            {
                var cmd = Console.ReadLine().Split().ToArray();
                var commandType = int.Parse(cmd[0]);

                switch (commandType)
                {
                    case 1:
                        commands.Push((commandType, str));
                        str += cmd[1];
                        break;
                    case 2:
                        var count = int.Parse(cmd[1]);
                        commands.Push((commandType, str));
                        var removed = "";

                        var tempQueue = new List<char>(str.ToCharArray());
                        for (int j = 0; j < count; j++)
                        {
                            var ind = tempQueue.Count - 1;
                            var removedChar = tempQueue[ind];
                            tempQueue.RemoveAt(ind);
                            removed += removedChar;
                        }

                        str = string.Join("", tempQueue);

                        break;
                    case 3:
                        var index = int.Parse(cmd[1]);

                        var tempQueue1 = new Queue<char>(str.ToCharArray());

                        for (int j = 0; j < index - 1; j++)
                        {
                            tempQueue1.Dequeue();
                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(tempQueue1.Dequeue());
                        Console.ResetColor();

                        break;
                    case 4:
                        var lastCommand = commands.Pop();

                        if (lastCommand.type == 1)
                        {
                            str = lastCommand.stringVal;
                        }
                        else if (lastCommand.type == 2)
                        {
                            str = lastCommand.stringVal;
                        }

                        break;
                }
            }
        }

        /// <summary>
        /// 10. Crossroads 57/100
        /// </summary>
        public static void Crossroads()
        {
            var greenLightTime = int.Parse(Console.ReadLine());
            var freeWindowTime = int.Parse(Console.ReadLine());

            var traffic = new Queue<(Queue<char> vehicle, string name)>();
            var passed = 0;

            var input = Console.ReadLine();

            while (input != "END")
            {
                if (input != "green")
                {
                    traffic.Enqueue((new Queue<char>(input.ToCharArray()), input));
                }
                else
                {
                    var car = traffic.Peek();

                    for (int i = 1; i <= greenLightTime; i++)
                    {
                        if (car.vehicle.Any())
                        {
                            car.vehicle.Dequeue();
                        }
                        else
                        {
                            if (traffic.Any())
                            {
                                traffic.Dequeue();
                                passed++;
                            }

                            if (traffic.Any())
                            {
                                car = traffic.Peek();
                                car.vehicle.Dequeue();
                            }
                        }
                    }

                    for (int j = 1; j <= freeWindowTime; j++)
                    {
                        if (car.vehicle.Any())
                        {
                            car.vehicle.Dequeue();
                        }
                        else
                        {
                            if (traffic.Any())
                            {
                                traffic.Dequeue();
                                passed++;
                                break;
                            }
                        }
                    }

                    if (car.vehicle.Any())
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{car.name} was hit at {car.vehicle.Peek()}.");
                        return;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passed} total cars passed the crossroads.");
        }
    }
}
