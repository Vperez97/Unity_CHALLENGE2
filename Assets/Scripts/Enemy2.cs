using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.UIElements;

public class Enemy2 : MonoBehaviour

{
    private bool dirRight = true;
    public float speed = 2.0f;

    void Update()
    {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= 10f)
        {
            dirRight = false;
        }

        if (transform.position.x <= 6.5)
        {
            dirRight = true;
        }
    }
}