using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{

    /*==========================================================================*/
    /// <summary>
    /// �ϐ��錾
    /// </summary>

    // Unity�ő���\
    [SerializeField]
    // �摜
    private Image arrowImage;
    // �N���b�N���W
    private Vector3 clickPosition;



    /*==========================================================================*/

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // �}�E�X���N���b�N����
        if (Input.GetMouseButtonDown(0))
        {

            clickPosition = Input.mousePosition;

            arrowImage.gameObject.SetActive(true);
        }

        // �}�E�X���N���b�N�𗣂����Ƃ�
        if (Input.GetMouseButton(0))
        {

            Vector3 dist = clickPosition - Input.mousePosition;

            // �x�N�g���̒������Z�o
            float size = dist.magnitude;
            // �x�N�g������p�x(�ʓx�@)���Z�o
            float angleRad = Mathf.Atan2(dist.y, dist.x);

            // ���̉摜���N���b�N�����ꏊ�ɉ摜���ړ�
            arrowImage.rectTransform.position = clickPosition;
            // ���̉摜���x�N�g������Z�o�����p�x��x���@�ɕϊ�����Z����]
            arrowImage.rectTransform.rotation =
                Quaternion.Euler(0.0f, 0.0f, angleRad * Mathf.Rad2Deg);
            // ���̉摜�̑傫�����h���b�O���������ɍ��킹��
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }
    }
}
