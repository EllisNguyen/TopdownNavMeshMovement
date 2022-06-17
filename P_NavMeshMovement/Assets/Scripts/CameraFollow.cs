///************************************
/// 
/// Author: Phap Nguyen.
/// Description: A simple camera follow target script.
/// Date created:07/05/2022
/// Last edited: 18/06/2022
/// 
///************************************

using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform targetObject;

    public void Update()
    {
        gameObject.transform.position = targetObject.position;
    }
}
