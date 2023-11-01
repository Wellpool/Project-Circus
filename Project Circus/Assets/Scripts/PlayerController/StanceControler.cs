using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StanceControler : MonoBehaviour
{
        private GameObject _stand;
        private GameObject _crouch;
        private GameObject _prone;

        public int stance = 1;

        private void Start()
        {
                _stand = GameObject.Find("Stand");
                _crouch = GameObject.Find("Crouch");
                _prone = GameObject.Find("Prone");
                
                _crouch.SetActive(false);
                _prone.SetActive(false);
        }

        private void Update()
        {
                //Controls to change stance
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                        stance++;
                }

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                        stance--;
                }
                
                //Limiting stance number
                if (stance > 3)
                {
                        stance = 3;
                }

                if (stance < 0)
                {
                        stance = 0;
                }
                
                //Logic to change stance
                Stance();
        }

        private void Stance()
        {
                switch (stance)
                {
                        case 1:
                                _stand.SetActive(true);
                                _crouch.SetActive(false);
                                _prone.SetActive(false);
                                break;
                        case 2:
                                _stand.SetActive(false);
                                _crouch.SetActive(true);
                                _prone.SetActive(false);
                                break;
                        case 3:
                                _stand.SetActive(false);
                                _crouch.SetActive(false);
                                _prone.SetActive(true);
                                break;
                }
        }
}
