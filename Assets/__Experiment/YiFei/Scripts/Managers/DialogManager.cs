using UnityEngine;
using System.Collections;

using LitJson;

public class DialogManager : Manager<DialogManager>
{
    public System.Action onStoryFinish;
    public System.Action onSectionFinish;

    private JsonData mLevelStoryConfig;
    private JsonData mStoryConfig;
    private int mCurrentSection;
    private bool mIsInitStory = false;

    public override void Init()
    {
        Debug.Log("Initialize DialogManager");

        // ��ȡ�ؿ�����ű�
        if (mLevelStoryConfig == null)
        {
            mLevelStoryConfig = ConfigFileReader.ReadConfig("StoryConfig");
        }
    }

    public override void Release()
    {
        Debug.Log("Release DialogManager");
    }


    /// <summary>
    /// �ж��Ƿ��Ѿ���ʼ����Ӧ�Ĺ��½ű�
    /// </summary>
    public bool IsInitStory()
    {
        return mIsInitStory;
    }

    public void InitStoryConfig(int levelId)
    {
        mStoryConfig = mLevelStoryConfig[levelId];
        mCurrentSection = 0;
        mIsInitStory = true;
    }

    public void GotoNextSection()
    {
        if (!mIsInitStory)
            return;

        if (mCurrentSection >= mStoryConfig.Count)
        {
            if (mCurrentSection == mStoryConfig.Count)
            {
                if (onStoryFinish != null)
                    onStoryFinish();
                DialogView.Instance.Hide();
                ++mCurrentSection;
                mIsInitStory = false;
            }
            return;
        }

        if (mCurrentSection != 0 && onSectionFinish != null)
            onSectionFinish();

        if (mStoryConfig != null)
        {
            DialogView.Instance.Show();
            string iconName = (string) mStoryConfig[mCurrentSection]["icon"];
            string msg = (string) mStoryConfig[mCurrentSection]["msg"];
            DialogView.Instance.SetStoryDialog(iconName, msg);
            ++mCurrentSection;
        }
        else
        {
            Debug.LogError("The story config is load failed");
        }
    }
}
