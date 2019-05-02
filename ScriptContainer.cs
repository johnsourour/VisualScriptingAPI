using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptContainer : MonoBehaviour {
    SymbolTable symbolTable;
    
    List<Node> nodes;

    EventNode eventStartNode;
    EventNode eventUpdateNode;
    EventNode eventPressNode;
    EventNode eventReleaseNode;
    EventNode eventSwipeUpNode;
    EventNode eventSwipeDownNode;
    EventNode eventSwipeLeftNode;
    EventNode eventSwipeRightNode;

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
        if (eventStartNode)
            eventStartNode.run();
    }

    public void Update() {
        if (eventUpdateNode)
            eventUpdateNode.run();

        if (Input.GetMouseButtonDown(0) && eventPressNode)
            eventPressNode.run();

        if (Input.GetMouseButtonUp(0) && eventReleaseNode)
            eventReleaseNode.run();

        if (Input.GetKeyDown(KeyCode.UpArrow) && eventSwipeUpNode)
            eventSwipeUpNode.run();

        if (Input.GetKeyDown(KeyCode.DownArrow) && eventSwipeDownNode)
            eventSwipeDownNode.run();
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && eventSwipeLeftNode)
            eventSwipeLeftNode.run();

        if (Input.GetKeyDown(KeyCode.RightArrow) && eventSwipeRightNode)
            eventSwipeRightNode.run();
    }
    
    public Node createNode(string type){
        switch(type)
        {
            case "rotateobject":
                return new RotateObject();
            case "scaleobject":
                return new ScaleObject();
            case "moveobject":
                return new MoveObject();
            case "printstring":
                return new PrintStringNode();
            case "createobject":
                return new CreateObject();
            case "createtext":
                return new CreateTextComponent();
            case "create3d":
                return new Create3DComponent();
            case "loadfile":
                return new FileToString();
            case "writefile":
                return new WriteToFile();
            case "gettext":
                return new GetTextComponent();
            case "get3d":
                return new Get3DComponent();
            case "setcomptext":
                return new SetComponentText();
            case "setfontsize":
                return new SetTextFontSize();
            case "getcomptext":
                return new GetComponentText();
            case "makevector":
                return new MakeVector();
            case "breakvector":
                return new BreakVector();
            case "numtoint":
                return new NumberToInt();
            case "inttonum":
                return new IntToNumber();
            case "addint":
                return new AddInt();
            case "addnum":
                return new AddNumber();
            case "subint":
                return new SubInt();
            case "subnum":
                return new SubNumber();
            case "divint":
                return new DivInt();
            case "divnum":
                return new DivNumber();
            case "multint":
                return new MultInt();
            case "multnum":
                return new MultNumber();
            case "sqrt":
                return new SquareRoot();
            case "gettime":
                return new GetTime();
            case "lerpnum":
                return new LerpNumber();
            case "lerpvector":
                return new LerpVector();
            case "gtenum":
                return new GreaterEqualNumber();
            case "gtnum":
                return new GreaterNumber();
            case "gteint":
                return new GreaterEqualInt();
            case "gtint":
                return new GreaterInt();
            case "equalnum":
                return new EqualNumber();
            case "equalint":
                return new EqualInt();
            case "not":
                return new Not();
            case "concat":
                return new ConcatenateString();
            case "substring":
                return new GetSubstring();
            case "stringindex":
                return new IndexString();
            case "strlen":
                return new StringLength();
            case "exit":
                return new ExitNode();
            case "setpmstatus":
                return new SetPMStatus();
            
            case "eventstart":
                eventStartNode = new EventNode();
                return eventStartNode;
            case "eventupdate":
                eventUpdateNode = new EventNode();
                return eventUpdateNode;
            case "eventgesturepress":
                eventPressNode = new EventNode();
                return eventPressNode;
            case "eventgesturerelease":
                eventReleaseNode = new EventNode();
                return eventReleaseNode;
            case "eventgestureswipeup":
                eventSwipeUpNode = new EventNode();
                return eventSwipeUpNode;
            case "eventgestureswipedown":
                eventSwipeDownNode = new EventNode();
                return eventSwipeDownNode;
            case "eventgestureswiperight":
                eventSwipeRightNode = new EventNode();
                return eventSwipeRightNode;
            case "eventgestureswipeleft":
                eventSwipeLeftNode = new EventNode();
                return eventSwipeLeftNode;
        
            case "setterbool":
                return new SetterNode<bool>();
            case "setterstring":
                return new SetterNode<string>();
            case "setternum":
                return new SetterNode<float>();
            case "setterint":
                return new SetterNode<int>();
            case "setterobj":
                return new SetterNode<GameObject>();
            case "setter3d":
                return new SetterNode<_3DObject>();
            case "setterpm":
                return new SetterNode<GameObject>();
            case "settertext":
                return new SetterNode<Text>();
            case "settervector":
                return new SetterNode<Vector3>();
        
            case "getterbool":
                return new GetterNode<bool>();
            case "getterstring":
                return new GetterNode<string>();
            case "getternum":
                return new GetterNode<float>();
            case "getterint":
                return new GetterNode<int>();
            case "getterobj":
                return new GetterNode<GameObject>();
            case "getter3d":
                return new GetterNode<_3DObject>();
            case "getterpm":
                return new GetterNode<GameObject>();
            case "gettertext":
                return new GetterNode<Text>();
            case "gettervector":
                return new GetterNode<Vector3>();

        
            case "constantbool":
                return new ConstantNode<bool>();
            case "constantstring":
                return new ConstantNode<string>();
            case "constantnum":
                return new ConstantNode<float>();
            case "constantint":
                return new ConstantNode<int>();
            case "constantobj":
                return new ConstantNode<GameObject>();
            case "constant3d":
                return new ConstantNode<_3DObject>();
            case "constantpm":
                return new ConstantNode<GameObject>();
            case "constanttext":
                return new ConstantNode<Text>();
            case "constantvector":
                return new ConstantNode<Vector3>();
            
            default:
            {
                Debug.LogError("Invalid Node Type!");
                return new EventNode();
            }          
        }
    }
}
