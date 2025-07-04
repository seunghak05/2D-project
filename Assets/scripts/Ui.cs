using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI tapToStartText;
    public CanvasGroup startCanvasGroup;

    private bool gameStarted = false;

    void Start()
    {
        // 제목 텍스트 페이드 인
        titleText.DOFade(1f, 1f).From(0f).SetEase(Ease.OutQuad);

        // "Tap to Start" 텍스트 깜빡이기
        DOTween.To(() => tapToStartText.alpha, x => tapToStartText.alpha = x, 0f, 0.8f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            gameStarted = true;

            // UI 페이드 아웃
            startCanvasGroup.DOFade(0f, 0.5f).OnComplete(() =>
            {
                startCanvasGroup.gameObject.SetActive(false);
                // 여기에 게임 시작 로직 또는 씬 전환 추가
                // SceneManager.LoadScene("MainScene"); 또는 GameManager.StartGame();
            });
        }
    }
}
