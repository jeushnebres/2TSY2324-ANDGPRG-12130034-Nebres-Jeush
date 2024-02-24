using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MonsterType
{
    Ground,
    Flying
}

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform goal;
    [SerializeField] NavMeshAgent agent;

    [SerializeField] MonsterType type;
    public MonsterType MonsterType { get { return type; } }

    // Start is called before the first frame update
    void Awake()
    {
        this.agent = this.GetComponent<NavMeshAgent>();
        
    }

    public void SetTarget(Transform target)
    {
        this.goal = target;
		this.agent.SetDestination(this.goal.position);
	}

	public void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.name.Contains("CrystalCore"))
        {
            SpawnerController.Instance.RemoveEnemy(this.gameObject);
            Destroy(this.gameObject);
        }
	}
}
