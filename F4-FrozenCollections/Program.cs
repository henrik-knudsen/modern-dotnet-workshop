// See https://aka.ms/new-console-template for more information

using System.Collections.Frozen;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using BenchmarkDotNet.Running;
using F4_FrozenCollections;

List<int> normalList = new List<int> { 1, 2, 3 };
ReadOnlyCollection<int> readonlyList = normalList.AsReadOnly();
FrozenSet<int> frozenSet = normalList.ToFrozenSet();
ImmutableList<int> immutableList = normalList.ToImmutableList();

normalList.Add(4);

Console.WriteLine($"List count: {normalList.Count}");
Console.WriteLine($"ReadOnlyList count: {readonlyList.Count}");
Console.WriteLine($"FrozenSet count: {frozenSet.Count}");
Console.WriteLine($"ImmutableList count: {immutableList.Count}");



BenchmarkRunner.Run<Benchmark>();