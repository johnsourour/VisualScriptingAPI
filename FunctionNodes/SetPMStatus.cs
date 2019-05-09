using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPMStatus : Node {
    public SetPMStatus() : base(NodeType.Function) {
        addInputPin(new PinValue()); //Projection Map
        addInputPin(new PinValue()); //bool
        addOutputPin(new PinExecutable()); //execution out
       
    }

    public bool ready(){
        return inputPins[0].exists() && inputPins[1].exists();
    }
    
    public override void run() {
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return;
        }

        Transform pm = inputPins[0].get();
        bool show = inputPins[1].get();
        
        pm.gameObject.SetActive(show);

        Debug.Log("Status set");
        
        outputPins[0].run();
    }
}