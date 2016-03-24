using UnityEngine;
using System.Collections;

namespace MRYGame
{
    public class Buff : MonoBehaviour
    {
        /// <summary>
        /// Buff唯一码
        /// </summary>
        public int buffId;

        /// <summary>
        /// Buff名称
        /// </summary>
        public string buffName;

        /// <summary>
        /// Actor添加Buff时刻
        /// </summary>
        public virtual void BuffOccur(Actor actor) { }

        /// <summary>
        /// 定时触发
        /// </summary>
        public virtual void BuffOnTick(Actor actor) { }

        /// <summary>
        /// Actor移除Buff时刻
        /// </summary>
        public virtual void BuffRemoved(Actor actor) { }

        /// <summary>
        /// Actor受到攻击时刻
        /// </summary>
        public virtual void BuffBeHurt(Actor actor) { }

        /// <summary>
        /// Actor攻击时刻
        /// </summary>
        public virtual void BuffBeHit(Actor actor) { }

        /// <summary>
        /// Actor死亡前时刻
        /// </summary>
        public virtual void BuffBeforeKilled(Actor actor) { }

        /// <summary>
        /// Actor死亡后时刻
        /// </summary>
        public virtual void BuffAfterKilled(Actor actor) { }
    }
}
