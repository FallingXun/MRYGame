using UnityEngine;
using System.Collections;

namespace MRYGame
{
    public class Skill : MonoBehaviour
    {
        protected Actor sourceActor;
        protected Actor targetActor;

        /// <summary>
        /// 技能冷却时间
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
        /// 触发技能 
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
        /// 技能前摇
        /// </summary>
        protected virtual void SkillBefore() { }

        /// <summary>
        /// 技能结算
        /// </summary>
        protected virtual void SkillRelease() { }

        /// <summary>
        /// 技能后摇
        /// </summary>
        protected virtual void SkillAfter() { }
    }
}
