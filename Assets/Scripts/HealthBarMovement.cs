using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarMovement : MonoBehaviour
{
    [SerializeField] private Transform parentObjt;

    // Update is called once per frame
    void Update()
    {
        if(parentObjt.gameObject.tag == "Boss")
        {
            transform.position = new Vector3(parentObjt.position.x, parentObjt.position.y + 5, parentObjt.position.z);
        }
        else
        {
            transform.position = new Vector3(parentObjt.position.x, parentObjt.position.y + 1, parentObjt.position.z);
        }
         
    }
}
