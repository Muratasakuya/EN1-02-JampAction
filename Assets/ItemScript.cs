using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{

    /*==========================================================================*/
    /// <summary>
    /// 変数宣言
    /// </summary>


    private Animator animator;

    /*==========================================================================*/

    // Start is called before the first frame update
    void Start()
    {

        // インスタンスの取得
        animator = GetComponent<Animator>();
    }

    /*==========================================================================*/
    /// <summary>
    /// 衝突判定
    /// </summary>

    // 衝突したか、接触中か、離脱したかを判定する各関数
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
    // コールバック関数

    // 消滅するようにする
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
