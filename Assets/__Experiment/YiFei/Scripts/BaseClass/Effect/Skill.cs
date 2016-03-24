using UnityEngine;
using System.Collections;

namespace MRYGame
{
    public class Skill : MonoBehaviour
    {
        protected Actor sourceActor;
        protected Actor targetActor;

        /// <summary>
        /// ������ȴʱ��
        /// </summary>
        private float cdTime = 2f;
        private float cdTimeCount = 0f;
        private bool isCooldown = false;

        void Update()
        {
            if (isCooldown)
            {
                cdTimeCount += Time.deltaTime;
                if (cdTimeCount >= cdTime)
                {
                    isCooldown = false;
                    cdTimeCount = 0f;
                }
            }
        }

        /// <summary>
        /// �������� 
        /// </summary>
        public void Fire(Actor source, Actor target)
        {
            sourceActor = source;
            targetActor = target;

            if (!isCooldown)
            {
                SkillBefore();
                SkillRelease();
                SkillAfter();

                isCooldown = true;
            }
        }

        /// <summary>
        /// ����ǰҡ
        /// </summary>
        protected virtual void SkillBefore() { }

        /// <summary>
        /// ���ܽ���
        /// </summary>
        protected virtual void SkillRelease() { }

        /// <summary>
        /// ���ܺ�ҡ
        /// </summary>
        protected virtual void SkillAfter() { }
    }
}
