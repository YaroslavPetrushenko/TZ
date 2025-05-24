using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlinkTextAndButton : MonoBehaviour
{
    public TMP_Text uiText;
    public Button button;
    public float speed = 2f;
    private float cycleDuration = 9f;

    private Image buttonImage;

    void Start()
    {
        if (button != null)
            buttonImage = button.GetComponent<Image>();
    }

    void Update()
    {
        float time = Time.time % cycleDuration;
        float phase = time / cycleDuration;

        float value = (Mathf.Sin(Time.time * speed) + 1f) / 2f;

        // Для кнопки используем сдвиг по времени
        float buttonTime = (Time.time + cycleDuration / 2f) % cycleDuration;
        float buttonPhase = buttonTime / cycleDuration;
        float buttonValue = (Mathf.Sin((Time.time + cycleDuration / 2f) * speed) + 1f) / 2f;

        // Цвет текста
        Color textColor = uiText.color;
        if (phase < 1f / 3f)
            textColor = new Color(value, 0f, 0f, 1f);
        else if (phase < 2f / 3f)
            textColor = new Color(0f, value, 0f, 1f);
        else
            textColor = new Color(0f, 0f, value, 1f);
        uiText.color = textColor;

        // Цвет кнопки (сдвиг по фазе)
        Color btnColor;
        if (buttonPhase < 1f / 3f)
            btnColor = new Color(buttonValue, 0f, 0f, 1f);
        else if (buttonPhase < 2f / 3f)
            btnColor = new Color(0f, buttonValue, 0f, 1f);
        else
            btnColor = new Color(0f, 0f, buttonValue, 1f);

        if (buttonImage != null)
            buttonImage.color = btnColor;
    }


}