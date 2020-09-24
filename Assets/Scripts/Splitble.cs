using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static System.Math;

public class Splitble : MonoBehaviour{

    float partSize = 0.1f; 
    private MeshBuilder meshBuilder = new MeshBuilder();

    void Start(){
        
    }

    void Update(){
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag.Equals("obsticle")){
            Debug.Log(other.relativeVelocity);
            Debug.Log(other.GetContact(0).point);
            Split(other.GetContact(0).point, other.relativeVelocity);
        }
    }

    private void Split(Vector3 contactPoint, Vector3 forceVector){
        Vector3 ceilingForceVector = new Vector3((float)Ceiling(forceVector.x/partSize),(float)Ceiling(forceVector.y/partSize),(float)Ceiling(forceVector.z/partSize));
        Vector3 ceilingContactPoint = new Vector3((float)Ceiling(contactPoint.x/partSize),(float)Ceiling(contactPoint.y/partSize),(float)Ceiling(contactPoint.z/partSize));

        GameObject part = meshBuilder.buildGameObject(contactPoint, partSize/2);
    }

}
