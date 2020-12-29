using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MaglioneFramework
{
    public class UpdateScoreTime : MonoBehaviour
    {
        public Text YourTime;
        public Text BestTime;
    
        // Start is called before the first frame update
        void Start()
        {
            YourTime.text = PlayerPrefs.GetString("TimeYour");
            BestTime.text = PlayerPrefs.GetString("TimeBest");
        }
    }
}
