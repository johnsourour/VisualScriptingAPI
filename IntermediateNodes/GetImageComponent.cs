using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Dynamic;

public class GetImageComponent : Node {

    public GetImageComponent() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //game object      
    }

    public bool ready(){
        return inputPins[0].exists();
    }
    
    public override dynamic get(uint pinID){
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return -1;
        }

        GameObject obj = inputPins[0].get();
        
        SpriteRenderer img = obj.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;

        
        Debug.Log("Got 3D Component");

        return img;
        
    }

    
}