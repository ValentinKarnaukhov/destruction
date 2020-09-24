using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshBuilder{

    public GameObject buildGameObject(Vector3 center, float size){
        GameObject gameObject = new GameObject();

        gameObject.AddComponent<MeshFilter>();
        gameObject.GetComponent<MeshFilter>().mesh = buildMesh(center, size);
        gameObject.AddComponent<MeshRenderer>();
        gameObject.transform.TransformVector(center);
    
        return gameObject;
    }

    public Mesh buildMesh(Vector3 center, float size){
        Vector3 initialPoint = center;

		Vector3[] coordiates = {
			initialPoint + new Vector3 (-size, -size, size),
			initialPoint + new Vector3 (size, -size, size),
			initialPoint + new Vector3 (size, -size, -size),
			initialPoint + new Vector3 (-size, -size, -size),

			initialPoint + new Vector3 (-size, size, size),
			initialPoint + new Vector3 (size, size, size),
			initialPoint + new Vector3 (size, size, -size),
			initialPoint + new Vector3 (-size, size, -size),
		};

        Vector3[] vertices = {
			//bottom
			coordiates[0], coordiates[1], coordiates[2], coordiates[3],
			//left
			coordiates[7], coordiates[4], coordiates[0], coordiates[3],
			//front
			coordiates[4], coordiates[5], coordiates[1], coordiates[0],
			//back
			coordiates[6], coordiates[7], coordiates[3], coordiates[2],
			//right
			coordiates[5], coordiates[6], coordiates[2], coordiates[1],
			//top
			coordiates[7], coordiates[6], coordiates[5], coordiates[4]
		};

		Vector3 up = Vector3.up;
        Vector3 down = Vector3.down;
        Vector3 forward = Vector3.forward;
        Vector3 back = Vector3.back;
        Vector3 left = Vector3.left;
        Vector3 right = Vector3.right;

		Vector3[] normals = {
	        down, down, down, down,             // bottom
	        left, left, left, left,             // left
	        forward, forward, forward, forward,	// front
	        back, back, back, back,             // back
	        right, right, right, right,         // right
	        up, up, up, up	                    // top
        };

		Vector2 uv00 = new Vector2(0f, 0f);
        Vector2 uv10 = new Vector2(1f, 0f);
        Vector2 uv01 = new Vector2(0f, 1f);
        Vector2 uv11 = new Vector2(1f, 1f);

		Vector2[] uvs = {
	        uv11, uv01, uv00, uv10, // bottom
	        uv11, uv01, uv00, uv10, // left
	        uv11, uv01, uv00, uv10, // front
	        uv11, uv01, uv00, uv10, // back	        
	        uv11, uv01, uv00, uv10, // right 
	        uv11, uv01, uv00, uv10  // top
        };

		int[] triangles = {
	        3, 1, 0,        3, 2, 1,        // bottom	
	        7, 5, 4,        7, 6, 5,        // left
	        11, 9, 8,       11, 10, 9,      // front
	        15, 13, 12,     15, 14, 13,     // back
	        19, 17, 16,     19, 18, 17,	    // right
	        23, 21, 20,     23, 22, 21,	    // top
        };

		Mesh mesh = new Mesh();
		mesh.Clear ();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uvs;
		mesh.Optimize ();
        return mesh;
    }

}
