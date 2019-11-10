using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    private NavMeshAgent[] _navMeshAgents;
    private Transform _targetTransform;


    private void Start()
    {
        _navMeshAgents = FindObjectsOfType<NavMeshAgent>();
        _targetTransform = transform;
    }

    private void UpdateTarget(Vector3 pos)
    {
        transform.position = pos;
        for (int i = 0; i < _navMeshAgents.Length; i++)
        {
            _navMeshAgents[i].SetDestination(pos);
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 newPos = hit.point;
                UpdateTarget(newPos);
            }
        }
    }
}
