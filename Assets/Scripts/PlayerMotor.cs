using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{

    NavMeshAgent _navMeshAgent;
    Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_target != null)
        {
            _navMeshAgent.SetDestination(_target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        _navMeshAgent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        _navMeshAgent.stoppingDistance = newTarget._radius * .8f;
        _navMeshAgent.updateRotation = false;
        _target = newTarget._interactionTransform;
    }

    public void StopFollowingTarget()
    {
        _navMeshAgent.stoppingDistance = 0f;
        _navMeshAgent.updateRotation = true;
        _target = null;
    }

    void FaceTarget()
    {
        Vector3 _direction = (_target.position - transform.position).normalized;
        Quaternion _lookRotation = Quaternion.LookRotation(new Vector3(_direction.x, 0f, _direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 5f);
    }
}
