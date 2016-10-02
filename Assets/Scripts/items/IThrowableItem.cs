using UnityEngine;
using System.Collections;

public interface IThrowableItem
{
    void MoveTo(Transform target, float speed);

    void MoveStraightforward(float speed);
}
