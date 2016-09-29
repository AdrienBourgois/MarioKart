using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IAController : MonoBehaviour {

    [SerializeField]
    private Path path;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float rotation_speed = 5f;
    [SerializeField]
    private GameMgr gameMgr;

    private float reach_distance = 5.0f;
    private Vector3 current_point;
    private Vector3 last_point;
    private int current_way_point_id = 0;
    private ICarController controller = null;

    void Awake()
    {
        controller = GetComponent<ICarController>();
    }

    // Use this for initialization
    void Start () {
        gameMgr = GameMgr.Instance;
        last_point = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameMgr.game_ready == true)
        {
            controller.Move(0f, 1f, 0f, 0f);
            float distance = Vector3.Distance(path.points[current_way_point_id].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, path.points[current_way_point_id].position, Time.deltaTime * speed);

            Quaternion rotation = Quaternion.LookRotation(path.points[current_way_point_id].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotation_speed);

            if (distance <= reach_distance)
            {
                current_way_point_id++;
            }

            if (current_way_point_id >= path.points.Count)
            {
                current_way_point_id = 0;
            }
        }
    }
}