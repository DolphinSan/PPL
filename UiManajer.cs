using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI phaseText;
    public TextMeshProUGUI questionText;
    public TMP_InputField answerInput;
    public Button submitButton;
    public TextMeshProUGUI feedbackText;
    public GameObject gameCompletePanel;
    
    [Header("Debug Settings")]
    public bool showDebugAnswer = true; // Toggle this in inspector
    
    void Start()
    {
        submitButton.onClick.AddListener(OnSubmitAnswer);
    }
    
    public void UpdateUI()
    {
        phaseText.text = "Phase " + GameSystem.Instance.currentPhase;
        
        // Show debug answer when UI updates
        if (showDebugAnswer)
        {
            ShowDebugAnswer();
        }
    }
    
    public void UpdateQuestionText(string question)
    {
        questionText.text = question;
        
        // Show debug answer when question updates
        if (showDebugAnswer)
        {
            ShowDebugAnswer();
        }
    }
    
    void ShowDebugAnswer()
    {
        if (GameSystem.Instance != null && GameSystem.Instance.phaseManager != null)
        {
            int correctAnswer = GameSystem.Instance.phaseManager.GetExpectedAnswer();
            ShowFeedback($"DEBUG - Correct Answer: {correctAnswer}", Color.yellow);
        }
    }
    
    void OnSubmitAnswer()
    {
        if (int.TryParse(answerInput.text, out int answer))
        {
            GameSystem.Instance.SubmitAnswer(answer);
            answerInput.text = "";
        }
        else
        {
            ShowFeedback("Please enter a valid number", Color.red);
        }
    }
    
    public void ShowIncorrectAnswer()
    {
        if (showDebugAnswer)
        {
            int correctAnswer = GameSystem.Instance.phaseManager.GetExpectedAnswer();
            ShowFeedback($"Incorrect! Correct was: {correctAnswer}. Resetting to Phase 1", Color.red);
        }
        else
        {
            ShowFeedback("Incorrect! Resetting to Phase 1", Color.red);
        }
    }

    public void ShowGameComplete()
    {
        gameCompletePanel.SetActive(true);
    }
    
    void ShowFeedback(string message, Color color)
    {
        feedbackText.text = message;
        feedbackText.color = color;
        
        // Clear feedback after longer time for debug messages
        CancelInvoke("ClearFeedback");
        if (color == Color.yellow) // Debug messages
        {
            Invoke("ClearFeedback", 5f); // Show debug longer
        }
        else
        {
            Invoke("ClearFeedback", 3f); // Normal feedback time
        }
    }
    
    void ClearFeedback()
    {
        feedbackText.text = "";
    }
}