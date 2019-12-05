using System;
using System.Collections.Generic;
using MulticastDelegateExtensions;

namespace TestConsole
{
    class Program
    {
        public static event EventHandler A;

        static void Main(string[] args)
        {
            A += RunA;
            A += RunA1;
            A += RunA2;
            Console.WriteLine("Hello World!");

            try
            {
                A.InvokeAll(default, new EventArgs());
            }
            catch (Exception e)
            {
                LogFailure(e);
            }

            var actions = new List<Action<object, EventArgs>>
            {
                RunA,
                RunA1,
                RunA2,
                null
            };

            try
            {
                actions.InvokeAll(default, new EventArgs());
            }
            catch (Exception e)
            {
                LogFailure(e);
            }

            var functions = new List<Func<object, EventArgs, int>>
            {
                RunB,
                RunB1,
                RunB2
            };

            try
            {
                functions.InvokeAll(default, new EventArgs());
            }
            catch (Exception e)
            {
                LogFailure(e);
            }

            var predicates = new List<Predicate<object>>
            {
                RunP,
                RunP1,
                RunP2
            };

            try
            {
                predicates.InvokeAll(default);
            }
            catch (Exception e)
            {
                LogFailure(e);
            }
        }

        static void RunA(object sender, EventArgs args)
        {
            Console.WriteLine("Running A");
        }

        static void RunA1(object sender, EventArgs args)
        {
            throw new Exception("HAH!");
        }

        static void RunA2(object sender, EventArgs args)
        {
            Console.WriteLine("Running A2");
        }

        static int RunB(object sender, EventArgs args)
        {
            Console.WriteLine("Running B");
            return 1;
        }

        static int RunB1(object sender, EventArgs args)
        {
            throw new Exception("HAH!");
        }

        static int RunB2(object sender, EventArgs args)
        {
            Console.WriteLine("Running B2");
            return 1;
        }

        static bool RunP(object sender)
        {
            Console.WriteLine("Running P");
            return true;
        }

        static bool RunP1(object sender)
        {
            throw new Exception("HAH!");
        }

        static bool RunP2(object sender)
        {
            Console.WriteLine("Running P2");
            return true;
        }

        static void LogFailure(Exception e)
        {
            Console.WriteLine($"Exception thrown in delegate with exception: {e}.");
        }
    }
}
