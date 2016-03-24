using UnityEngine;
using System.Collections;

namespace MRYGame
{
    public class Buff : MonoBehaviour
    {
        /// <summary>
        /// BuffΨһ��
        /// </summary>
        public int buffId;

        /// <summary>
        /// Buff����
        /// </summary>
        public string buffName;

        /// <summary>
        /// Actor���Buffʱ��
        /// </summary>
        public virtual void BuffOccur(Actor actor) { }

        /// <summary>
        /// ��ʱ����
        /// </summary>
        public virtual void BuffOnTick(Actor actor) { }

        /// <summary>
        /// Actor�Ƴ�Buffʱ��
        /// </summary>
        public virtual void BuffRemoved(Actor actor) { }

        /// <summary>
        /// Actor�ܵ�����ʱ��
        /// </summary>
        public virtual void BuffBeHurt(Actor actor) { }

        /// <summary>
        /// Actor����ʱ��
        /// </summary>
        public virtual void BuffBeHit(Actor actor) { }

        /// <summary>
        /// Actor����ǰʱ��
        /// </summary>
        public virtual void BuffBeforeKilled(Actor actor) { }

        /// <summary>
        /// Actor������ʱ��
        /// </summary>
        public virtual void BuffAfterKilled(Actor actor) { }
    }
}
