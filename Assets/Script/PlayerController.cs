using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MaglioneFramework
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables and Properties
        public float speed;
        public float jumpForce;
        public bool Grounded = true;
        Rigidbody2D rb;

        public static bool LeftBool;
        public static bool RightBool;
        public static bool ButtonPress;
        public int SecondsChronometer;
        public int MinuteChronometer;
        public int HourChronometer;
        public Text TextChronometer;
        string StringChronometer;
        public int SpeedTime = 1;
        int ChronometerGeneral;
        #endregion

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            StartCoroutine(Chronometer());
        }

        void Update()
        {
            if (LeftBool == true)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else if (RightBool == true)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                RightBool = false;
                LeftBool = false;
            }

            if(ButtonPress == true)
            {
                if (Input.touchCount > 1 && Grounded == true && ButtonPress == true && rb.velocity.y == 0)
                {
                    ButtonPress = false;
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    
                    Grounded = false;
                }
            }
            else
            {
                if (Input.touchCount == 1 && Grounded == true && rb.velocity.y == 0)
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

                    Grounded = false;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Grounded = true;

            if(collision.gameObject.name == "Destroyer")
            {
                PlayerPrefs.SetString("TimeYour", StringChronometer);
                if (PlayerPrefs.GetInt("TimeBestInt",0) < ChronometerGeneral)
                {
                    PlayerPrefs.SetInt("TimeBestInt", ChronometerGeneral);
                    PlayerPrefs.SetString("TimeBest", PlayerPrefs.GetString("TimeYour"));
                }
                SceneManager.LoadScene("GameOver");
            }
        }
        
        public IEnumerator Chronometer()
        {
            while (true)
            {
                yield return new WaitForSeconds(1 / SpeedTime);
                ChronometerGeneral += 1;
                SecondsChronometer += 1;
                if (SecondsChronometer > 59)
                {
                    MinuteChronometer += 1;
                    SecondsChronometer = 0;
                }
                if (MinuteChronometer > 59)
                {
                    HourChronometer += 1;
                    MinuteChronometer = 0;
                }
                TextChronometer.text = HourChronometer.ToString("d2") +":"+MinuteChronometer.ToString("d2") +":" + SecondsChronometer.ToString("d2");
                StringChronometer = HourChronometer.ToString("d2") + ":" + MinuteChronometer.ToString("d2") + ":" + SecondsChronometer.ToString("d2");
                PlayerPrefs.SetString("TimeYour", StringChronometer);
            }
        }
    }
}
