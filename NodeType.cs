using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum NodeType {
    Event,
    Setter,
    Getter,
    Constant,
    Function,
    Intermediate,
    FlowNode
}