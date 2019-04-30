using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum PinDataType {
    Execution,
    Number,
    Integer,
    String,
    Vector,
    Transform,
    ARObject,
    ProjectionMap,
    Image,
    VariableReference
}