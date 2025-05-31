# Aplikacja Przetwarzania Zamówień z Testami Jednostkowymi

## Opis

Prosta aplikacja w języku C# demonstrująca współpracę dwóch modułów: `OrderService` (obsługującego zamówienia) oraz `PaymentProcessor` (obsługującego płatności). Projekt skupia się na zastosowaniu wzorca wstrzykiwania zależności (Dependency Injection) oraz pisaniu testów jednostkowych z wykorzystaniem mocków (NUnit & Moq) do weryfikacji interakcji między komponentami.

Głównym celem jest pokazanie, jak testować logikę biznesową w izolacji od jej zależności.

## Główne Funkcjonalności

* **Moduł `OrderService`**: Odpowiada za logikę składania zamówień.
* **Interfejs `IPaymentProcessor`**: Definiuje kontrakt dla systemu płatności.
* **Moduł `PaymentProcessor`**: Przykładowa implementacja systemu płatności.
* **Wstrzykiwanie zależności**: `OrderService` otrzymuje zależność `IPaymentProcessor` poprzez konstruktor.
* **Testy Jednostkowe**:
    * Weryfikacja, czy `OrderService` poprawnie wywołuje metodę `ProcessPayment`.
    * Sprawdzenie, czy `ProcessPayment` jest wywoływana z oczekiwanymi parametrami (kwota, waluta).
    * Testowanie logiki `OrderService` w oparciu o symulowane (mockowane) wyniki operacji płatniczych.

## Technologie

* **Język**: C#
* **Platforma**: .NET (np. .NET 6, .NET 7, .NET 8 lub nowszy)
* **Framework do testów**: NUnit
* **Biblioteka do mockowania**: Moq

## Uruchamianie Testów

Aby uruchomić testy jednostkowe, potrzebujesz zainstalowanego .NET SDK.

1.  **Klonuj repozytorium:**
    ```bash
    git clone https://github.com/sebCzabak/PaymentSystem
    cd PaymentSystem
    ```
2.  **Uruchom testy z linii poleceń:**
    Przejdź do głównego katalogu solucji lub katalogu projektu testowego (`PaymentSystem.Tests`) i wykonaj polecenie:
    ```bash
    dotnet test
    ```
3.  **Uruchom testy w Visual Studio:**
    * Otwórz plik solucji (`.sln`) w Visual Studio.
    * Zbuduj solucję (`Ctrl+Shift+B` lub `Build > Build Solution`).
    * Otwórz Test Explorer (`Test > Test Explorer`) i uruchom wybrane lub wszystkie testy.

---

Ten projekt służy głównie celom edukacyjnym i demonstracyjnym.
