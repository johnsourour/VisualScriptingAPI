using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetterNode : Node {
    protected SymbolTable symbolTable;
    protected string variableName;
    public SetterNode(): base(NodeType.Setter) {
        symbolTable = null;
        variableName = "";

        addInputPin(new PinValue());
        addOutputPin(new PinExecutable());
    }

    public SetterNode(SymbolTable _symbolTable) : base(NodeType.Setter) {
        symbolTable=_symbolTable;
        variableName="";

        addInputPin(new PinValue());
        addOutputPin(new PinExecutable());
    }
    
    public SetterNode(SymbolTable _symbolTable, string _variableName) : base(NodeType.Setter) {
        symbolTable=_symbolTable;
        variableName=_variableName;

        addInputPin(new PinValue());
        addOutputPin(new PinExecutable());
    }

    public void setVarName(string vn) {
        variableName = vn;
    }
}

public class SetterNode<T> : SetterNode {
    public SetterNode() : base() {}
    public SetterNode(SymbolTable _symbolTable) : base(_symbolTable) {}
    public SetterNode(SymbolTable _symbolTable, string _variableName) : base(_symbolTable, _variableName) {}

    public void setVariableParams(SymbolTable _symbolTable, string _variableName){
        symbolTable     = _symbolTable;
        variableName    = _variableName;

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
        else if (typeof(T) == typeof(bool))   
            symbolTable.Set<bool>(variableName, val);
        else if (typeof(T) == typeof(Vector3))
            symbolTable.Set<Vector3>(variableName, val);
        else if (typeof(T) == typeof(GameObject))
            symbolTable.Set<GameObject>(variableName, (val as GameObject));
        else if (typeof(T) == typeof(_3DObject))
            symbolTable.Set<_3DObject>(variableName, (val as _3DObject));
        else if (typeof(T) == typeof(Text))
            symbolTable.Set<Text>(variableName, (val as Text));
        else if (typeof(T) == typeof(Image))
            symbolTable.Set<Image>(variableName, (val as Image));
        else
            Debug.LogError("Invalid type in Symbol Table Entry");

        outputPins[0].run();
    }
}