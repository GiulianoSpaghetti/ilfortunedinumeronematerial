# ATTENZIONE

[Il fortune almeno su debian è stato standardizzato ed è a libero accesso](https://gemini.google.com/share/43016f2620a3), per cui l'app viene dichiarata DEPRECATA su tale sistema.

## Il fortune di numerone

Il fortune teller che parla italiano

:it: La prima incarnazione seria di un fortune teller in lingua non americana in dialetto material.

Il primo prodotto commerciale pubblicato per android che usa il dialetto material.


![Napoli-Logo](https://github.com/user-attachments/assets/485755c8-376c-4778-b9ba-80f6cb204142)

![made in parco grifeo](https://github.com/user-attachments/assets/8f3e561e-6002-4dd8-bc50-888c14a1dfe3)

[Fatti spiegare il progetto da Gemini di google](https://gemini.google.com/share/05886a1f23c8): basta loggarsi col proprio account.

## Introduzione

Circa 15 anni fa era in voga in Italia una newsletter chiamata "Una barzelletta al giorno" della società buongiorno.
All'inizio pubblicavano citazioni, ma poi si sono messi a pubblicare citazioni non più coperte dal diritto d'autore.
Io me le sono conservate con lo specifico intento di creare il fortune coi cookie italiani.

## Il server

E' liberamente accessibile all'indirizzo numeronesoft.ddns.net porta 3306, con attualmente 1000 massime, è mariadb.
Il server è stato ispezionato dalla FIMI e non presenta particolari problemi, per cui potete realizzare il vostro fortune personale, connettendovi con le librerie mysql in qualsiasi linguaggio vogliate, basta usare come user guest e come password nessuna.

## Video dimostrativi

[Per android](https://youtu.be/5f9GKY1Yyt4)

[Per debian](https://youtu.be/DeC4SAB-fxQ)

[Per windows](https://youtu.be/42Kz41jhDj4)

## Le eccezioni in Avalonia

Su android le eccezioni di Avalonia sono proprietarie e personalmente ho visto che loro fanno una grossa exception a la java invece di intercettarle tutte quante una per una e gestirle correttamente.

Questo rallenta notevolmente l'esecuzione del programma, ed io mi sono dovuto adattare perché la quantità dei dispositivi è talmente varia che ognuno lancia una eccezione diversa.

Il punto è che in caso di errore si blocca, ma è stato dimostrato che non va in crash, per cui il programma non rallenta tantissimo.

## Come scaricare

## Per android

[![google](https://play.google.com/intl/it_it/badges/static/images/badges/it_badge_web_generic.png)](https://play.google.com/store/apps/details?id=org.altervista.numerone.fortune)

## Per debian e windows

[![pling](http://numeronesoft.ddns.net:8080/images/pling.png)](https://www.pling.com/p/2296522/)

## Prerequisti

### Windows
https://winstall.app/apps/Microsoft.DotNet.DesktopRuntime.10

### Debian

https://learn.microsoft.com/it-it/linux/packages


## Donazioni (la banda costa, così come l'elettricità)
https://numerone.altervista.org/donazioni.php

## Note
Se in seguito ad aggiornamenti non installati i client dotnet riprendono a fare shock sulle ventole, provate a disinstallare il pacchetto, aggiornare all'ultimo framework e reinstallare.

# Il software è sotto MIT, potete trarne ispirazione e potete studiarlo, ma non potete diffondere il prodotto completo come vostro, sopratutto dietro pagamento.
