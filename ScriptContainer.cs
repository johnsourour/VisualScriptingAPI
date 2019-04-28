using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptContainer : MonoBehaviour {
    SymbolTable symbolTable;
    
    List<Node> nodes;

    EventNode eventStartNode;

    ScriptContainer() {
        symbolTable = new SymbolTable();
        nodes = new List<Node>();
    }

    public void Awake() {
        symbolTable.Add<string>("Wow");

        eventStartNode = new EventNode();
        EventNode e = eventStartNode;
        nodes.Add(eventStartNode);

        ConstantNode<string> c = new ConstantNode<string>("Cool Dude");
        nodes.Add(c);

        SetterNode<string> s = new SetterNode<string>(symbolTable, "Wow");
        nodes.Add(s);

        GetterNode<string> g = new GetterNode<string>(symbolTable, "Wow");
        nodes.Add(g);

        PrintStringNode p = new PrintStringNode();
        nodes.Add(p);
        
        p.setStringInputPin(g, PinDataType.String);
        p.setStringOutputPin(null);
        e.setEventOutPin(s);
        s.setSetterOutputPin(p);
        s.setSetterInputPin(c,PinDataType.String);
    }

    public void Start() {
        eventStartNode.run();
    }
}
