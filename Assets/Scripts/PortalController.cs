using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
   private  Transform dest;
    public Transform destA;
    public Transform destB;
    GameObject player;

    public bool isB;
    public bool isA;
    public float distance = 0.2f;

    //Start is called before the first frame update
    void Start()
    {
        dest = null;

        if (isB == false)
        {
            dest = destA;
        }
        if (isA == false)
        {
            dest = destB;
        }

    }
    //private void Awake()
    //{
    //    dest = null;

    //    if (isB == false)
    //    {
    //        dest = destA;
    //    }
    //    if (isA == false)
    //    {
    //        dest = destB;
    //    }

    //    player = GameObject.FindGameObjectWithTag("Player");
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        //if (Vector2.Distance(player.transform.position, transform.position) > 0.3f)
    //        //{
    //            player.transform.position = destination.transform.position;
    //        //}
    //    }

    //}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //if (isB == false)
            //{
            //    dest = GameObject.FindGameObjectWithTag("PortalB").GetComponent<Transform>();
            //}
            //if (isA == false)
            //{
            //    dest = GameObject.FindGameObjectWithTag("PortalA").GetComponent<Transform>();
            //}

            if (Vector2.Distance(transform.position, other.transform.position) > distance)
            {
                other.transform.position = new Vector2(dest.position.x, dest.position.y);
            }
        }
    }


    

}
