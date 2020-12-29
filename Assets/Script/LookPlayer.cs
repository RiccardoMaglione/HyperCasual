using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaglioneFramework
{
    public class LookPlayer : MonoBehaviour
    {
        public GameObject Player;
    
        void Update()
        {
            transform.position = new Vector3(transform.position.x, Player.transform.position.y + 3, transform.position.z);
        }
    }
}