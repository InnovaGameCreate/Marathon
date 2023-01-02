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
    }

    //�ϐ�
    public LayerMask Layer1; //���C���[
    public LayerMask Layer2; //���C���[
    public LayerMask Layer3; //���C���[
    public static MaskRect leftLeg; //��
    public static MaskRect rightLeg;
    public static MaskRect pad;
    public static int playerMove = 0;

    // Start is called before the first frame update
    void Start()
    {
        //�Z�`�̐ݒ�
        leftLeg.rect1 = new Vector2(-0.5f, -0.99f);
        leftLeg.rect2 = new Vector2(-0.49f, -1f);
        rightLeg.rect1 = new Vector2(0.49f, -0.99f);
        rightLeg.rect2 = new Vector2(0.5f, -1f);
        pad.rect1 = new Vector2(-0.55f, -1f);
        pad.rect2 = new Vector2(0.55f, -1.01f);
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[���W
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);

        //�Z�`�Ə��̓����蔻��
        if (Physics2D.OverlapArea(playerPos + pad.rect1, playerPos + pad.rect2, Layer2)
            && Physics2D.OverlapArea(playerPos + rightLeg.rect1, playerPos + rightLeg.rect2, Layer2)) playerMove = 2;
        else if (Physics2D.OverlapArea(playerPos + pad.rect1, playerPos + pad.rect2, Layer3)
            && !Physics2D.OverlapArea(playerPos + leftLeg.rect1, playerPos + leftLeg.rect2, Layer3)) playerMove = 3;
        else if (Physics2D.OverlapArea(playerPos + pad.rect1, playerPos + pad.rect2, Layer1)
                || Physics2D.OverlapArea(playerPos + pad.rect1, playerPos + pad.rect2, Layer2)
                || Physics2D.OverlapArea(playerPos + pad.rect1, playerPos + pad.rect2, Layer3)) playerMove = 1;
        else playerMove = 0;

        if (playerMove == 3 && Physics2D.OverlapArea(playerPos + rightLeg.rect1, playerPos + rightLeg.rect2, Layer1)) playerMove = 2;
    }
}
