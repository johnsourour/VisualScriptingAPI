using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptContainer : MonoBehaviour {
    SymbolTable symbolTable;
    
    List<Node> nodes;

    EventNode eventStartNode;

    ScriptContainer() {
        symbolTable = new SymbolTable();
        nodes = new List<Node>();
    }

    public void Awake() {
        symbolTable.Add<string>("Wow");

        eventStartNode = new EventNode();
        EventNode e = eventStartNode;
        nodes.Add(eventStartNode);

        // ConstantNode<string> c = new ConstantNode<string>("Cool Dude");
        // nodes.Add(c);

        // SetterNode<string> s = new SetterNode<string>(symbolTable, "Wow");
        // nodes.Add(s);

        // GetterNode<string> g = new GetterNode<string>(symbolTable, "Wow");
        // nodes.Add(g);

        // PrintStringNode p = new PrintStringNode();
        // nodes.Add(p);
        
        // p.setStringInputPin(g, PinDataType.String);
        // p.setStringOutputPin(null);
        // e.setEventOutPin(s);
        // s.setSetterOutputPin(p);
        // s.setSetterInputPin(c,PinDataType.String);

        //Takes current object
        ConstantNode<Transform> c1 = new ConstantNode<Transform>(transform);
        nodes.Add(c1);

        Vector3 v1 = new Vector3(1, 1, 1);
        ConstantNode<Vector3> vc1 = new ConstantNode<Vector3>(v1);
        nodes.Add(vc1);
        Vector3 v2 = new Vector3(3, 3, 3);
        ConstantNode<Vector3> vc2 = new ConstantNode<Vector3>(v2);
        nodes.Add(vc2);
        Vector3 v3 = new Vector3(0, 90, 0);
        ConstantNode<Vector3> vc3 = new ConstantNode<Vector3>(v3);
        nodes.Add(vc3);

        MoveObject mo = new MoveObject();
        nodes.Add(mo);

        ScaleObject so = new ScaleObject();
        nodes.Add(so);

        RotateObject ro = new RotateObject();
        nodes.Add(ro);

        e.setEventOutPin(mo);

        mo.setLocationPin(vc1, PinDataType.Vector);
        mo.setObjectPin(c1, PinDataType.Transform);
        mo.setExecOutputPin(so);

        so.setScalePin(vc2, PinDataType.Vector);
        so.setObjectPin(c1, PinDataType.Transform);
        so.setExecOutputPin(ro);

        ro.setRotationPin(vc3, PinDataType.Vector);
        ro.setObjectPin(c1, PinDataType.Transform);

    }

    public void Start() {
        eventStartNode.run();
    }
}
