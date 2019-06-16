using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickmanager : MonoBehaviour {

    public enum brickbreakerstate { playing, win, lost };

    public GameObject Brickpre;
    public GameObject Brickpre1;

    public float width = 0.64f;
    public float height = 0.16f;

    public int x = 15;
    public int y = -3;
    
    void Start () {
        
        Screen.SetResolution(1024, 512, true);

		for(int i = 0;i > y; i--)
        {
            for(int j = 0;j < x; j++)
            {
                if( (i == -1 && j == 1) || (i == -1 && j == 13))
                {
                    GameObject go = Instantiate(Brickpre1, transform);
                    go.transform.localPosition = new Vector2(width * j, height * i);
                }
                else
                {
                    GameObject go = Instantiate(Brickpre, transform);
                    go.transform.localPosition = new Vector2(width * j, height * i);
                }
            }
        }
        
	}
	
	void Update () {
		
	}
}
