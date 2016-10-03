using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Car : MonoBehaviour {

    [SerializeField]
    private GameMgr gameMgr;
    [SerializeField]
    private Text positon_label = null;
    [SerializeField]
    private Text turn_label = null;

    private string lap_str = "Laps: ";
    private bool checkpoint = false;
    private int position = 1;
    private int lap = 1;

    // Use this for initialization
    void Start()
    {
        gameMgr = GameMgr.Instance;
        turn_label.text = lap_str + lap + "/" + gameMgr.max_turn;
    }

    // Update is called once per frame
    void Update()
    {
        turn_label.text = lap_str + lap + "/" + gameMgr.max_turn;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Finish"))
        {
            if (checkpoint)
            {
                if (lap == gameMgr.max_turn && position == 1)
                {
                    gameMgr.Victory();
                }
                else
                {
                    lap = lap + 1;
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