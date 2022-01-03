//***************************************************
//VS 2022 VUE + ASP.NET CORE API
//***************************************************

Visual Studio 2022 projektin luonti Vue front, c# asp.net core back:
https://docs.microsoft.com/en-us/visualstudio/javascript/tutorial-asp-net-core-with-vue?view=vs-2022

//***************************************************
//BOOTSTRAP
//***************************************************

Bootstrapin käyttöönotto:
https://bootstrap-vue.org/docs

.:NPM:.
npm install vue bootstrap bootstrap-vue

.:main.js:.
import BootstrapVue from 'bootstrap-vue/dist/bootstrap-vue.esm';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import 'bootstrap/dist/css/bootstrap.css';

Vue.use(BootstrapVue);

//***************************************************
//DATABASE SQLITE
//***************************************************
Valitsin tämän, koska itsellä ei nyt valitettavasti ole mahdollisuutta ottaa maksullista Azure SQL -tietokantaa käyttöön ja tämä on mielestäni riittävä ja miltei yhtenevä SQL kanssa demotilanteessa, tietysti produktiossa huono jos monta käyttäjää puukottaa samaa db-tiedostoa.

https://chaitanyasuvarna.wordpress.com/2020/07/26/sqlite-with-efcore-3/

https://stackoverflow.com/questions/68980778/config-connection-string-in-net-core-6

Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 6.0.1 initialized 'CarDataSQLiteDbContext' using provider 'Microsoft.EntityFrameworkCore.Sqlite:6.0.1' with options: None
To undo this action, use Remove-Migration.

//***************************************************
//AXIOS
//***************************************************
https://www.npmjs.com/package/axios

//***************************************************
//CORS
//***************************************************
https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-6.0

