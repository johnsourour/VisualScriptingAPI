using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterNode<T> : Node {
    private string variableName;
    private SymbolTable symbolTable;

    public SetterNode(SymbolTable _symbolTable, string _variableName) : base(NodeType.Setter) {
        symbolTable     = _symbolTable;
        variableName    = _variableName;
    }
    public override void run() {
        dynamic val;

        if (inputPins.Count >= 1 && inputPins[0].exists()) {
            val = inputPins[0].get();

            if (typeof(T) == typeof(int))
                symbolTable.Set<int>(variableName, (val as int?).Value);
            else if (typeof(T) == typeof(float))
                symbolTable.Set<float>(variableName, (val as float?).Value);
            else if (typeof(T) == typeof(string))
                symbolTable.Set<string>(variableName, val as string);
            else if (typeof(T) == typeof(Vector3))
                symbolTable.Set<Vector3>(variableName, (val as Vector3?).Value);
            else
                Debug.LogError("Invalid type in Symbol Table Entry");

        }
        
        if (outputPins.Count >= 1 && outputPins[0].exists())
            outputPins[0].run();
    }
}