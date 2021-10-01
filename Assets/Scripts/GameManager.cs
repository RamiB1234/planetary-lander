using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public bool missionFailed = false;
    public GameObject missionFailedMenu;

    void Awake()
    {
        if (GM != null)
            Destroy(GM);
        else
            GM = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(missionFailed)
        {
            missionFailedMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Retry()
    {
        missionFailed = false;
        Time.timeScale = 1;
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
