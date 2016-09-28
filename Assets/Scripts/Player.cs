using UnityEngine;
using System.Collections;

public class Player : InfoCourse {

	// Use this for initialization
	void Start() {
        Init();
    }
	
	// Update is called once per frame
	void Update() {
        UpdateTurn();
    }

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 2))
        {
            //print("There is lol");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Finish"))
        {
            if (checkpoint)
            {
                if (turn == gameMgr.max_turn && position == 1)
                {
                    gameMgr.victory_label.enabled = true;
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
