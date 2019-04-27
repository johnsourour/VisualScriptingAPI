using System.IO;
using System;
using System.Collections.Generic;

public class SetterNode<T> : Node {
    private string variableName;
    private Dictionary<string,T> symbolTable;
    public SetterNode(){
    }
    public SetterNode(Dictionary<string,T> _symbolTable, string _variableName){
        symbolTable=_symbolTable;
        variableName=_variableName;
        base.setType("Setter");
    }
    public void get(T val) {
         symbolTable[variableName] = val
    }
}