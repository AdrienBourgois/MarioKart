using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : InfoCourse {

    [SerializeField]
    private Text positon_label;
    [SerializeField]
    private Text turn_label;

    // Use this for initialization
    void Start() {
        Init();
        turn_label.text = Turn_str + Turn + "/" + GameMgr.max_turn;
    }
	
	// Update is called once per frame
	void Update() {
        turn_label.text = Turn_str + Turn + "/" + GameMgr.max_turn;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Finish"))
        {
            if (Checkpoint)
            {
                if (Turn == GameMgr.max_turn && Position == 1)
                {
                    GameMgr.Victory();
                }
                else
                {
                    Turn = Turn + 1;
                    Checkpoint = false;
                }
            }
        }

        if (collider.gameObject.layer == LayerMask.NameToLayer("Checkpoint"))
        {
            Checkpoint = true;
        }
    }
}
