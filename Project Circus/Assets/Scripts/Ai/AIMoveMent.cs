using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;



public class AIMoveMent : MonoBehaviour
{
        public float viewDistance = 5f;
        public float lookTime = 3f;
        private float lookTimer;
        public float rotationSpeed = 90f;
        

        private bool _lookingAtPlayer = false;
        private bool _chasingPlayer = false;
        private Transform _player;
        private NavMeshAgent _agent;

        [SerializeField] private TextMeshProUGUI _watchMeter;

        private void Start()
        {
                _agent = GetComponent<NavMeshAgent>();
                _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        private void Update()
        {
                float distanceToPlayer = Vector3.Distance(transform.position, _player.position);
                _watchMeter.text = "View Meter: " + lookTimer;
                

                if (distanceToPlayer < viewDistance)
                {
                        _lookingAtPlayer = true;
                }
                else
                {
                        _lookingAtPlayer = false;
                        lookTimer = 0f;
                }

                if (_lookingAtPlayer)
                {
                        // Set the agent's destination to the player's position
                        _agent.SetDestination(_player.position);
                        _agent.stoppingDistance = viewDistance;

                        // Calculate the rotation needed to face the player
                        Vector3 directionToPlayer = (_player.position - transform.position).normalized;
                        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

                        // Rotate towards the player over time
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                        lookTimer += Time.deltaTime;
                }

                if (lookTimer >= lookTime)
                {
                        _chasingPlayer = true;
                        lookTimer = 0f;
                }

                if (_chasingPlayer)
                {
                        _agent.SetDestination(_player.position);
                        _agent.stoppingDistance = 0f;
                }
        }
}
