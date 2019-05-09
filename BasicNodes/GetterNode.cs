using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetterNode : Node {
    protected SymbolTable symbolTable;
    protected string variableName;
    public GetterNode(): base(NodeType.Getter){}
    public GetterNode(SymbolTable _symbolTable) : base(NodeType.Getter) {
        symbolTable=_symbolTable;
        variableName="";
    }
    public GetterNode(SymbolTable _symbolTable, string _variableName) : base(NodeType.Getter) {
        symbolTable=_symbolTable;
        variableName=_variableName;
    }

    public void setVarName(string vn) {
        variableName = vn;
    }
}

public class GetterNode<T> : GetterNode {
    public GetterNode(): base(){}
    public GetterNode(SymbolTable _symbolTable) : base(_symbolTable) {}
    public GetterNode(SymbolTable _symbolTable, string _variableName) : base(_symbolTable, _variableName) {}

    public void setVariableParams(SymbolTable _symbolTable, string _variableName){
        symbolTable     = _symbolTable;
        variableName    = _variableName;

    }
    public override dynamic get(uint pinID) {
        dynamic v;
        if (!symbolTable.Get<T>(variableName, out v)) {
            Debug.LogError("Could not find variable name.");
        }
        
        return v;
    }
}