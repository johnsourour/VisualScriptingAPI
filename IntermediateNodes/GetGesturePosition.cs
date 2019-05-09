using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetGesturePosition : Node {

    public GetGesturePosition() : base(NodeType.Intermediate) {  
    }
    public override dynamic get(uint pinID){
        Vector3 v = Input.mousePosition;
        return v;
    }

    
}