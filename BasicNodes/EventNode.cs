using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNode : Node {
    
    public EventNode() : base(NodeType.Event) {
        addOutputPin(new PinExecutable());
    }
    public bool setEventOutPin(Node src){
        return setOutputPin(src,0);
    }
    public override void run() {
        outputPins[0].run();
    }
}