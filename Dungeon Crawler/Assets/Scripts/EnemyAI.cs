using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;


public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    NavMeshAgent agent;
    FOV fov;
    Animator animator;
    [SerializeField] bool InAttackrange = false;
    float Distance;
    void Start()
    {
       Player = GameObject.FindWithTag("Player");
       agent = this.gameObject.GetComponent<NavMeshAgent>();
       fov = this.gameObject.GetComponent<FOV>();
       animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(fov.Can_See_Player)
        {
            agent.SetDestination(Player.transform.position);
            animator.SetBool("Running",true);
        }
        else if(fov.Can_See_Player && InAttackrange == true)
        { 
            animator.SetBool("Running",false);
            animator.SetTrigger("Attack");
        }
        else
        {
             animator.SetBool("Running",false);
        }
        
    }
        void OnTriggerEnter(Collider collider)
        {
           if(collider.gameObject.tag == "Player")
           {
                InAttackrange = true;
           }
           else
           {
             InAttackrange = false;
           }
        }
        


}
