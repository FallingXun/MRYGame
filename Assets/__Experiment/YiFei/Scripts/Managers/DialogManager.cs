using UnityEngine;
using System.Collections;

using LitJson;

namespace MRYGame
{
    public class DialogManager : Manager<DialogManager>
    {
        public System.Action onStoryFinish;
        public System.Action onSectionFinish;

        private JsonData levelStoryConfig;
        private JsonData storyConfig;
        private int currentSection;
        private bool isInitStory = false;

        public override void Init()
        {
            Debug.Log("Initialize DialogManager");

            // 读取关卡剧情脚本
            if (levelStoryConfig == null)
            {
                levelStoryConfig = ConfigFileReader.ReadConfig("StoryConfig");
            }
        }

        public override void Release()
        {
            Debug.Log("Release DialogManager");
        }


        /// <summary>
        /// 判断是否已经初始化对应的故事脚本
        /// </summary>
        public bool IsInitStory()
        {
            return isInitStory;
        }

        public void InitStoryConfig(int levelId)
        {
            storyConfig = levelStoryConfig[levelId];
            currentSection = 0;
            isInitStory = true;
        }

        public void GotoNextSection()
        {
            if (!isInitStory)
                return;

            if (currentSection >= storyConfig.Count)
            {
                if (currentSection == storyConfig.Count)
                {
                    if (onStoryFinish != null)
                        onStoryFinish();
                    DialogView.Instance.Hide();
                    ++currentSection;
                    isInitStory = false;
                }
                return;
            }

            if (currentSection != 0 && onSectionFinish != null)
                onSectionFinish();

            if (storyConfig != null)
            {
                DialogView.Instance.Show();
                string iconName = (string) storyConfig[currentSection]["icon"];
                string msg = (string) storyConfig[currentSection]["msg"];
                DialogView.Instance.SetStoryDialog(iconName, msg);
                ++currentSection;
            }
            else
            {
                Debug.LogError("The story config is load failed");
            }
        }
    }
}
