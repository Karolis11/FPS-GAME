using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarMovement : MonoBehaviour
{
    [SerializeField] private Transform parentObjt;

    // Update is called once per frame
    void Update()
    {
         transform.position = new Vector3(parentObjt.position.x, parentObjt.position.y + 1, parentObjt.position.z);
    }
}
