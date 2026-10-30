// Name: <Mohamed Hafez>
// Student ID: <225114464>

using System;
using System.Text;

namespace Cse111Task1;

public class StudentList
{
    public Student? First { get; private set; }
    public Student? Last { get; private set; }
    public int Count { get; private set; }

    public void AddFront(int id)
    {
        var node = new Student(id);
        node.Next = First;
        First = node;

        if (Last == null)  
        {
            Last = node;
        }

        Count++;
    }

    public void AddEnd(int id)
    {
        var node = new Student(id);

        if (Last == null)   // empty line
        {
            First = node;
            Last = node;
        }
        else
        {
            Last.Next = node;
            Last = node;
        }

        Count++;
    }

    public bool Remove(int id)
    {
        Student? previous = null;
        Student? current = First;

        while (current != null && current.Id != id)
        {
            previous = current;
            current = current.Next;
        }

        if (current == null)    
        {
            return false;
        }

        if (previous == null)   
        {
            First = current.Next;
        }
        else                    
        {
            previous.Next = current.Next;
        }

        if (current == Last)   
        {
            Last = previous;
        }

        current.Next = null;
        Count--;
        return true;
    }

    public void Reverse()
    {
        Student? previous = null;
        Student? current = First;

        Last = First;   
        while (current != null)
        {
            Student? next = current.Next;   
            current.Next = previous;
            previous = current;
            current = next;
        }

        First = previous;
    }

    public void Print()
    {
        var sb = new StringBuilder();
        Student? current = First;

        while (current != null)
        {
            if (sb.Length > 0)
            {
                sb.Append(' ');
            }

            sb.Append(current.Id);
            current = current.Next;
        }

        Console.WriteLine(sb.ToString());
    }
}
