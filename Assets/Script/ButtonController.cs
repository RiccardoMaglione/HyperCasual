using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaglioneFramework
{
    public class ButtonController : MonoBehaviour
    {
        public void LeftVelocity()
        {
            PlayerController.LeftBool = true;
            PlayerController.RightBool = false;
            PlayerController.ButtonPress = true;
        }

        public void RightVelocity()
        {
            PlayerController.RightBool = true;
            PlayerController.LeftBool = false;
            PlayerController.ButtonPress = true;
        }

        public void NullVelocity()
        {
            PlayerController.RightBool = false;
            PlayerController.LeftBool = false;
            StartCoroutine(TimerPress());
        }

        public IEnumerator TimerPress()
        {
            yield return new WaitForSeconds(0.1f);
            PlayerController.ButtonPress = false;
        }
    }
}
