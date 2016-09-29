using UnityEngine;
using System.Collections;

public class IA : InfoCourse
{
    // Use this for initialization
    void Start() {
        Init();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Finish"))
        {
            if (Checkpoint)
            {
                if (Turn == GameMgr.max_turn && Position == 1)
                {
                    GameMgr.loose_label.enabled = true;
                    GameMgr.game_ready = false;
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