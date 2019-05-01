using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileToString : Node {
    private string val="";

    public FileToString() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //filename      
        addOutputPin(new PinExecutable()); //exec out  
    }

    public bool ready(){
        return inputPins[0].exists();
    }
    
    public override void run(){
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return;
        }

        string file = inputPins[0].get();
        
        if (!File.Exists(file))  
        {  
            Debug.LogError("File not found!");
            return;
        } 

        val = File.ReadAllText(file); 
        Debug.Log("Done loading file!");
        
        outputPins[0].run();
    }

    public override dynamic get(uint pinID) {
        return val;      
    }
}