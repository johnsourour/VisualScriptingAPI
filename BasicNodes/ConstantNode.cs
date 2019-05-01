using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantNode<T> : Node {
    private T value;
    public ConstantNode() : base(NodeType.Constant) {

    }
    public ConstantNode(T _value) : base(NodeType.Constant) {
        value = _value;
    }
    public void setConstant(T _value){
        value = _value;
    }
    public override dynamic get(uint pinID) {
        return value;
    }
}