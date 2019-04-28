using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNode : Node {
    
    public EventNode() : base(NodeType.Event) {}
    
    public override void run() {
        if (outputPins.Count >= 1 && outputPins[0].exists())
            outputPins[0].run();
    }
}