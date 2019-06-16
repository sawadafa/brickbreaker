
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball1Control : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject daoju1pre;
    public GameObject daoju2pre;

    static public int leftball = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public bool isstart;

    private Vector3 point;
    
    private int poss = 0;
    public void startmove()
    {
        float x = Random.Range(-1f, 1f);
        rb.velocity = new Vector2(x, 1).normalized * 3;
        isstart = true;
        point = transform.position;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isstart == false)
        {
            return;
        }
        if (transform.position == point)
        {
            return;
        }
        if (collision.collider.tag == "brick1" || collision.collider.tag == "brick")
        {
            Destroy(collision.collider.gameObject);
            if (collision.collider.tag == "brick1")
            {
                poss = Random.Range(0, 100);
                poss = poss < 49 ? 0 : 1;
                if (poss == 0)
                {
                    ContactPoint2D contact = collision.contacts[0];
                    Vector2 pos = contact.point;
                    Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
                    Instantiate(daoju1pre, pos, rot);
                }
                else
                {
                    ContactPoint2D contact = collision.contacts[0];
                    Vector2 pos = contact.point;
                    Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
                    Instantiate(daoju1pre, pos, rot);
                }
            }
        }
        if (collision.collider.tag == "daoju1")
        {

        }
        else
        {
            Vector2 Invec = transform.position - point;
            point = transform.position;
            Vector2 Outvec = Vector2.Reflect(Invec, collision.contacts[0].normal);
            GetComponent<Rigidbody2D>().velocity = Outvec.normalized * 3;
        }
        if (rb.velocity.normalized.x < 0.1 && rb.velocity.normalized.x > -0.1)
        {
            rb.velocity = new Vector2(1f, 1f).normalized * 3;
        }
        if (rb.velocity.normalized.y < 0.1 && rb.velocity.normalized.y > -0.1)
        {
            rb.velocity = new Vector2(1f, 1f).normalized * 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "daoju1" || collision.name == "daoju2")
        {
            
        }
        else
        {
            Destroy(gameObject);
            leftball--;
        }
    }

    void Update()
    {
        
    }
}
