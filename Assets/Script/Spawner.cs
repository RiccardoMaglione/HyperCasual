using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaglioneFramework
{
    public class Spawner : MonoBehaviour
    {
        Vector3 InitialPosition;
        public GameObject Wall;
        public int Ypos = 0;
        public int YWallpos = 0;
        public int ID = 1;

        public int PosMinWall = -10;
        public int PosMaxWall = 10;
        void Start()
        {
            StartCoroutine(InstPlat());
            StartCoroutine(InstPlatWall());
        }
    
        public IEnumerator InstPlat()
        {
            while (true)
            {
                Ypos += 3;

                InitialPosition = new Vector3(Random.Range(-1.75f, 1.75f), Ypos, transform.position.z);
                GameObject PlatformGo = ObjectPool.SharedInstance.GetPooledObjectWithInfo(InitialPosition, transform.rotation);
                if (PlatformGo != null)
                {
                    PlatformGo.SetActive(true);
                }
                yield return new WaitForSeconds(0.5f);
                ID++;
            }
        }
    
        public IEnumerator InstPlatWall()
        {
            while (true)
            {
                YWallpos += 1;
                GameObject Wall1Go = Instantiate(Wall, new Vector3(PosMaxWall, YWallpos, transform.position.z), Quaternion.identity);
                GameObject Wall2Go = Instantiate(Wall, new Vector3(PosMinWall, YWallpos, transform.position.z), Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                ID++;
            }
        }
    
}
}