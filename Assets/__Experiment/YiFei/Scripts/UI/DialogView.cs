using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using UnityEngine.UI;

public class DialogView : View<DialogView>
{
    private Image mHeadImage;
    private Text mStoryText;

    private List<string> mLines = new List<string>();
    private int mParagraphNum;
    private int mCurrentParagraphIndex;

    protected override void InitData()
    {
        mHeadImage = transform.Find("HeadImage").GetComponent<Image>();
        mStoryText = transform.Find("StoryText").GetComponent<Text>();

        EventTriggerListener.Get(this.gameObject).onClick += OnGotoNextStoryTextClick;
        EventTriggerListener.Get(transform.Find("Background").gameObject).onClick += OnGotoNextStoryTextClick;

        // Hack
        mInstance = this;
        gameObject.SetActive(false);
    }

    public void OnGotoNextStoryTextClick(GameObject go)
    {
        if (mCurrentParagraphIndex == mParagraphNum)
        {
            DialogManager.Instance.GotoNextSection();
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            for (int i = mCurrentParagraphIndex * 3;
                i < mLines.Count && i < mCurrentParagraphIndex * 3 + 3; i++)
            {
                sb.Append(mLines[i] + "\n");
            }
            SetStoryText(sb.ToString());
            ++mCurrentParagraphIndex;
        }
    }

    public void SetStoryDialog(string iconName, string text)
    {
        mCurrentParagraphIndex = 0;
        mLines.Clear();

        GetAllLines(text);
        mParagraphNum = Mathf.CeilToInt(mLines.Count / 3.0f);
        if (mParagraphNum <= 1)
        {
            SetRoleIcon(iconName);
            SetStoryText(text);
        }
        else
        {
            SetRoleIcon(iconName);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                sb.Append(mLines[i] + "\n");
            }
            SetStoryText(sb.ToString());
        }
        ++mCurrentParagraphIndex;
    }

    /// <summary>
    /// ·ÖÎö²¢ÇÐ¸î×Ö·û´®
    /// </summary>
    void GetAllLines(string text)
    {
        Rect rect = mStoryText.GetComponent<RectTransform>().rect;
        float lineWidth = rect.width;
        StringBuilder sb = new StringBuilder();

        Font font = mStoryText.font;
        int fontSize = mStoryText.fontSize;
        font.RequestCharactersInTexture(text, fontSize, FontStyle.Normal);
        CharacterInfo characterInfo;
        for (int i = 0; i < text.Length; i++)
        {
            font.GetCharacterInfo(text[i], out characterInfo, fontSize);
            if (lineWidth - characterInfo.advance <= 0)
            {
                sb.Append('\n');
                lineWidth = rect.width;
            }
            sb.Append(text[i]);
            lineWidth -= characterInfo.advance;
        }
        mLines.AddRange(sb.ToString().Split('\n'));
    }

    void SetRoleIcon(string iconName)
    {
        Sprite sprite = Resources.Load<Sprite>("UI/HeadIcon/" + iconName);
        if (sprite != null)
        {
            mHeadImage.sprite = sprite;
            mHeadImage.SetNativeSize();
        }
        else
        {
            Debug.LogError("The resource of headIcon " + iconName + " load failed");
        }
    }

    void SetStoryText(string text)
    {
        mStoryText.text = text;
    }
}
