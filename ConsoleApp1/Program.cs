// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var client = new AresClient.AresClient();
var result = await client.FindCompanyByIco("17338786");

Console.WriteLine(result);
