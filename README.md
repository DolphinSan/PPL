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


