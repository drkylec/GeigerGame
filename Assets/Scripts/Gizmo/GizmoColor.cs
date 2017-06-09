/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using System.Collections;

public class GizmoColor : MonoBehaviour {

    //sets colors to the gizmos to lower confussion
    //0 = yellow
    //1 = blue
    //2 = magenta
    //3 = white
    //4 = red
    public int index = 0;
    BoxCollider bc;
    //Quaternion quat;

    void Start()
    {
        
    }

    //changes the color of the gizmo
    void OnDrawGizmosSelected()
    {
        bc = GetComponent<BoxCollider>();
        //quat = GetComponent<Quaternion>();
        Matrix4x4 rotationMatrix = Matrix4x4.TRS(this.transform.position, this.transform.rotation, this.transform.lossyScale);
        Gizmos.matrix = transform.localToWorldMatrix;
        if (index == 0)
        {
            //Vector3 boxPos = this.transform.position + this.bc.center;
            //Quaternion boxRot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            Gizmos.color = Color.yellow;
            //Gizmos.DrawWireSphere(transform.position, 2);
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(bc.size.x, bc.size.y, bc.size.z));
        }
        if (index == 1)
        {
            //Vector3 boxPos = this.transform.position + this.bc.center;
            Gizmos.color = Color.blue;
            //Gizmos.DrawWireSphere(transform.position, 2);
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(bc.size.x, bc.size.y, bc.size.z));
        }
        if (index == 2)
        {
            //Vector3 boxPos = this.transform.position + this.bc.center;
            Gizmos.color = new Color(1,0,1,1);
            //Gizmos.DrawWireSphere(transform.position, 2);
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(bc.size.x, bc.size.y, bc.size.z));
        }
        if (index == 3)
        {
            //Vector3 boxPos = this.transform.position + this.bc.center;
            Gizmos.color = Color.white;
            //Gizmos.DrawWireSphere(transform.position, 2);
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(bc.size.x, bc.size.y, bc.size.z));
        }
        if (index == 4)
        {
            //Vector3 boxPos = this.transform.position + this.bc.center;
            Gizmos.color = Color.red;
            //Gizmos.DrawWireSphere(transform.position, 2);
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(bc.size.x, bc.size.y, bc.size.z));
        }
    }
}
