using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintStringNode : Node {
    public PrintStringNode() : base(NodeType.Function) {}
    
    public override void run() {
        string val = "String not found.";

        if (inputPins.Count >= 1 && inputPins[0].exists())
            val = inputPins[0].get() as string;
        
        Debug.Log(val);

        if (outputPins.Count >= 1 && outputPins[0].exists())
            outputPins[0].run();
    }
}