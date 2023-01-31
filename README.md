# PARAbolic
## Capitalist Jungle

<details>
<summary>

### Sprint 1 - Planning

</summary>

În primul sprint toți membrii echipei s-au familiarizat cu modul de lucru în Unity și au configurat mediul de dezvoltare în mod corespunzător pentru a putea lucra. 
În urma discuțiilor purtate în cadrul echipei, dintre mai multe teme de joc propuse inițial, s-a ales tematica actuală și s-a început planificarea sprinturilor și a obiectivelor. Astfel, în primul sprint am urmărit îndeplinirea următoarelor obiective:
- **Familiarizare Unity**
- **Configurare Initiala Proiect**
- **Ca Jucător îmi pot urmări caracterul din perspectivă top-down** - implementarea camerei care urmărește jucătorul
- **Ca Jucător pot să controlez direcția de deplasare a caracterului cu tastele WASD** - jucătorul se poate deplasa folosind fie tastele WASD, fie săgețile și acesta se rotește după cursorul mouse-ului
- **Ca Jucător pot avea deplasarea împiedicată de Obstacole de pe hartă** - adăugarea elementelor interactive pe hartă (diferite obstacole de care jucătorul se poate lovi sau pe care le poate muta)
- **Ca Jucător pot să trag mai multe proiectile la distanță mică printr-un right click pentru a da damage mai multor Inamici** - am hotărât să nu mai implementăm acest obiectiv deoarece ar fi redus prea mult dificultatea jocului 
- **Ca Jucător sunt urmărit și atacat de Inamici pentru a-mi scădea numărul de Health Points și pentru a pierde sesiunea de joc** - plasarea inamicilor pe hartă
- **Ca Jucător pot apăsa pe butonul de Options pentru a schimba diferite setări ale jocului**
- **Ca Jucător pot apăsa pe butonul de Play pentru a începe o nouă sesiune de joc**
- **Ca Jucător pot apăsa pe butonul Exit pentru a putea părăsi aplicația jocului**
- **Ca Jucător pot apăsa pe pe butonul de Highscores pentru a vedea ultimele 5 highscore-uri**
- **Ca Jucător pot apăsa pe butonul Credits pentru a vedea detalii despre creatorii jocului**

De asemenea, am rezolvat diferite bug-uri care au apărut în timul implementării obiectivelor. Am întâlnit probleme la afișarea unor obiecte pe hartă cauzate de ordinea de apariție în diferite layer-e, la coliziunile dintre unele obiecte care cauzau mișcări eronate și legăturile dintre componentele meniului principal.
![sprint_1](https://i.imgur.com/EBN7gvH.png)

</details>

<details>
<summary>

### Sprint 2 - Programming

</summary>

Sprintul 2 a urmărit implementarea următoarelor obiective:
- **Ca Jucător pot să trag un proiectil la distanță mare printr-un left click pentru a da damage unui singur Inamic**
- **Ca Jucător pentru a elimina un Inamic este nevoie să îl atac până ce îi scad toate Health Points-urile**
- **Ca Jucător dacă sunt atins de atacul unui Inamic îmi pierd din Health Points în funcție de tipul Inamicului** - interactiunea dintre jucător și inamici
- **Ca Jucător pot întâlni diferite tipuri de Inamici care au comportament diferit** - sunt 4 tipuri de inamici care diferă prin atributele lor: viteză, damage, viață, viteza de tragere și viteza proiectilului
- **Ca Jucător pot vedea numărul de Health Points ale caracterului meu** - a fost implementată o primă versiune a unui health bar, care a fost modificată în următorul sprint
- **Ca Jucător pot primi un scor diferit în funcție de tipul Inamicilor** - scorul primit diferă în funcție de inamicul eliminat
- **Ca Jucător pot colecta diferite PowerUp-uri de pe hartă**
- **Ca Jucător primesc bonusurile de la PowerUp in momentul colectării**
- **Ca Jucător la deschiderea aplicației sunt întâmpinat de un meniu principal, de o grafică a jocului pe fundal și de o melodie specifică**
- **Ca Jucător, in Optiuni, pot modifica volumul, dimensiunea ecranului si graficile jocului**

Următoarele obiective nu au mai fost implementate deoarece ar fi scăzut prea mult dificultatea: 
- **Ca Jucător pot să trag o rafală de proiectile timp de 5 secunde folosind un PowerUp pentru a elimina câți mai mulți Inamici**
- **Ca Jucător pot să fiu protejat de un scut invincibil de atactul Inamicilor timp de 5 secunde folosind un PowerUp**
- **Ca Jucător pot să dau stun Inamicilor din proximitatea caracterului meu timp de 5 secunde folosind un PowerUp**

![sprint_2](https://i.imgur.com/7ScELtU.png)

</details>

<details>
<summary>

### Hardening Sprint

</summary>

În acest sprint s-a urmărit implementarea și îmbunătățirea următoarelor obiective:
- **Ca Jucător la finalul unei sesiuni de joc dacă am obținut un nou Highscore îmi pot trece numele într-o casetă de text, iar la final salvez noul Highscore apăsând un buton**
- **Ca Jucător după pierderea unei sesiuni de joc îmi sunt afișate stats-urile sesiunii și dacă am obținut Highscore** 
- **Ca Jucător primesc bonusurile de la PowerUp in momentul colectării**
- **Ca Jucător pot colecta diferite PowerUp-uri de pe hartă**
- **Ca Jucător pot apăsa pe butonul Credits pentru a vedea detalii despre creatorii jocului**
- **Ca Jucător pot apăsa pe pe butonul de Highscores pentru a vedea ultimele 5 highscore-uri**
- **Ca Jucător pot să-mi recapăt în totalitate numărul de Health Points folosind un PowerUp**
- **Ca Jucător pot sa îmi cresc viteza de deplasare timp de 3 secunde folosind un PowerUp pentru a fugi de inamici**
- **Ca Jucător pot vedea scorul pe care îl acumulez pe parcursul sesiunii de joc și wave-ul la care sunt**
- **Ca Jucător pot pune pauză în timpul unei sesiuni de joc pentru a lua o pauză sau pentru a abandona sesiunea de joc și să fiu redirecționat la Meniul Principal** 
- **Ca Jucător pot vedea numărul de Health Points ale caracterului meu**
- **Ca Jucător voi auzi câte un sunet diferit pentru acțiuni sau evenimente diferite** 
- **Ca Jucător la finalul unei sesiuni de joc pot să reîncep un nou joc apăsând un buton** 
- **Ca Jucător la finalul unei sesiuni de joc pot să mă reîntorc la la Meniul Principal apăsând un buton** 

Următoarele obiective nu au mai fost implementate deoarece nu ar fi adus o îmbunătățire semnificativă gameplay-ului 
- **Ca Jucător în timpul sesiunii de joc în funcție de scor envirement-ul și melodia de fundal se schimbă** 
- **Ca Jucător pot vedea ce PowerUp am disponibil la un moment dat**

</details>

### [Link pentru descărcarea arhivei jocului](https://mega.nz/file/yYRABb4J#N5v4_wctcDljcRgiyJqRdQVRFahrb6azrh2j8xacL_Q)
