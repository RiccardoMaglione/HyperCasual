using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        #endregion

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
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
                if (Input.touchCount > 1 && Grounded == true)
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    
                    Grounded = false;
                    PlayerController.ButtonPress = false;
                }
            }
            else
            {
                if (Input.touchCount == 1 && Grounded == true)
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

                    Grounded = false;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Grounded = true;
        }
    }
}
