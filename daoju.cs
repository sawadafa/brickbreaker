using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daoju : MonoBehaviour {

    public GameObject ball1;
    public GameObject daoju1pre;
    public GameObject daoju2pre;
    
	void Start () {
		
	}
	
	void Update () {
        GetComponent<Rigidbody>().velocity = new Vector2(0, -1).normalized * 3;
        int leftball = BallControl.leftball + Ball1Control.leftball;
        if(leftball < 1)
        {

        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ban")
        {
            Destroy(daoju1pre);
            ContactPoint2D contact = collision.contacts[0];
            Vector2 pos = contact.point;
            pos.y += 0.2f;
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Instantiate(ball1, pos, rot);
            ball1.GetComponent<Ball1Control>().startmove();
            Ball1Control.leftball++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(daoju1pre);
    }
}
