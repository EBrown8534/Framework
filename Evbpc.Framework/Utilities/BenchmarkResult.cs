using System;
using System.Diagnostics;

namespace Evbpc.Framework.Utilities
{
    /// <summary>
    /// Represents the result of a benchmarking session.
    /// </summary>
    public class BenchmarkResult
    {
        /// <summary>
        /// The total number of rounds ran.
        /// </summary>
        public ulong RoundsRun { get; set; }

        /// <summary>
        /// The average time for all the rounds.
        /// </summary>
        public TimeSpan AverageTime { get; set; }

        /// <summary>
        /// The maximum time taken for a single round.
        /// </summary>
        public TimeSpan MaxTime { get; set; }

        /// <summary>
        /// The minimum time taken for a single round.
        /// </summary>
        public TimeSpan MinTime { get; set; }

        /// <summary>
        /// The variance (standard deviation) of all the rounds.
        /// </summary>
        public TimeSpan Variance { get; set; }

        /// <summary>
        /// The number of rounds that passed testing. (Always equivalent to <see cref="RoundsRun"/> for <see cref="Benchmark(ulong, Action)"/>.)
        /// </summary>
        public ulong RoundsPassed { get; set; }
        
        /// <summary>
        /// Runs a benchmark of a method.
        /// </summary>
        /// <param name="rounds">The number of rounds to run.</param>
        /// <param name="method">The code to run.</param>
        /// <returns>A <see cref="BenchmarkResult"/> representing the result of the session.</returns>
        public static BenchmarkResult Benchmark(ulong rounds, Action method)
        {
            var sw = new Stopwatch();

            double m2 = 0;
            double averageTicks = 0;
            double totalValues = 0;
            long maxTicks = 0;
            long minTicks = 0;

            for (ulong i = 0; i < rounds; i++)
            {
                sw.Start();
                method.Invoke();
                sw.Stop();

                if (totalValues == 0)
                {
                    maxTicks = sw.ElapsedTicks;
                    minTicks = sw.ElapsedTicks;
                }

                totalValues++;

                maxTicks = Math.Max(sw.ElapsedTicks, maxTicks);
                minTicks = Math.Min(sw.ElapsedTicks, minTicks);

                // We need to store `delta` here as the `averageTicks` will change on the next calculation, and we need this previous `delta` for the calculation after it.
                double delta = sw.ElapsedTicks - averageTicks;
                averageTicks = averageTicks + delta / totalValues;
                m2 += delta * (sw.ElapsedTicks - averageTicks);

                sw.Reset();
            }

            double variance = m2 / (totalValues - 1);

            return new BenchmarkResult
            {
                AverageTime = new TimeSpan(Convert.ToInt64(averageTicks)),
                MaxTime = new TimeSpan(maxTicks),
                MinTime = new TimeSpan(minTicks),
                RoundsPassed = rounds,
                RoundsRun = rounds,
                Variance = new TimeSpan(Convert.ToInt64(variance))
            };
        }

        /// <summary>
        /// Runs a benchmark of a function and returns the results of the session.
        /// </summary>
        /// <typeparam name="T">The type of the output of the function.</typeparam>
        /// <param name="rounds">The number of rounds to run.</param>
        /// <param name="method">The code to run.</param>
        /// <param name="expectedResult">The expected result of the function. This will be compared to the actual result and used for <see cref="BenchmarkResult.RoundsPassed"/>. This uses the default <code>object.Equals(object)</code> method.</param>
        /// <returns>A <see cref="BenchmarkResult"/> representing the result of the session.</returns>
        public static BenchmarkResult Benchmark<T>(ulong rounds, Func<T> method, T expectedResult)
        {
            var sw = new Stopwatch();

            double m2 = 0;
            double averageTicks = 0;
            double totalValues = 0;
            long maxTicks = 0;
            long minTicks = 0;
            ulong roundsPassed = 0;

            for (ulong i = 0; i < rounds; i++)
            {
                sw.Start();
                var result = method.Invoke();
                sw.Stop();

                if (expectedResult.Equals(result))
                {
                    roundsPassed++;
                }

                if (totalValues == 0)
                {
                    maxTicks = sw.ElapsedTicks;
                    minTicks = sw.ElapsedTicks;
                }

                totalValues++;

                maxTicks = Math.Max(sw.ElapsedTicks, maxTicks);
                minTicks = Math.Min(sw.ElapsedTicks, minTicks);

                // We need to store `delta` here as the `averageTicks` will change on the next calculation, and we need this previous `delta` for the calculation after it.
                double delta = sw.ElapsedTicks - averageTicks;
                averageTicks = averageTicks + delta / totalValues;
                m2 += delta * (sw.ElapsedTicks - averageTicks);

                sw.Reset();
            }

            double variance = m2 / (totalValues - 1);

            return new BenchmarkResult
            {
                AverageTime = new TimeSpan(Convert.ToInt64(averageTicks)),
                MaxTime = new TimeSpan(maxTicks),
                MinTime = new TimeSpan(minTicks),
                RoundsPassed = roundsPassed,
                RoundsRun = rounds,
                Variance = new TimeSpan(Convert.ToInt64(variance))
            };
        }
    }
}