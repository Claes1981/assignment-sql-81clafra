# Reflektion över Monster Tracker

**Namn:** Claes Fransson
**Datum:** [Datum]

---

## Del 1: Grundreflektion (G)

### 1. Planering

**Hur planerade du databasstrukturen och koden?**

**Ditt svar:**
1. ritade ER-diagram i Drawio desktop
2. skapade SQL-schema-filen utifrån mall
3. implementerade CRUD-metoder i en repository-klass för monster
4. skrev metoder för användargränsnitt rörande monster
5. konstruerade därtill facade- och modell-klasser för monster
6. skapade klass för att skapa databasen
7. implementerade alla metoder kopplade till jägare
8. skrev alla metoder kopplade till platser
9. konstruerade metoder för hanteringen av observationer
10. la till felhanteringsrutiner

---

### 2. Problem

**Vad var svårast? Hur löste du det?**


**Ditt svar:**
Svårt att peka ut något enskilt problem, det var många moment som behövde kluras ut hur de skulle implementeras. Svårt att någon gång hitta något flow i programmerandet.
Löste det genom att ta en liten bit i taget och försöka ha tålamod.

---

### 3. Stolthet

**Vad är du mest nöjd med i ditt projekt?**

**Ditt svar:**
Kanske att C#-koden automatiskt skapar en tom databas endast utifrån schema-filen.

---

## Del 4: Samarbete och källor

### AI-verktyg

**Hur använde du AI (ChatGPT, Claude, etc.) i projektet?**

Se [readme](README.md)




### Kurskamrater och lärare

**Vem hjälpte dig och med vad?**

Lärare Marcus Medina förklarade varför det såg bättre ut att kalla samtliga primärnycklar för "Id" istället för att ge dem unika namn.

### Externa resurser

**Vilka guider, dokumentation eller videos använde du?**

Se [readme](README.md)

---

## Del 5: Personlig utveckling

### Vad har du lärt dig om databaser?

Mycket var nytt för mig, såsom normalisering och nycklar. Också att lågnivåspråket för SQL var såpass krångligt och olikt de andra programmeringsspråk jag använt. 

### Vad har du lärt dig om koddesign?

Att icke statiska metoder kräver att en instans först skapas av dem, och att det nog är rekommenderat att ha ickestatiska metoder för databashantering.
Namnet facade var nytt för mig. Även behovet av modell-klasser i C# för databas-objekten, även om jag nog inte riktigt greppat de beskrivande klassernas syntax än.

### Vad har du lärt dig om problemlösning?

---

**Slutkommentar:**

[Avsluta med några meningar om helhetsintrycket av projektet. Vad var roligast? Vad var mest lärorikt?]

---

_Datum för reflektion: [Datum]_
_Skapad av: Claes Fransson_
