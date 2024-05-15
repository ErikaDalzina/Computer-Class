using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FOV : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerRef;
    NavMeshAgent agent;
    [Range(0,360)] //permite asignar un rango para editar
    public float View_Angle;
    public float Radius;
    [SerializeField] LayerMask Target_Mask;
    [SerializeField] LayerMask Obstruction_Mask;
    public bool Can_See_Player;


    void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    IEnumerator FOVRoutine()
    {
        float delay = .2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while(true)
        {
            yield return wait;
            FOV_Check();
        }
    }
    //functions
        void FOV_Check()
        {
            Collider[] rangeCheck = Physics.OverlapSphere(transform.position,Radius,Target_Mask);
        // ^^checks for any collider,cast a sphere to detect collisions withe the following parameters(Game object position,radius of sphere, Layer mask)^^

            if(rangeCheck.Length != 0) //if something was recorded in range
            {
                Transform target = rangeCheck[0].transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                if(Vector3.Angle(transform.forward,directionToTarget) < View_Angle /2) //creates angle between the foward direction and the target position. then checks if that angle is smaller that the allowed angle /2
                {
                    float DistanceToTarget = Vector3.Distance(transform.position, target.position);// Distance to target 
                    if(!Physics.Raycast(transform.forward, directionToTarget,DistanceToTarget,Obstruction_Mask))
                    {
                        Can_See_Player =true;
                    }
                    else{Can_See_Player =false;}
                }
                else{ Can_See_Player = false;}
            }
            else{ Can_See_Player = false;}
        }
}
