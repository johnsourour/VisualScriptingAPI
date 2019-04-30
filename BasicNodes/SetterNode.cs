using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterNode<T> : Node {
    private string variableName;
    private SymbolTable symbolTable;

    public SetterNode(SymbolTable _symbolTable, string _variableName) : base(NodeType.Setter) {
        symbolTable     = _symbolTable;
        variableName    = _variableName;

        addInputPin(new PinValue());
        addOutputPin(new PinExecutable());
    }

    public void setSetterInputPin(Node src, PinDataType type){
        setInputPin(src, 0, type);
    }

    public void setSetterOutputPin(Node src){
        setOutputPin(src, 0);
    }
    
    public bool ready(){
        return inputPins[0].exists();
    }
    
    public override void run() {
        
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return;
        }

        dynamic val = inputPins[0].get();

        if (typeof(T) == typeof(int))
            symbolTable.Set<int>(variableName, (val as int?).Value);
        else if (typeof(T) == typeof(float))
            symbolTable.Set<float>(variableName, (val as float?).Value);
        else if (typeof(T) == typeof(string))   
            symbolTable.Set<string>(variableName, val as string);
        else if (typeof(T) == typeof(Vector3))
            symbolTable.Set<Vector3>(variableName, val);
        else if (typeof(T) == typeof(Transform))
            symbolTable.Set<Transform>(variableName, (val as Transform));
        else
            Debug.LogError("Invalid type in Symbol Table Entry");

        outputPins[0].run();
    }
}