using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID
{
    public class EffectTrigger : MonoBehaviour
    {
        public AreaOfEffect m_Effect;
        //public RectangleEffect rectangleEffect;
        //public CircleEffect circleEffect;

        private void Start()
        {
            Debug.Log(m_Effect.CalculateArea().ToString());
        }

        private void OnTriggerEnter(Collider other)
        {
            //����Ʈ�� ��Ʈ����
            PlayEffect(other);
        }

        void PlayEffect(Collider other)
        {
            if (other.tag == "Player")
            {
                //rectangleEffect.PlayEffect();
                //circleEffect.PlayEffect();

                m_Effect.PlayEffect();
            }
        }
    }
}