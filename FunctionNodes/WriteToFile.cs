using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WriteToFile : Node {

    public WriteToFile() : base(NodeType.Function) {
        addInputPin(new PinValue()); //filename  
        addInputPin(new PinValue()); //string to write      
        addOutputPin(new PinExecutable()); //exec out  
    }

    public bool ready(){
        return inputPins[0].exists() && inputPins[1].exists();
    }
    
    public override void run(){
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return;
        }

        string file = inputPins[0].get();
        string text = inputPins[1].get();
        
        if (!File.Exists(file))  
        {  
            Debug.LogError("File not found!");
            return;
        } 

        File.WriteAllText(file, text);
        Debug.Log("Done writing to file!");
        
        outputPins[0].run();
    }

}