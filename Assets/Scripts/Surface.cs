using UnityEngine;

public class Surface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "End")
        {
            GetComponent<Rigidbody2D>().simulated = false;
            GameObject.FindGameObjectWithTag("Lander").GetComponent<Lander>().autoPilot = true;
        }
    }
}
