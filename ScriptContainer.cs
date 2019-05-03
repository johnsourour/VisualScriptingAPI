using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

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

        ParseIntermediateCode("CodeExported.txt");

        // symbolTable.Add<string>("Wow");

        // eventStartNode = new EventNode();
        // EventNode e = eventStartNode;
        // nodes.Add(eventStartNode);

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
        // ConstantNode<GameObject> c1 = new ConstantNode<GameObject>(gameObject);
        // nodes.Add(c1);

        // Vector3 v1 = new Vector3(1, 1, 1);
        // ConstantNode<Vector3> vc1 = new ConstantNode<Vector3>(v1);
        // nodes.Add(vc1);
        // Vector3 v2 = new Vector3(3, 3, 3);
        // ConstantNode<Vector3> vc2 = new ConstantNode<Vector3>(v2);
        // nodes.Add(vc2);
        // Vector3 v3 = new Vector3(0, 90, 0);
        // ConstantNode<Vector3> vc3 = new ConstantNode<Vector3>(v3);
        // nodes.Add(vc3);

        // MoveObject mo = new MoveObject();
        // nodes.Add(mo);

        // ScaleObject so = new ScaleObject();
        // nodes.Add(so);

        // RotateObject ro = new RotateObject();
        // nodes.Add(ro);

        // dynamic mo = createNode("moveobject");
        // nodes.Add(mo);

        // dynamic ro = createNode("rotateobject");
        // nodes.Add(ro);

        // dynamic so = createNode("scaleobject");
        // nodes.Add(so);

        // e.setOutputPin(mo, 0);

        // mo.setInputPin(vc1 , 0, PinDataType.Vector);
        // mo.setInputPin(c1, 1, PinDataType.GameObject);
        // mo.setOutputPin(so, 0);

        // so.setInputPin(vc2 , 0, PinDataType.Vector);
        // so.setInputPin(c1, 1, PinDataType.GameObject);
        // so.setOutputPin(ro, 0);

        // ro.setInputPin(vc3, 0, PinDataType.Vector);
        // ro.setInputPin(c1, 1, PinDataType.GameObject);

    }

    public void Start() {
        if (eventStartNode!=null)
            eventStartNode.run();
    }

    public void Update() {
        if (eventUpdateNode!=null)
            eventUpdateNode.run();

        if (Input.GetMouseButtonDown(0) && eventPressNode!=null)
            eventPressNode.run();

        if (Input.GetMouseButtonUp(0) && eventReleaseNode!=null)
            eventReleaseNode.run();

        if (Input.GetKeyDown(KeyCode.UpArrow) && eventSwipeUpNode!=null)
            eventSwipeUpNode.run();

        if (Input.GetKeyDown(KeyCode.DownArrow) && eventSwipeDownNode!=null)
            eventSwipeDownNode.run();
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && eventSwipeLeftNode!=null)
            eventSwipeLeftNode.run();

        if (Input.GetKeyDown(KeyCode.RightArrow) && eventSwipeRightNode!=null)
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
                return new SetTextFont();
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
            case "getgesturepos":
                return new GetGesturePosition();
            
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
    private void ParseIntermediateCode(string filename)
    {
        bool var_flag = true;
        int list_count = 0;
        
        FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

        using (StreamReader streamReader = new StreamReader(fs, Encoding.Default))
        {
            string line = String.Empty;
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line == "[" && list_count == 0)
                {
                    var_flag = false;
                    list_count++;
                    line = streamReader.ReadLine();
                }

                if (var_flag)
                {
                    string[] tokens = line.Split(':');
                    if (tokens[0] != null && tokens[1] != null)
                    {
                        switch (tokens[0])
                        {
                            case "GameObject":
                                symbolTable.Add<GameObject>(tokens[1]);
                                break;
                            case "Component3D":
                                symbolTable.Add<_3DObject>(tokens[1]);
                                break;
                            case "Integer":
                                symbolTable.Add<int>(tokens[1]);
                                break;
                            case "Number":
                                symbolTable.Add<float>(tokens[1]);
                                break;
                            case "ProjectionMap":
                                symbolTable.Add<GameObject>(tokens[1]);
                                break;
                            case "String":
                                symbolTable.Add<string>(tokens[1]);
                                break;
                            case "Bool":
                                symbolTable.Add<bool>(tokens[1]);
                                break;
                            case "ComponentText":
                                symbolTable.Add<Text>(tokens[1]);
                                break;
                            case "Vector":
                                symbolTable.Add<Vector3>(tokens[1]);
                                break;
                            case "Image":
                               symbolTable.Add<Image>(tokens[1]);
                               break;
                            default:
                                Debug.LogError("Invalid type in Symbol Table Entry");
                                break;
                        }
                    }
                }
                else //if node_flag
                {
                    string internal_node_name;
                    if (line == "{")
                    {
                        line = streamReader.ReadLine();
                        internal_node_name = line;
                        Node nd = createNode(internal_node_name); //dynamic instead of Node
                        nodes.Add(nd);

                        while (streamReader.ReadLine() != "[") ; //ignore graphical data

                        line = streamReader.ReadLine();
                        while (line != "]") //read input pins
                        {
                            string[] tokens = line.Split(' ');
                            if (tokens[0] != "Execution") //save pins if not execution
                            {
                                uint node_index, pin_index, datatype_index_start, datatype_index_end;
                                string datatype;

                                //parse line to find node and pin
                                node_index = (uint)(line.IndexOf("node") + 4);
                                pin_index = (uint)(line.IndexOf("pin") + 3);
                                datatype_index_start = (uint)(line.IndexOf(":") + 1);
                                datatype_index_end = (uint)(line.IndexOf(" ", (int)datatype_index_start));
                                datatype = line.Substring((int)datatype_index_start, (int)datatype_index_end - (int)datatype_index_start);

                                PinDataType pdt = PinDataType.Number; //Default

                                switch (datatype)
                                {
                                    case "GameObject":
                                        pdt = PinDataType.GameObject;
                                        break;
                                    case "Component3D":
                                        pdt = PinDataType.Component3D;
                                        break;
                                    case "Integer":
                                        pdt = PinDataType.Integer;
                                        break;
                                    case "Number":
                                        pdt = PinDataType.Number;
                                        break;
                                    case "ProjectionMap":
                                        pdt = PinDataType.ProjectionMap;
                                        break;
                                    case "String":
                                        pdt = PinDataType.String;
                                        break;
                                    case "Bool":
                                        pdt = PinDataType.Bool;
                                        break;
                                    case "ComponentText":
                                        pdt = PinDataType.ComponentText;
                                        break;
                                    case "Image":
                                       pdt = PinDataType.Image;
                                       break;
                                    case "VariableReference":
                                       pdt = PinDataType.VariableReference;
                                       break;
                                    case "Vector":
                                        pdt = PinDataType.Vector;
                                        break;
                                    default:
                                        Debug.LogError("Invalid Pin Datatype");
                                        break;
                                }

                                nd.setInputPin(nodes[(int)node_index], pin_index, pdt);
                            }
                            line = streamReader.ReadLine();
                        }

                        streamReader.ReadLine(); //ignore '['

                        line = streamReader.ReadLine();
                        while (line != "]") //read ouput pins
                        {
                            string[] tokens = line.Split(' ');
                            if (tokens[0] == "Execution") //save pins only if execution
                            {
                                uint node_index, pin_index;

                                //parse line to find node and pin
                                node_index = (uint)(line.IndexOf("node") + 4);
                                pin_index = (uint)(line.IndexOf("pin") + 3);
                                
                                //parse line to find node and pin
                                nd.setOutputPin(nodes[(int)node_index], pin_index);

                                line = streamReader.ReadLine();
                            }
                        }

                        streamReader.ReadLine(); //ignore '['

                        line = streamReader.ReadLine();
                        while (line != "]") //read parameters
                        {
                            //TODO: save parameters
                            line = streamReader.ReadLine();
                        }
                        streamReader.ReadLine(); //ignore "}"
                    }
                }
            }
        }
    }

}
