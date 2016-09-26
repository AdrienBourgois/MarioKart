using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoCourse : MonoBehaviour
{
    [SerializeField]
    private Text positon_label;
    [SerializeField]
    private Text turn_label;
    [SerializeField]
    private Text victory_label;
    [SerializeField]
    private Text loose_label;

    private string turn_str = "Turns: ";

    private bool checkpoint = false;
    private int position = 1;
    private int turn = 1;
    private GameMgr gameMgr;

    void Awake()
    {
        victory_label.enabled = false;
        loose_label.enabled = false;
    }

    // Use this for initialization
    void Start()
    {
        gameMgr = GameMgr.Instance;
        turn_label.text = turn_str + turn + "/" + gameMgr.max_turn;
    }

    // Update is called once per frame
    void Update()
    {
        turn_label.text = turn_str + turn + "/" + gameMgr.max_turn;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Finish"))
        {
            if (checkpoint)
            {
                if (turn == gameMgr.max_turn && position == 1)
                {
                    victory_label.enabled = true;
                }
                else
                {
                    turn = turn + 1;
                    checkpoint = false;
                }
            }
        }

        if (collider.gameObject.layer == LayerMask.NameToLayer("Checkpoint"))
        {
            checkpoint = true;
        }
    }
}