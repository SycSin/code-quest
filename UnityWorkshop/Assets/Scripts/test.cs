using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class test : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}