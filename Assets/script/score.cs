    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class score : MonoBehaviour
    {
        public Text scoreText;
        public static int scoreValue = 0;

        void Start()
        {
        }

        void Update()
        {
            scoreText.text = "SCORE: "+ scoreValue;
        }
    }
