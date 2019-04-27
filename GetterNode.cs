using System.IO;
using System;
using System.Collections.Generic;

public class GetterNode<T> : Node {
    private string variableName;
    private Dictionary<string,T> symbolTable;
    public GetterNode(){}
    public GetterNode(Dictionary<string,T> _symbolTable, string _variableName){
        symbolTable=_symbolTable;
        variableName=_variableName;
        base.setType("Getter");
    }
    public T get() {
        return symbolTable[variableName] as T;
    }
}