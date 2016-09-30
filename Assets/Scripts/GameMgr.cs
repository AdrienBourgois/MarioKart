using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour {

    [SerializeField]
    public int max_turn = 3;
    [SerializeField]
    private Text victory_label;
    [SerializeField]
    private Text loose_label;
    [SerializeField]
    private Text counter_label;
    [SerializeField]
    private Button retry_button;
    [SerializeField]
    private Button quit_button;

    private CarUserControl car_use;
    public bool game_ready = false;
    private static GameMgr instance = null;
    public static GameMgr Instance
    {
        get
        {
            if (instance != null)
                return instance;
            instance = GameObject.FindGameObjectWithTag("GameMgr").GetComponent<GameMgr>();
            return instance;
        }
    }

    void Awake()
    {
        victory_label.enabled = false;
        loose_label.enabled = false;
        retry_button.gameObject.SetActive(false);
        quit_button.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(Counter());
	}
	
	// Update is called once per frame
	void Update () {
    }

    IEnumerator Counter()
    {
        for (int count = 3; count >= 0; count--)
        {
            if (count == 3)
                counter_label.text = "3";
            if (count == 2)
            {
                counter_label.color = Color.yellow;
                counter_label.text = "2";
            }
            if (count == 1)
            {
                counter_label.color = Color.green;
                counter_label.text = "1";
            }
            if (count == 0)
            {
                counter_label.color = Color.white;
                counter_label.text = "Go!!";
                game_ready = true;
                car_use = GameObject.FindGameObjectWithTag("Player").GetComponent<CarUserControl>();
                car_use.RegisterInputFunctions();
            }
            yield return new WaitForSeconds(1.5f);
        }
        counter_label.enabled = false;
    }

    public void Victory()
    {
        if (loose_label.enabled == true)
            return;
        victory_label.enabled = true;
        game_ready = false;
        car_use.UnregisterInputFunctions();
        ShowButton();
    }

    public void Loose()
    {
        if (victory_label.enabled == true)
            return;
        loose_label.enabled = true;
        game_ready = false;
        car_use.UnregisterInputFunctions();
        ShowButton();
    }

    void ShowButton()
    {
        retry_button.gameObject.SetActive(true);
        quit_button.gameObject.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}