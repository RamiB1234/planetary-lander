using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoroid : MonoBehaviour
{
    public float velocity = 2f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocity);
        GetComponent<Rigidbody2D>().angularVelocity = Random.value * 50;

        // Tilt
        Vector3 euler = transform.localEulerAngles;
        euler.z = Mathf.Lerp(euler.z, 0, 2.0f * Time.deltaTime);
        transform.localEulerAngles = euler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
