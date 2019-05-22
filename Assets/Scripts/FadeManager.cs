/*
フェード付画面遷移クラス


＜使用法＞
このファイルをプロジェクトのアセットフォルダに追加

メニューのFile→Build Settings
Scene in Buildに使用するシーンをドラッグで追加

画面遷移したいタイミングで以下のコードを呼び出す
FadeManager.FadeOut("遷移したいシーン名");


参考サイト　https://onosendai.net/70/
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{

	//フェード用のCanvasとImage
	private static Canvas fadeCanvas;
	private static Image fadeImage;

	//フェード用Imageの透明度
	private static float alpha = 0.0f;

	//フェードインアウトのフラグ
	public static bool isFadeIn = false;
	public static bool isFadeOut = false;

	//フェードしたい時間（単位は秒）
	private static float fadeTime = 0.5f;

	//遷移先のシーン名
	private static string nextScene;

	//フェード用のCanvasとImage生成
	static void Init()
	{
		//フェード用のCanvas生成
		GameObject FadeCanvasObject = new GameObject("CanvasFade");
		fadeCanvas = FadeCanvasObject.AddComponent<Canvas>();
		FadeCanvasObject.AddComponent<GraphicRaycaster>();
		fadeCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
		FadeCanvasObject.AddComponent<FadeManager>();

		//最前面になるよう適当なソートオーダー設定
		fadeCanvas.sortingOrder = 100;

		//フェード用のImage生成
		fadeImage = new GameObject("ImageFade").AddComponent<Image>();
		fadeImage.transform.SetParent(fadeCanvas.transform, false);
		fadeImage.rectTransform.anchoredPosition = Vector3.zero;

		//Imageのサイズは適当に設定してください
		fadeImage.rectTransform.sizeDelta = new Vector2(1920, 1080);
	}

	//フェードイン開始
	public static void FadeIn()
	{
		if (fadeImage == null) Init();
		fadeImage.color = Color.black;
		isFadeIn = true;
	}

	//フェードアウト開始
	public static void FadeOut(string scene)
	{
		if (fadeImage == null) Init();
		nextScene = scene;
		fadeImage.color = Color.clear;
		fadeCanvas.enabled = true;
		isFadeOut = true;
	}

	void Update()
	{
		//フラグ有効なら毎フレームフェードイン/アウト処理
		if (isFadeIn)
		{
			//経過時間から透明度計算
			alpha -= Time.deltaTime / fadeTime;

			//フェードイン終了判定
			if (alpha <= 0.0f)
			{
				isFadeIn = false;
				alpha = 0.0f;
				fadeCanvas.enabled = false;
			}

			//フェード用Imageの透明度設定
			fadeImage.color = new Color(0.0f, 0.0f, 0.0f, alpha);

		}
		else if (isFadeOut)
		{
			//経過時間から透明度計算
			alpha += Time.deltaTime / fadeTime;

			//フェードアウト終了判定
			if (alpha >= 1.0f)
			{
				isFadeOut = false;
				alpha = 1.0f;

				//次のシーンへ遷移
				SceneManager.LoadScene(nextScene);
			}

			//フェード用Imageの透明度設定
			fadeImage.color = new Color(0.0f, 0.0f, 0.0f, alpha);
		}
	}
}