using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{

    /*==========================================================================*/
    /// <summary>
    /// 変数宣言
    /// </summary>

    // Unityで操作可能
    [SerializeField]
    // 画像
    private Image arrowImage;
    // クリック座標
    private Vector3 clickPosition;

    /*==========================================================================*/

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // マウス左クリック入力
        if (Input.GetMouseButtonDown(0))
        {

            clickPosition = Input.mousePosition;
        }

        // マウス左クリックを離したとき
        if (Input.GetMouseButton(0))
        {

            Vector3 dist = clickPosition - Input.mousePosition;

            // ベクトルの長さを算出
            float size = dist.magnitude;
            // ベクトルから角度(弧度法)を算出
            float angleRad = Mathf.Atan2(dist.y, dist.x);

            // 矢印の画像をクリックした場所に画像を移動
            arrowImage.rectTransform.position = clickPosition;
            // 矢印の画像をベクトルから算出した角度を度数法に変換してZ軸回転
            arrowImage.rectTransform.rotation =
                Quaternion.Euler(0.0f, 0.0f, angleRad * Mathf.Rad2Deg);
            // 矢印の画像の大きさをドラッグした距離に合わせる
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);

            Debug.Log(dist);
        }
    }
}
