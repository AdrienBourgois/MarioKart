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

    private float max_pos = 10f;
    private float reach_distance = 5.0f;
    private Vector3 current_point;
    private Vector3 last_point;
    private int current_way_point_id = 0;
    private ICarController controller;

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
            Vector3 rand_way_point = new Vector3(Random.Range(-max_pos, max_pos), 0, Random.Range(-max_pos, max_pos));
            float distance = Vector3.Distance(path.points[current_way_point_id].position + rand_way_point, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, path.points[current_way_point_id].position + rand_way_point, Time.deltaTime * speed);

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