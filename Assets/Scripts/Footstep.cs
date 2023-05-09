using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSR {
    public class Footstep : MonoBehaviour {
        public FSR_Player fsr;
        float elapsedTime;
        float timeLimit = 0.5f;

        // Start is called before the first frame update
        void Start() {
        }

        // Update is called once per frame
        void Update() {
            elapsedTime += Time.deltaTime;

            // Handle input from WASD keys
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
                if (elapsedTime >= timeLimit) {
                    elapsedTime = 0;
                    fsr.step();
                }
            }

            // Handle input from Xbox Wireless Controller joystick
            float joystickHorizontalInput = Input.GetAxis("Horizontal");
            float joystickVerticalInput = Input.GetAxis("Vertical");
            if (Mathf.Abs(joystickHorizontalInput) > 0 || Mathf.Abs(joystickVerticalInput) > 0) {
                if (elapsedTime >= timeLimit) {
                    elapsedTime = 0;
                    fsr.step();
                }
            }
        }
    }
}