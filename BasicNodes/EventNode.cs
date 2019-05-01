using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNode : Node {
    
    public EventNode() : base(NodeType.Event) {
        addOutputPin(new PinExecutable());
    }
    public override void run() {
        outputPins[0].run();
    }
}