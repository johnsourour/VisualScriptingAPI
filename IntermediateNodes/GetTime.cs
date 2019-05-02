using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTime : Node {

    public GetTime() : base(NodeType.Intermediate) {  
    }
    public override dynamic get(uint pinID){
        float t = Time.time;
        return t;
    }

    
}