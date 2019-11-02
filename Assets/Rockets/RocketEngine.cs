using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class RocketEngine : MonoBehaviour
{

    private MeshFilter filter;
    private Mesh mesh;

    private int nextVertIndex = 0;

    private readonly Dictionary<Vector3, int> verts = new Dictionary<Vector3, int>();
    private readonly List<Tuple<Vector3, Vector3, Vector3>> tris = new List<Tuple<Vector3, Vector3, Vector3>>();

    // Start is called before the first frame update
    void Start()
    {
        filter = GetComponent<MeshFilter>();
        mesh = filter.mesh;

        if (mesh == null) mesh = new Mesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int addVert(Vector3 v)
    {
        verts.Add(v, nextVertIndex);

        return nextVertIndex++;
    }

    private void createTri(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        tris.Add(new Tuple<Vector3, Vector3, Vector3>(v1, v2, v3));
    }

    private void compileMesh()
    {
        mesh.vertices = verts.Keys.ToArray();
    }
}
