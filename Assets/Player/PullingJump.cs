using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{

    /*==========================================================================*/
    /// <summary>
    /// 変数宣言
    /// </summary>

    // リジットボディ
    private Rigidbody rb;

    // マウス座標
    private Vector3 clickPosition;

    // Unityで操作可能
    [SerializeField]
    // ジャンプ力
    private float jumpPower = 10.0f;
    // ジャンプしたかどうか
    private bool isCanJump;
    // 地面と接触しているかどうかの判定
    private bool isGrounded;

    /*==========================================================================*/

    // Start is called before the first frame update
    void Start()
    {

        // コンポーネントの取得
        rb = gameObject.GetComponent<Rigidbody>();
    }

    /*==========================================================================*/
    /// <summary>
    /// 衝突判定
    /// </summary>

    /*==========================================================================*/
    // 地面に着いているかどうか判定する関数

    private void CheckGrounded(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 otherNormal = contact.normal;
            float DotUN = Vector3.Dot(Vector3.up, otherNormal);
            float dotDeg = Mathf.Acos(DotUN) * Mathf.Rad2Deg;

            // 地面と接触しているかを判定
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

    // 衝突したか、接触中か、離脱したかを判定する各関数
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

            // 地面から離れた場合にジャンプを無効化
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

        // マウス左クリック入力
        if (Input.GetMouseButtonDown(0))
        {

            clickPosition = Input.mousePosition;
        }

        // マウス左クリックを離したとき
        if (isCanJump && Input.GetMouseButtonUp(0))
        {

            // クリックした座標と離した座標の差分を取得
            Vector3 dist = clickPosition - Input.mousePosition;

            // クリックとリリースが同じ座標なら無視
            if (dist.sqrMagnitude == 0.0f) { return; }

            // 差分を標準化し、jumpPowerをかけ合わせた値を移動量とする
            rb.velocity = dist.normalized * jumpPower;
        }
    }
}
