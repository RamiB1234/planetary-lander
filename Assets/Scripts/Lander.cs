using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lander : MonoBehaviour
{
    public float speed = 1f;
    public int health = 10;
    public GameObject surface;
    public GameObject remainingAltitudeText;
    public bool autoPilot = false;
    public GameObject missionSuccessMenu;

    private bool surfaceHit = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("DamageBar").GetComponent<Slider>().maxValue = health;
        GameObject.FindGameObjectWithTag("DamageBar").GetComponent<Slider>().value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(autoPilot==false)
        {
            // Get the horizontal and vertical axis.
            // By default they are mapped to the arrow keys.
            // The value is in the range -1 to 1
            float verticalMovement = Input.GetAxis("Vertical") * speed;
            float horizontalMovement = Input.GetAxis("Horizontal") * speed;
            if (horizontalMovement > 0)
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
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.35f;
        }

        if(surfaceHit==false)
        {
            float dist = Vector2.Distance(transform.position, surface.transform.position);
            remainingAltitudeText.GetComponent<TextMeshProUGUI>().text = Math.Round(dist, 1).ToString();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag== "Meteoroid")
        {
            Destroy(col.gameObject);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ShakeBehavior>().TriggerShake();
            health--;
            GameObject.FindGameObjectWithTag("DamageBar").GetComponent<Slider>().value= health;

            if(health==0)
            {
                GameManager.GM.missionFailed = true;
            }
        }

        if (col.transform.tag == "Surface")
        {
            surfaceHit = true;
            remainingAltitudeText.GetComponent<TextMeshProUGUI>().text = "0";
            missionSuccessMenu.SetActive(true);
            GetComponent<Rigidbody2D>().simulated = false;
            col.transform.GetComponent<Rigidbody2D>().simulated = false;
        }

    }
}
