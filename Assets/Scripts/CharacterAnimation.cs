using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimation : MonoBehaviour
{
    const float _locamotionAnimationSmoothTime = .1f;

    Animator _animator;
    NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float _speedPercent = _navMeshAgent.velocity.magnitude / _navMeshAgent.speed;
        _animator.SetFloat("speedPercent", _speedPercent, _locamotionAnimationSmoothTime, Time.deltaTime);
    }
}
