using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;



public class WhileNode : Node {
    public WhileNode() : base(NodeType.FlowNode) {
        addInputPin(new PinValue());
        addOutputPin(new PinExecutable());
        addOutputPin(new PinExecutable());
        
    }

    public bool ready(){
        return inputPins[0].exists();
    }

    public override void run() {
        if(!ready()){
            Debug.LogError("Node pins not initialized.");
            return;
        }
        dynamic condition;
        condition = inputPins[0].get();
        int i = 0;
        while((condition as bool?).Value && i++ < 1000) {
            outputPins[1].run();
            condition = inputPins[0].get();
        }
            
        outputPins[0].run();
    }
}
