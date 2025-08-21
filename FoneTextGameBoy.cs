using UnityEngine;
using TMPro;
using System.Globalization;
using System.Collections;

public class FoneTextGameBoy : MonoBehaviour
{

    public TextMeshProUGUI uiText; // ������� ��� UI Text �����
    // public TMP_Text uiText; // ����������� ��� ��� TextMeshPro
    public string[] texts; // ������ ������� ��� �����������
    public float typingSpeed = 0.05f; // �������� ������
    public float delayBetweenTexts = 2f; // �������� ����� ��������

    private void Start()
    {
        StartCoroutine(TypeTexts());
    }

    private IEnumerator TypeTexts()
    {
        while (true) // ����������� ���� ��� ���������� ������
        {
            foreach (string text in texts)
            {
                yield return StartCoroutine(TypeText(text));
                yield return new WaitForSeconds(delayBetweenTexts);
            }
        }
    }

    private IEnumerator TypeText(string text)
    {
        uiText.text = ""; // ������� ����� ����� ������� ������

        foreach (char letter in text)
        {
            uiText.text += letter; // ��������� ����� � ������
            yield return new WaitForSeconds(typingSpeed); // ���� ����� ����������� ��������� �����
        }
    }
}
