## README för API

För att starta API:et, gå in i mappen Filmstudion/api via en terminal och skriv *dotnet run*.

**Bra att veta**

API:erna PUT */api/films* och PATCH /api/films/{Id} kräver att man skickar med en token för att fungera.
För att få en token, registrera en användare och skicka sedan in *Username* och *Password* i */api/users/authenticate*.


För att se alla åtkomsterpunket, starta API:et och gå sedan in på *https://localhost:5001/swagger/index.html*