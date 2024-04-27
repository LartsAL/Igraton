using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessController : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    public float darkness = 0;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetDarknessLevel(darkness);
    }

    // ���������� ������� ���������� (0 - ��������� ���������, 1 - ��������� �����������)
    public void SetDarknessLevel(float darknessLevel)
    {
        Color color = spriteRenderer.color;
        color.a = Mathf.Clamp01(darknessLevel); // ���������, ��� �������� � ��������� �� 0 �� 1
        spriteRenderer.color = color;
    }

    // Update is called once per frame
    void Update()
    {
       
    }


}
