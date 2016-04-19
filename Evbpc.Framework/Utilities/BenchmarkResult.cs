using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

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
        public long RoundsRun { get; set; }

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
        public long RoundsPassed { get; set; }

        /// <summary>
        /// The total amount of time taken for all the benchmarks. (Does not include statistic calculation time, or result verification time.)
        /// </summary>
        /// <remarks>
        /// Depending on the number of rounds and time taken for each, this value may not be entirely representful of the actual result, and may have rounded over. It should be used with caution on long-running methods that are run for long amounts of time, though that likely won't be a problem as that would result in the programmer having to wait for it to run. (It would take around 29,247 years for it to wrap around.)
        /// </remarks>
        public TimeSpan TotalTime { get; set; }

        /// <summary>
        /// Runs a benchmark of a method.
        /// </summary>
        /// <param name="rounds">The number of rounds to run.</param>
        /// <param name="method">The code to run.</param>
        /// <param name="warmupSeconds">The number of seconds to run the method for to warm up.</param>
        /// <param name="forceGcBetweenRuns">If true, forces the garbage collector to run between each round. This can significantly increase the amount of time it takes for the benchmark to complete.</param>
        /// <returns>A <see cref="BenchmarkResult"/> representing the result of the session.</returns>
        public static BenchmarkResult Benchmark(long rounds, Action method, double warmupSeconds = 0, bool forceGcBetweenRuns = false)
        {
            var sw = new Stopwatch();

            if (warmupSeconds > 0)
            {
                var cts = new CancellationTokenSource();
                var ct = cts.Token;
                var t = Task.Run(() => { for (int i = 0; i < 1; i += 0) { if (ct.IsCancellationRequested) { break; } sw.Start(); method.Invoke(); sw.Stop(); sw.Reset(); } }, ct);

                cts.CancelAfter((int)(warmupSeconds * 1000));

                t.Wait();
            }

            double m2 = 0;
            double averageTicks = 0;
            double totalValues = 0;
            long maxTicks = 0;
            long minTicks = 0;
            long totalTime = 0;

            for (long i = 0; i < rounds; i++)
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

                totalTime += sw.ElapsedTicks;

                sw.Reset();

                if (forceGcBetweenRuns)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }

            double variance = m2 / (totalValues - 1);

            return new BenchmarkResult
            {
                AverageTime = new TimeSpan(Convert.ToInt64(averageTicks)),
                MaxTime = new TimeSpan(maxTicks),
                MinTime = new TimeSpan(minTicks),
                RoundsPassed = rounds,
                RoundsRun = rounds,
                TotalTime = new TimeSpan(totalTime),
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
        /// <param name="warmupSeconds">The number of seconds to run the method for to warm up.</param>
        /// <param name="forceGcBetweenRuns">If true, forces the garbage collector to run between each round. This can significantly increase the amount of time it takes for the benchmark to complete.</param>
        /// <returns>A <see cref="BenchmarkResult"/> representing the result of the session.</returns>
        public static BenchmarkResult Benchmark<T>(long rounds, Func<T> method, T expectedResult, double warmupSeconds = 0, bool forceGcBetweenRuns = false)
        {
            var sw = new Stopwatch();

            if (warmupSeconds > 0)
            {
                var cts = new CancellationTokenSource();
                var ct = cts.Token;
                var t = Task.Run(() => { for (int i = 0; i < 1; i += 0) { if (ct.IsCancellationRequested) { break; } sw.Start(); method.Invoke(); sw.Stop(); sw.Reset(); } }, ct);

                cts.CancelAfter((int)(warmupSeconds * 1000));

                t.Wait();
            }

            double m2 = 0;
            double averageTicks = 0;
            double totalValues = 0;
            long maxTicks = 0;
            long minTicks = 0;
            long totalTime = 0;
            long roundsPassed = 0;

            for (long i = 0; i < rounds; i++)
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

                totalTime += sw.ElapsedTicks;

                sw.Reset();

                if (forceGcBetweenRuns)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }

            double variance = m2 / (totalValues - 1);

            return new BenchmarkResult
            {
                AverageTime = new TimeSpan(Convert.ToInt64(averageTicks)),
                MaxTime = new TimeSpan(maxTicks),
                MinTime = new TimeSpan(minTicks),
                RoundsPassed = roundsPassed,
                RoundsRun = rounds,
                TotalTime = new TimeSpan(totalTime),
                Variance = new TimeSpan(Convert.ToInt64(variance))
            };
        }
    }
}