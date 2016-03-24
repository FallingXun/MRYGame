using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using UnityEngine.UI;

namespace MRYGame
{
    public class DialogView : View<DialogView>
    {
        private Image headImage;
        private Text storyText;

        private List<string> textLines = new List<string>();
        private int paragraphNum;
        private int currentParagraphIndex;

        protected override void InitData()
        {
            headImage = transform.Find("HeadImage").GetComponent<Image>();
            storyText = transform.Find("StoryText").GetComponent<Text>();

            EventTriggerListener.Get(this.gameObject).onClick += OnGotoNextStoryTextClick;
            EventTriggerListener.Get(transform.Find("Background").gameObject).onClick += OnGotoNextStoryTextClick;

            // Hack
            instance = this;
            gameObject.SetActive(false);
        }

        public void OnGotoNextStoryTextClick(GameObject go)
        {
            if (currentParagraphIndex == paragraphNum)
            {
                DialogManager.Instance.GotoNextSection();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = currentParagraphIndex * 3;
                    i < textLines.Count && i < currentParagraphIndex * 3 + 3; i++)
                {
                    sb.Append(textLines[i] + "\n");
                }
                SetStoryText(sb.ToString());
                ++currentParagraphIndex;
            }
        }

        public void SetStoryDialog(string iconName, string text)
        {
            currentParagraphIndex = 0;
            textLines.Clear();

            GetAllLines(text);
            paragraphNum = Mathf.CeilToInt(textLines.Count / 3.0f);
            if (paragraphNum <= 1)
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
                    sb.Append(textLines[i] + "\n");
                }
                SetStoryText(sb.ToString());
            }
            ++currentParagraphIndex;
        }

        /// <summary>
        /// ·ÖÎö²¢ÇÐ¸î×Ö·û´®
        /// </summary>
        void GetAllLines(string text)
        {
            Rect rect = storyText.GetComponent<RectTransform>().rect;
            float lineWidth = rect.width;
            StringBuilder sb = new StringBuilder();

            Font font = storyText.font;
            int fontSize = storyText.fontSize;
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
            textLines.AddRange(sb.ToString().Split('\n'));
        }

        void SetRoleIcon(string iconName)
        {
            Sprite sprite = Resources.Load<Sprite>("UI/HeadIcon/" + iconName);
            if (sprite != null)
            {
                headImage.sprite = sprite;
                headImage.SetNativeSize();
            }
            else
            {
                Debug.LogError("The resource of headIcon " + iconName + " load failed");
            }
        }

        void SetStoryText(string text)
        {
            storyText.text = text;
        }
    }
}
