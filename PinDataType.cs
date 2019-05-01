using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum PinDataType {
    Execution,
    Bool,
    Number,
    Integer,
    String,
    Vector,
    GameObject,
    Component3D,
    ComponentText,
    ProjectionMap,
    Image,
    VariableReference
}