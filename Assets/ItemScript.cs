using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{

    /*==========================================================================*/
    /// <summary>
    /// �ϐ��錾
    /// </summary>


    private Animator animator;

    /*==========================================================================*/

    // Start is called before the first frame update
    void Start()
    {

        // �C���X�^���X�̎擾
        animator = GetComponent<Animator>();
    }

    /*==========================================================================*/
    /// <summary>
    /// �Փ˔���
    /// </summary>

    // �Փ˂������A�ڐG�����A���E�������𔻒肷��e�֐�
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Enter");

        animator.SetTrigger("Get");
    }
    private void OnTriggerStay(Collider other)
    {

        Debug.Log("Stay");
    }
    private void OnTriggerExit(Collider other)
    {

        Debug.Log("Exit");
    }

    /*==========================================================================*/
    // �R�[���o�b�N�֐�

    // ���ł���悤�ɂ���
    private void DestroySelf()
    {

        Destroy(gameObject);
    }

    /*==========================================================================*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
