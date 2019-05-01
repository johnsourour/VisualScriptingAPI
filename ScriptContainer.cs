using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptContainer : MonoBehaviour {
    SymbolTable symbolTable;
    
    List<Node> nodes;

    EventNode eventStartNode;

    public Transform contentArea;

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
        ConstantNode<GameObject> c1 = new ConstantNode<GameObject>(gameObject);
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

        // MoveObject mo = new MoveObject();
        // nodes.Add(mo);

        // ScaleObject so = new ScaleObject();
        // nodes.Add(so);

        // RotateObject ro = new RotateObject();
        // nodes.Add(ro);

        dynamic mo = createNode("moveobject");
        nodes.Add(mo);

        dynamic ro = createNode("rotateobject");
        nodes.Add(ro);

        dynamic so = createNode("scaleobject");
        nodes.Add(so);

        e.setOutputPin(mo, 0);

        mo.setInputPin(vc1 , 0, PinDataType.Vector);
        mo.setInputPin(c1, 1, PinDataType.GameObject);
        mo.setOutputPin(so, 0);

        so.setInputPin(vc2 , 0, PinDataType.Vector);
        so.setInputPin(c1, 1, PinDataType.GameObject);
        so.setOutputPin(ro, 0);

        ro.setInputPin(vc3, 0, PinDataType.Vector);
        ro.setInputPin(c1, 1, PinDataType.GameObject);

    }

    public void Start() {
        eventStartNode.run();
    }

    
    public Node createNode(string type){
        switch(type)
        {
            case "rotateobject":
                return (new RotateObject() ) ;
            case "scaleobject":
                return (new ScaleObject() ) ;
            case "moveobject":
                return (new MoveObject() ) ;
            case "printstring":
                return (new PrintStringNode() ) ;
            
            case "eventstart":
            case "eventupdate":
            case "eventgesturepress":
            case "eventgesturerelease":
            case "eventgestureswipeup":
            case "eventgestureswipedown":
            case "eventgestureswiperight":
            case "eventgestureswipeleft":
                return (new EventNode()) ;
        
            case "setterbool":
                return (new SetterNode<bool>() ) ;
            case "setterstring":
                return (new SetterNode<string>() ) ;
            case "setternum":
                return (new SetterNode<float>() ) ;
            case "setterint":
                return (new SetterNode<int>() ) ;
            case "setterobj":
            case "setterpm":
                return (new SetterNode<Transform>() ) ;
            case "settervector":
                return (new SetterNode<Vector3>() ) ;
        
            case "getterbool":
                return (new GetterNode<bool>() ) ;
            case "getterstring":
                return (new GetterNode<string>() ) ;
            case "getternum":
                return (new GetterNode<float>() ) ;
            case "getterint":
                return (new GetterNode<int>() ) ;
            case "getterobj":
            case "getterpm":
                return (new GetterNode<Transform>() ) ;
            case "gettervector":
                return (new GetterNode<Vector3>() ) ;
        
            case "constantbool":
                return (new ConstantNode<bool>() ) ;
            case "constantstring":
                return (new ConstantNode<string>() ) ;
            case "constantnum":
                return (new ConstantNode<float>() ) ;
            case "constantint":
                return (new ConstantNode<int>() ) ;
            case "constantobj":
            case "constantpm":
                return (new ConstantNode<Transform>() ) ;
            case "constantvector":
                return (new ConstantNode<Vector3>() ) ;
            
            default:
            {
                Debug.LogError("Invalid Node Type!");
                return new EventNode();
            }          
        }
    }
}
