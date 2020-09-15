using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour{
    
    private MeshFilter meshFilter;

    void Start(){
       meshFilter = FindObjectOfType<MeshFilter>();
       Debug.Log(transform.up);
       Debug.Log(transform.right);
    }

    void Update(){
        
    }

    private void OnMouseDown() {
        Split();
    }

    void Split(){
        float size = 0.5f;
        Vector3 initialPoint = transform.InverseTransformPoint(transform.position);
        Vector3[] vertices = {
			initialPoint + new Vector3 (-size, -size, size),
			initialPoint + new Vector3 (size, -size, size),
			initialPoint + new Vector3 (size, size, size),
			initialPoint + new Vector3 (-size, size, size),
			initialPoint + new Vector3 (-size, size, -size),
			initialPoint + new Vector3 (size, size, -size),
			initialPoint + new Vector3 (size, -size, -size),
			initialPoint + new Vector3 (-size, -size, -size)
		};

		int[] triangles = {
			0, 2, 1, //face front
			0, 3, 2,
			2, 3, 4, //face top
			2, 4, 5,
			1, 2, 5, //face right
			1, 5, 6,
			0, 7, 4, //face left
			0, 4, 3,
			5, 4, 7, //face back
			5, 7, 6,
			0, 6, 7, //face bottom
			0, 1, 6
		};

        Vector2[] uvs = {
            new Vector2(1,1),
            new Vector2(1,1),
            new Vector2(1,1),
            new Vector2(1,1),
            new Vector2(1,1),
            new Vector2(1,1),
            new Vector2(1,1),
            new Vector2(1,1)
        };
			
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.Clear ();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
        mesh.uv = uvs;
		mesh.RecalculateNormals();
    }
}
