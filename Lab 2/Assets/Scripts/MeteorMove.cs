using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMove : MonoBehaviour
{
    public float force;
    public GameObject impactPrefab;

    private Rigidbody rb;
    private Animator anim;
    private Vector3 startPos, endPos, velocity;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
            rb.AddForce(velocity * force);
    }

    private void OnCollisionEnter(Collision collision)
	{
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if (impactPrefab != null)
		{
            var impactVFX = Instantiate(impactPrefab, pos, rot) as GameObject;
            Destroy(impactVFX, 5);
        }
        //Debug.Log(collision.gameObject.name);
        Destroy(gameObject);
	}

    public void GetStartPos()
    {
        startPos = transform.position;
    }

    public void GetEndPos()
    {
        endPos = transform.position;
        velocity = endPos - startPos;
        anim.enabled = false;
        isMoving = true;
    }
}
