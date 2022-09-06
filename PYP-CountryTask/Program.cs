// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using PYP_CountryTask.Models;

HttpClient http = new HttpClient();
List<Country> Countries = new();
var Phones = http.GetAsync("http://country.io/phone.json").Result;
var Iso = http.GetAsync("http://country.io/iso3.json").Result;
var Capital = http.GetAsync("http://country.io/capital.json").Result;
var Currency = http.GetAsync("http://country.io/currency.json").Result;
var Contient = http.GetAsync("http://country.io/continent.json").Result;
var Country = http.GetAsync("http://country.io/names.json").Result;


var phoneStr = Phones.Content.ReadAsStringAsync().Result;
var phone = JsonConvert.DeserializeObject<Dictionary<string, string>>(phoneStr);

var contientStr = Contient.Content.ReadAsStringAsync().Result;
var contient = JsonConvert.DeserializeObject<Dictionary<string, string>>(contientStr);

var ISOStr = Iso.Content.ReadAsStringAsync().Result;
var ISO = JsonConvert.DeserializeObject<Dictionary<string, string>>(ISOStr);

var CapitalStr = Capital.Content.ReadAsStringAsync().Result;
var capital = JsonConvert.DeserializeObject<Dictionary<string, string>>(CapitalStr);

var CurrencyStr = Currency.Content.ReadAsStringAsync().Result;
var currency = JsonConvert.DeserializeObject<Dictionary<string, string>>(CurrencyStr);

var CountryStr = Country.Content.ReadAsStringAsync().Result;
var country = JsonConvert.DeserializeObject<Dictionary<string, string>>(CountryStr);

for (int i = 0; i < country.Keys.Count; i++)
{
    Country NewCountry = new Country
    {
        Capital = capital.Values.ToArray()[i],
        Currency = currency.Values.ToArray()[i],
        Code = country.Keys.ToArray()[i],
        Name = country.Values.ToArray()[i],
        Phone = phone.Values.ToArray()[i],
        Continent = contient.Values.ToArray()[i],
        ISO = ISO.Values.ToArray()[i]
    };
    Countries.Add(NewCountry);
}
Console.WriteLine("{0,-10}{1,-10}{2,-15}{3,-15}{4,-25}{5,-15}{6,-15}", "Phone", "ISO", "Capital", "Currency", "Continent", "Code", "Name");
Console.WriteLine("{0,-10}{1,-10}{2,-15}{3,-15}{4,-25}{5,-15}{6,-15}", "-------", "-----", "----------", "----------", "-----------------------", "----------", "----------");
foreach (var item in Countries)
{
    Console.WriteLine("{0,-10}{1,-10}{2,-15}{3,-15}{4,-25}{5,-15}{6,-15}", item);
}