using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

    [SerializeField]
    private Color line_color;

    private List<Transform> points = new List<Transform>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = line_color;

        Transform[] path_transforms = GetComponentsInChildren<Transform>();
        points = new List<Transform>();

        for(int i = 0; i < path_transforms.Length; i++)
        {
            if (path_transforms[i] != transform)
            {
                points.Add(path_transforms[i]);
            }
        }

        for(int i = 0; i < points.Count; i++)
        {
            Vector3 current_point = points[i].position;
            Vector3 previous_point = Vector3.zero;

            if (i > 0)
            {
                previous_point = points[i - 1].position;
            }
            else if (i == 0 && points.Count > 1)
            {
                previous_point = points[points.Count - 1].position;
            }

            Gizmos.DrawLine(previous_point, current_point);
            Gizmos.DrawWireSphere(current_point, 0.3f);
        }
    }
} 