using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMask : MonoBehaviour
{
    //�Z�`�\����
    public struct MaskRect
    {
        public Vector2 rect1;
        public Vector2 rect2;
        public bool trg; //�����蔻��������t���O
    }

    //�ϐ�
    public static MaskRect upRect; //�E���̓����蔻��
    public static MaskRect downRect; //�����̓����蔻��
    public static MaskRect gravityLeftRect; //�n�ʉE�̓����蔻��
    public static MaskRect gravityRightRect; //�n�ʍ��̓����蔻��
    public LayerMask Layer; //���C���[

    // Start is called before the first frame update
    void Start()
    {
        //�����ŒZ�`�̐ݒ�
        upRect.rect1 = new Vector2(0.4f, -0.8f);
        upRect.rect2 = new Vector2(0.5f, -0.9f);
        downRect.rect1 = new Vector2(-0.4f, -0.9f);
        downRect.rect2 = new Vector2(-0.3f, -1f);
        gravityLeftRect.rect1 = new Vector2(-0.5f, -0.9f);
        gravityLeftRect.rect2 = new Vector2(-0.49f, -1f);
        gravityRightRect.rect1 = new Vector2(0.4f, -0.9f);
        gravityRightRect.rect2 = new Vector2(0.5f, -1f);
    }

    // Update is called once per frame
    void Update()
    {
        //�����蔻�菈��
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        upRect.trg = Physics2D.OverlapArea(playerPos + upRect.rect1, playerPos + upRect.rect2, Layer);
        downRect.trg = Physics2D.OverlapArea(playerPos + downRect.rect1, playerPos + downRect.rect2, Layer);
        gravityLeftRect.trg = Physics2D.OverlapArea(playerPos + gravityLeftRect.rect1, playerPos + gravityLeftRect.rect2, Layer);
        gravityRightRect.trg = Physics2D.OverlapArea(playerPos + gravityRightRect.rect1, playerPos + gravityRightRect.rect2, Layer);

        //�Z�`�̕\��
        //Debug.DrawLine(playerPos + upRect.rect1, playerPos + upRect.rect2, Color.green);
        //Debug.DrawLine(playerPos + downRect.rect1, playerPos + downRect.rect2, Color.green);
        //Debug.DrawLine(playerPos + gravityLeftRect.rect1, playerPos + gravityLeftRect.rect2, Color.green);
        //Debug.DrawLine(playerPos + gravityRightRect.rect1, playerPos + gravityRightRect.rect2, Color.green);
    }
}
