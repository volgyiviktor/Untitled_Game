using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    Vector3 pos;
    public float speed = 1f;
    public Texture2D cursorTexture;
    //void Start()
    //{
    //    Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    //}

    void Update()
    {
        pos = Input.mousePosition;
        pos.z = speed;
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        //transform.position = mousePosition;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }


}
