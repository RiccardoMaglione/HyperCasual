using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaglioneFramework
{
    public class DestroyObject : MonoBehaviour
    {
        public int Speed = 1;

        void Update()
        {
            transform.localScale = new Vector3(30, transform.localScale.y + 1 * Speed * Time.deltaTime, 5);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {   
            if(collision.gameObject.name == "Wall(Clone)")
            {
                Destroy(collision.gameObject);
            }
            else
            {
                ObjectPool.SharedInstance.GeneralResetPooledObject(collision.gameObject, collision.transform.position, Quaternion.identity);
            }

        }
    }
}