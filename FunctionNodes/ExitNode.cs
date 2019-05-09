using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitNode : Node {
    public ExitNode() : base(NodeType.Function) {
        
    }

    public override void run() {
        Application.Quit();
    }
}