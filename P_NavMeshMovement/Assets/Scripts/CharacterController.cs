///************************************
/// 
/// Author: Phap Nguyen.
/// Description: Control player movement using navmesh agent.
/// Date created:07/05/2022
/// Last edited: 18/06/2022
/// 
///************************************

using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterController : MonoBehaviour
{
    //Variables
    [SerializeField] Transform cameraTransform;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float speed = 6f; //player movement speed

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GameObject.Find("Main Camera").transform; //get camera reference
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        Movements();
    }

    /// <summary>
    /// Movements for player based on Vector.
    /// </summary>
    void Movements()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //Get horizontal input without smoothing
        float vertical = Input.GetAxisRaw("Vertical");//Get vertical input without smoothing
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //Input data stored into a Vector and normalized

        Vector3 playerPosition = this.transform.position;//store the position before moving

        //returns the deviation in RADIAN from z axis (Atan2 x/z), 
        //exchange to degrees through Rad2Deg 
        //and add in camera angles for camera dependency.

        if (direction != Vector3.zero)
        {
            //movements
            Vector3 destination = transform.position + transform.right * direction.x + transform.forward * direction.z;

            agent.speed = speed;
            agent.destination = destination;
        }
        else
        {
            agent.destination = transform.position;
        }

        this.transform.position = playerPosition; //updating the position after moving
    }
}
