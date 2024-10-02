using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID
{
    public abstract class AreaOfEffect : MonoBehaviour
    {
        public float TotalArea => CalculateArea();
        public abstract float CalculateArea();

        public void PlayEffect()
        {
            //...
        }

        public void PlayParticleEffect()
        {

        }
    }
}