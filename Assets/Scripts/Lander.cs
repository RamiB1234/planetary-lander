using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lander : MonoBehaviour
{
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float verticalMovement = Input.GetAxis("Vertical") * speed;
        float horizontalMovement = Input.GetAxis("Horizontal") * speed;
        if(horizontalMovement>0)
        {
            GetComponent<Animator>().SetBool("MovingRight", true);
            GetComponent<Animator>().SetBool("MovingLeft", false);
        }
        else if (horizontalMovement < 0)
        {
            GetComponent<Animator>().SetBool("MovingLeft", true);
            GetComponent<Animator>().SetBool("MovingRight", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("MovingRight", false);
            GetComponent<Animator>().SetBool("MovingLeft", false);
        }

        GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalMovement, verticalMovement));
    }
}
