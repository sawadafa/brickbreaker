using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanControl : MonoBehaviour {

    public float left = -1f;
    public float right = 1f;

	void Start () {
		
	}
	
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        if(horizontal != 0)
        {
            horizontal = horizontal > 0 ? 1 : -1;
            transform.Translate(Vector2.right * 5 * Time.deltaTime * horizontal);
            if(transform.position.x > right || transform.position.x < left)
            {
                transform.Translate(Vector2.right * -5 * Time.deltaTime * horizontal);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(transform.childCount > 0)
            {
                GetComponentInChildren<BallControl>().startmove();
                transform.GetChild(0).parent = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "daoju1")
        {

        }
    }
}
