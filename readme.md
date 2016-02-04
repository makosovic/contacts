Zadatak
----------
Potrebno je napraviti web-aplikaciju za odrzavanje kontakt liste. Neki od featura koje mora podrzavati:
 
1. Unos, brisanje i uredjivanje kontakata
2. Proizvoljan broj telefonskih brojeva i email adresa za svaki kontakt. Osim toga, neka podrzava unos uobicajenih podataka poput imena, prezimena, adrese i mozda jos pokojeg.
3. Mogucnost tagiranja kontakata proizvoljnim tagovima
4. Pretraga po imenu, prezimenu i tagovima (neka ne bude rijesena potpuno client side, pretrazivanje se treba obaviti na serveru).
5. Neka aplikacija bude izvedena kao single-page application koja podatke dohvaca ajax pozivima, uz podrsku za bookmarking pojedinih kontakata i back-forward buttone u browseru.
6. Pri prvom pokretanju aplikacija bi trebala dodati testne podatke u bazu podataka
 
Naglasak neka bude na cistom, razumljivom i elegantnom dizajnu koda.
 
Na front-endu koristi AngularJS a na back-endu koristi ASP.NET MVC tehnologiju. Podaci neka se spremaju u neki perzistentni storage, sam izaberi koji zelis koristiti.
 
Za slucaj da nije jasno is samog zadatka, aplikacija je zamisljena za jednog korisnika, nije potrebno implementirati nikakav sustav za log-in, registraciju i slicno.

Rješenje
----------

Korišten je bower tako da je u Contacts.Web projektu potrebno pozvati naredbu 
```
bower install
```

Perzistentni storage očekuje SqlServer named instance, te da korisnik ima prava u protivnom je potrebno mjenjati sljedeći connection string
```xml
  <connectionStrings>
    <add name="ContactsDbConnectionString" connectionString="Data Source=.;Initial Catalog=ContactsDb;Integrated Security=True;MultipleActiveResultSets=True" providerName="System.Data.SqlClient" />
  </connectionStrings>
```
