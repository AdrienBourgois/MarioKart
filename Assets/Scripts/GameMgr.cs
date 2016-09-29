using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {

    [SerializeField]
    public Text victory_label;
    [SerializeField]
    public Text loose_label;
    [SerializeField]
    private Text counter_label;
    [SerializeField]
    public int max_turn = 3;

    //private int count = 3;
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
                //counter_label.enabled = false;
            }
            yield return new WaitForSeconds(1.5f);
        }
        counter_label.enabled = false;
    }
}