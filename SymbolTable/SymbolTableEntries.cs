using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class SymbolTableEntry {
    public PinDataType type;
    public SymbolTableEntry() {
    }
};

[System.Serializable]
public class SymbolTableEntry<T> : SymbolTableEntry {
    public T value;
    public SymbolTableEntry() : base() {
        if (typeof(T) == typeof(int))
            type = PinDataType.Integer;
        else if (typeof(T) == typeof(float))
            type = PinDataType.Number;
        else if (typeof(T) == typeof(string))
            type = PinDataType.String;
        else if (typeof(T) == typeof(Vector3))
            type = PinDataType.Vector;
        else
            Debug.LogError("Invalid type in Symbol Table Entry");
    }
}