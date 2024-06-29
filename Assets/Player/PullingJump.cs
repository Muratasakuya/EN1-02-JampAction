using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{

    /*==========================================================================*/
    /// <summary>
    /// �ϐ��錾
    /// </summary>

    // ���W�b�g�{�f�B
    private Rigidbody rb;

    // �}�E�X���W
    private Vector3 clickPosition;

    // Unity�ő���\
    [SerializeField]
    // �W�����v��
    private float jumpPower = 10.0f;
    // �W�����v�������ǂ���
    private bool isCanJump;
    // �n�ʂƐڐG���Ă��邩�ǂ����̔���
    private bool isGrounded;

    /*==========================================================================*/

    // Start is called before the first frame update
    void Start()
    {

        // �R���|�[�l���g�̎擾
        rb = gameObject.GetComponent<Rigidbody>();
    }

    /*==========================================================================*/
    /// <summary>
    /// �Փ˔���
    /// </summary>

    /*==========================================================================*/
    // �n�ʂɒ����Ă��邩�ǂ������肷��֐�

    private void CheckGrounded(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 otherNormal = contact.normal;
            float DotUN = Vector3.Dot(Vector3.up, otherNormal);
            float dotDeg = Mathf.Acos(DotUN) * Mathf.Rad2Deg;

            // �n�ʂƐڐG���Ă��邩�𔻒�
            if (dotDeg <= 45.0f)
            {
                isGrounded = true;
                isCanJump = true;
                return;
            }
        }
        isGrounded = false;
        isCanJump = false;
    }

    /*==========================================================================*/

    // �Փ˂������A�ڐG�����A���E�������𔻒肷��e�֐�
    private void OnCollisionEnter(Collision collision)
    {

        CheckGrounded(collision);
    }
    private void OnCollisionStay(Collision collision)
    {

        CheckGrounded(collision);
    }
    private void OnCollisionExit(Collision collision)
    {

        isGrounded = false;
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 otherNormal = contact.normal;
            float DotUN = Vector3.Dot(Vector3.up, otherNormal);
            float dotDeg = Mathf.Acos(DotUN) * Mathf.Rad2Deg;

            // �n�ʂ��痣�ꂽ�ꍇ�ɃW�����v�𖳌���
            if (dotDeg <= 45.0f)
            {
                isGrounded = true;
                break;
            }
        }
        if (!isGrounded)
        {
            isCanJump = false;
        }
    }

    /*==========================================================================*/

    // Update is called once per frame
    void Update()
    {

        // �}�E�X���N���b�N����
        if (Input.GetMouseButtonDown(0))
        {

            clickPosition = Input.mousePosition;
        }

        // �}�E�X���N���b�N�𗣂����Ƃ�
        if (isCanJump && Input.GetMouseButtonUp(0))
        {

            // �N���b�N�������W�Ɨ��������W�̍������擾
            Vector3 dist = clickPosition - Input.mousePosition;

            // �N���b�N�ƃ����[�X���������W�Ȃ疳��
            if (dist.sqrMagnitude == 0.0f) { return; }

            // ������W�������AjumpPower���������킹���l���ړ��ʂƂ���
            rb.velocity = dist.normalized * jumpPower;
        }
    }
}
