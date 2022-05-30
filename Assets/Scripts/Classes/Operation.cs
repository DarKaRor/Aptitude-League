using System.Data;
using System;
using UnityEngine;

public class Operation
{
    int num1;
    int num2;
    char op;

    DataTable dataTable = new DataTable();

    public Operation(int num1, int num2, char op)
    {
        this.num1 = num1;
        this.num2 = num2;
        this.op = op;
    }

    public string Solve() =>  dataTable.Compute(ToString(), string.Empty).ToString();
    
    public override string ToString() => $"{num1} {op} {num2}";

    public string ToStringStylized() => ToString().Replace('*', 'x').Replace('/', '÷');
    
}
