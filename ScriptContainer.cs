using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptContainer : MonoBehaviour {
    SymbolTable symbolTable;
    
    List<Node> nodes;

    Node eventStartNode;

    ScriptContainer() {
        symbolTable = new SymbolTable();
        nodes = new List<Node>();
    }

    public void Awake() {
        symbolTable.Add<string>("Wow");

        eventStartNode = new EventNode();
        Node e = eventStartNode;
        nodes.Add(eventStartNode);

        Node c = new ConstantNode<string>("Cool Dude");
        nodes.Add(c);

        Node s = new SetterNode<string>(symbolTable, "Wow");
        nodes.Add(s);

        Node g = new GetterNode<string>(symbolTable, "Wow");
        nodes.Add(g);

        Node p = new PrintStringNode();
        nodes.Add(p);
        
        p.inputPins.Add(new PinValue(g, 0, PinDataType.String));
        p.outputPins.Add(new PinExecutable(null, 0));
        e.outputPins.Add(new PinExecutable(s, 0));
        s.outputPins.Add(new PinExecutable(p, 0));
        s.inputPins.Add(new PinValue(c, 0, PinDataType.String));
    }

    public void Start() {
        eventStartNode.run();
    }
}
