using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject meteor;
    public Transform startPoint;
    public Transform endPoint;
    // Start is called before the first frame update
    void Start()
    {
        var startPos = startPoint.position;
        GameObject objVFX = Instantiate(meteor, startPos, Quaternion.identity) as GameObject;

        var endPos = endPoint.position;

        RotateTo(objVFX, endPos);
    }

    // Update is called once per frame
    void RotateTo(GameObject obj, Vector3 destination)
    {
        var direction = destination - obj.transform.position;
        var rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
}
