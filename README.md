# PPL
## Cohesion = Functional
#### Contoh Kode
```csharp
public void ShowGameComplete()
    {
        gameCompletePanel.SetActive(true); 
    }
```
#### Penjelasan 
Functional, adalah modul cohesion yang hanya bekerja untuk satu tujuan spesifik. Tanpa ada melakukan hal hal lain diluar tujuannya

dari contoh func diatas, ShowGameComplete hanya bertugas memanggil SetActive(true) tanpa ada tujuan apa apa lagi yang membuat itu termasuk Cohesion Functional

#### Contoh Kode != Functional
```csharp
public void ShowGameComplete()
    {
        gameCompletePanel.SetActive(true);
        ShowFeedback("Congratulations Puzzle Completed", Color.green);
    }
```
apabila terdapat tambahan seperti ShowFeedback, maka func ini tidak dapat dikategorikan Functional dikarenakan memiliki 2 tujuan


## Coupling = Data
#### Contoh Kode
```csharp
void ShowDebugAnswer()
    {
        if (GameSystem.Instance != null && GameSystem.Instance.phaseManager != null)
        {
            int correctAnswer = GameSystem.Instance.phaseManager.GetExpectedAnswer();
            ShowFeedback($"DEBUG - Correct Answer: {correctAnswer}", Color.yellow);
        }
    }
```

#### Penjelasan 
Data, adlaah module coupling yang berhubungan dengan modul lain namun hanya mengirimkan atribut yang diperlukan tanpa menambah atribut yang lain

dari contoh func diatas, ShowDebugAnswer hanya memanggil antribut correctAnswer tanpa ada tambahan atribut lain dari manapun sehingga membuatnay menjadi coupling jenis data

#### Contoh Kode != Data
```csharp
void ShowDebugAnswer()
    {
        if (GameSystem.Instance != null && GameSystem.Instance.phaseManager != null)
        {
            int correctAnswer = GameSystem.Instance.phaseManager.GetExpectedAnswer();
            int wrongAnswer = GameSystem.Instance.phaseManager.GetCurrentAnswer();
            ShowFeedback($"DEBUG - Correct Answer: {correctAnswer}", Color.yellow);
            ShowFeedback($"DEBUG - Correct Answer: {wrongAnswer}", Color.red);
        }
    }
```
apabila terdapat tambahan antribut seperti wrongAnswer, maka func ini tidak dapat masuk ke kategori Data dikarenakan tidak mengirimkan atau menerima hanya 1 atrribut
