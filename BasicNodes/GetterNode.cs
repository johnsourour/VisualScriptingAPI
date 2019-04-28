using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetterNode<T> : Node {
    private string variableName;
    private SymbolTable symbolTable;

    public GetterNode(SymbolTable _symbolTable, string _variableName) : base(NodeType.Getter) {
        symbolTable=_symbolTable;
        variableName=_variableName;
    }
    
    public override dynamic get(uint pinID) {
        dynamic v;
        if (!symbolTable.Get<T>(variableName, out v)) {
            Debug.LogError("Could not find variable name.");
        }
        
        return v;
    }
}