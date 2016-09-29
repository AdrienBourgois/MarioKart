using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IAPath : MonoBehaviour {

    [SerializeField]
    private Transform path;
    [SerializeField]
    private float max_steer_angle;
    [SerializeField]
    private WheelCollider wheel_fl;
    [SerializeField]
    private WheelCollider wheel_fr;
    [SerializeField]
    private WheelCollider wheel_fl1;
    [SerializeField]
    private WheelCollider wheel_fr1;
    [SerializeField]
    private Transform center_of_mass;

    private List<Transform> points;
    private int current_point = 0;
    private float dist_from_path = 20f;
    private int current_path_obj = 0;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().centerOfMass = center_of_mass.position;
        Transform[] path_transforms = path.GetComponentsInChildren<Transform>();
        points = new List<Transform>();

        for (int i = 0; i < path_transforms.Length; i++)
        {
            if (path_transforms[i] != path.transform)
            {
                points.Add(path_transforms[i]);
            }
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        ApplySteer();
	}

    void ApplySteer()
    {
        Vector3 relative_vector = transform.InverseTransformPoint(points[current_point].position);
        float new_steer = (relative_vector.x / relative_vector.magnitude) * max_steer_angle;
        wheel_fl.steerAngle = new_steer;
        wheel_fr.steerAngle = new_steer;
        wheel_fl1.steerAngle = new_steer;
        wheel_fr1.steerAngle = new_steer;
    }
}