using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _3DObject 
{
    public MeshFilter mesh_filter;
    public MeshRenderer mesh_renderer;
    public _3DObject(MeshFilter _mesh_filter, MeshRenderer _mesh_renderer){
        mesh_filter = _mesh_filter;
        mesh_renderer = _mesh_renderer;
    }
}