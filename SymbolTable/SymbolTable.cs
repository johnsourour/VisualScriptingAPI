using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolTable {
    public Dictionary<string, SymbolTableEntry> symbolTable;

    public void Awake() {
        createST();
    }
    
    void createST() {
        if (symbolTable == null)
            symbolTable = new Dictionary<string, SymbolTableEntry>();
    }

    public void     Add<T>(string key) {
        createST();

        SymbolTableEntry entry;

        entry = new SymbolTableEntry<T>();

        symbolTable[key] = entry;
    }

    public void     Add(string key, PinDataType type) {
        SymbolTableEntry entry;

        switch(type) {
            default:
            case PinDataType.Integer:
                entry = new SymbolTableEntry<int>();
                break;
            case PinDataType.Number:
                entry = new SymbolTableEntry<float>();
                break;
            case PinDataType.String:
                entry = new SymbolTableEntry<string>();
                break;
            case PinDataType.Vector:
                entry = new SymbolTableEntry<Vector3>();
                break;
        }

        symbolTable[key] = entry;
    }

    SymbolTableEntry searchTable(string key) {
        return symbolTable.ContainsKey(key) ? symbolTable[key] : null;
    }
    
    public void     Set<T>(string key, T value) {
        SymbolTableEntry ste = searchTable(key);
        if (ste == null) {
            Debug.Log("Key " + key + " not found.");
        }
        else {
            ((SymbolTableEntry<T>)ste).value = value;
        }
    }
    
    public void     Set(string key, int value) {
        ((SymbolTableEntry<int>)searchTable(key)).value = value;
    }

    public void     Set(string key, float value) {
        ((SymbolTableEntry<float>)searchTable(key)).value = value;
    }

    public void     Set(string key, string value) {
        ((SymbolTableEntry<string>)searchTable(key)).value = value;
    }
    
    public void     Set(string key, Vector3 value) {
        ((SymbolTableEntry<Vector3>)searchTable(key)).value = value;
    }
    
    public bool      Get<T>(string key, out dynamic value) {
        SymbolTableEntry<T> entry = ((SymbolTableEntry<T>)searchTable(key));
        if (entry != null) {
            value = entry.value;
            return true;
        }
        
        value = 0;
        return false;
    }
    
    public bool      GetInt(string key, out int value) {
        SymbolTableEntry<int> entry = ((SymbolTableEntry<int>)searchTable(key));
        if (entry != null) {
            value = entry.value;
            return true;
        }
        
        value = 0;
        return false;
    }
    
    public bool    GetFloat(string key, out float value) {
        SymbolTableEntry<float> entry = ((SymbolTableEntry<float>)searchTable(key));
        if (entry != null) {
            value = entry.value;
            return true;
        }

        value = 0.0f;
        return false;
    }
    
    public bool   GetString(string key, out string value) {
        SymbolTableEntry<string> entry = ((SymbolTableEntry<string>)searchTable(key));
        if (entry != null) {
            value = entry.value;
            return true;
        }
        
        value = "";
        return false;
    }
    
    public bool  GetVector(string key, out Vector3 value) {
        SymbolTableEntry<Vector3> entry = ((SymbolTableEntry<Vector3>)searchTable(key));
        if (entry != null) {
            value = entry.value;
            return true;
        }
        
        value = new Vector3();
        return false;
    }
}
