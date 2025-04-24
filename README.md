# Stack vs Heap
Minnet som tilldelas till stacken är statiskt, de typer som alloceras här är valuetypes t.ex. int och bool.
Variabler som tilldelas till stacken är beroende på funktionen som kallar dem, när funktionen har slutet exkveras så försvinner den från stacken.
Stacken sparar också referenser till objekt eller refererade valuetypes som pekar på heapen.
```cs
  int number = 50;
  bool hasEatenLunch = false;
```
Tillskillnad från stacken hanterar heapen dynamiskt minne såsom objekt.
När variabler slutar användas av funktioner måste garbage collectorn städa upp eller så måste programmeraren deallokeras minnet manuellt.
```cs
  Person me = new Person();
```
![image](https://github.com/user-attachments/assets/bc8f3962-5e8c-43be-907f-3f319c3737ca)


### Value types vs Reference types
Value types är typer som hanterar en instans, t.ex. int, bool. Medans reference types är typer som hanterar en referens till en instans.
De hanteras på lite olika sätt när det kommer till funktion-/metod-anrop, där value types kopierar värdet till funktionen och skapar en ny instans, medans reference types skickar med referensen till där värdet existerar.

I nedanstående bild har vi ett enkelt exempel som visar detta. 
I den övre metoden kopieras värdet från det första deklarerade numret till det andra, medans i den nedre metoden så kopieras referensen.  
![image](https://github.com/user-attachments/assets/97863c45-e03c-4cb7-91d7-971a0c6947c3)


## Queue and Stack simulation of a grocery store queue.

![image](https://github.com/user-attachments/assets/e29fd5a7-5a7c-48bb-912f-f42f5fe67e89)

I följande skiss visas det hur en kö skulle se ut om man använde en queue respektive en stack för att bygga ett kö system.
I den vänstra kön (Queue) så hanteras den som har stått längst i kön först (FIFO).
Men i den högra kön (Stack) så hanteras den som har stått kortast i kön först (LIFO).
I våran simulerade matvaruaffärskö skulle detta vara väldigt dåligt, då stackars John aldrig skulle få sina varor skannade.
Om vi fortfarande tänker att vi vill att John ska få sina varor skannade först, så måste vi då veta alla som kommer ställa sig i kön under hela dagen.

 
