using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class InfoCourse : MonoBehaviour
{
    [SerializeField]
    public Text positon_label;
    [SerializeField]
    public Text turn_label;

    private string turn_str = "Turns: ";

    public bool checkpoint = false;
    public int position = 1;
    public int turn = 1;
    public GameMgr gameMgr;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init() {
        gameMgr = GameMgr.Instance;
        turn_label.text = turn_str + turn + "/" + gameMgr.max_turn;
    }

    public void UpdateTurn()
    {
        turn_label.text = turn_str + turn + "/" + gameMgr.max_turn;
    }
}