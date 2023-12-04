// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Runtime.CompilerServices;


var alice = new User("Alice");
var bob = new User("Bob");
var charlie = new User("Charlie");


List<User> users = [alice, bob, charlie];

/* Collection expressions can be converted to:
 
 - Arrays
 - List<T>
 - IEnumerable<T>
 - Span<T>, ReadOnlySpan<T>
 - Anything which has a static method Create(ReadOnlySpan<T>) (see example) 
 */



#region Lists and Arrays


// Alternative 1: var
var users1 = new List<User>()
{
    alice, bob, charlie
};

// Alternative 2: Explicit type + new()
List<User> users2 = new()
{
    alice, bob, charlie
};

// Alternative 3: Collection expressions
List<User> users3 = [alice, bob, charlie];

// Example using spread operator.
User[] users4 = [alice, bob, charlie, ..users3, ..GetUsers()];


List<User> GetUsers()
{
    return [new User("Dave")];
}

#endregion


#region Custom collection types


LineBuffer line = ['H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd', '!'];


[CollectionBuilder(typeof(LineBufferBuilder), "Create")]
public class LineBuffer : IEnumerable<char>
{
    private readonly char[] _buffer = new char[80];

    public LineBuffer(ReadOnlySpan<char> buffer)
    {
        int number = (_buffer.Length < buffer.Length) ? _buffer.Length : buffer.Length;
        for (int i = 0; i < number; i++)
        {
            _buffer[i] = buffer[i];
        }
    }

    public IEnumerator<char> GetEnumerator() => _buffer.AsEnumerable().GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _buffer.GetEnumerator();
}


internal static class LineBufferBuilder
{
    internal static LineBuffer Create(ReadOnlySpan<char> values) => new LineBuffer(values);
}


#endregion


#region TODO: Dictionaries

// Not supported in C# 12. Maybe C# 13?

// var dict1 = [1: alice, 2: bob];
//var dict2 = [..dict1, 3: charlie];


/*
 * Compare to python:
 *
 * dict1 = {1: alice, 2: bob}
 */


#endregion



public record User(string Name);
