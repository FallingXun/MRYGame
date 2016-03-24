using UnityEngine;
using System.Collections;

namespace MRYGame
{
    public class View<T> : Singleton<T> where T : View<T>
    {
        protected bool isShowed = true;

        void Awake()
        {
            InitData();
        }

        protected virtual void InitData() { }

        public virtual void Show()
        {
            gameObject.SetActive(true);
            isShowed = false;
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
