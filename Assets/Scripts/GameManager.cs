using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public static bool gameStarted = false;
    public bool missionFailed = false;
    public GameObject missionFailedMenu;
    public GameObject howToPlayMenu;

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
        if(gameStarted==false)
        {
            Time.timeScale = 0;
            howToPlayMenu.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStarted)
        {
            Time.timeScale = 1;
            howToPlayMenu.SetActive(false);

        }
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

    public void StartGame()
    {
        gameStarted = true;
    }
}
