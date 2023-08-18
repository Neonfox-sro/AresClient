using System.Xml.Linq;

namespace AresClient;

public class Class1
{
    public void Log(string text)
    {
        Console.WriteLine(text);
    }
    
    private const string AresUrl = "https://wwwinfo.mfcr.cz/cgi-bin/ares/darv_std.cgi?ico=";
    private const string LocalName = "Pocet_zaznamu";
    
    /// <summary>
    /// Method to validate ICO in ARES
    /// </summary>
    /// <param name="ico">Identification of subject</param>
    /// <returns>True if ICO is valid</returns>
    public async Task<bool> ValidIco(string ico)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                var url = AresUrl + ico;
                var response =  await client.GetAsync(url);
        
                XElement xmlParsed = XElement.Parse(await response.Content.ReadAsStringAsync());
                var count = xmlParsed.Descendants().FirstOrDefault(x => x.Name.LocalName == LocalName)?.Value;

                return count != null && count != "0";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something gone wrong: {ex.Message}");
        }

        return false;
    }
    
}
