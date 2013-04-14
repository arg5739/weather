using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Net;
using System.Web.Services;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    // variable declaration
    string key = null;

    //constructor
    public Service() 
    {
        key = "21ae1d7bb5078da2";
    }
    /**
 * Provides the weather report for given city and state
 *
 * @param       city_name    (string) it is city name 
 * @param       state_name   (string) it is state name
 
 *
 * @return              json object 
 */
    public string getWeather(string city_name, string state_name) 
    {
        string output;
        using (WebClient client = new WebClient())
        {
        
            string input = "http://api.wunderground.com/api/" + key + "/conditions/q/" + state_name+"/"+city_name+".json";
            output = client.DownloadString(input);


            
            //JsonValue value = JsonValue.Parse(output);
            var jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<Dictionary<string, dynamic>>(output);
            return (jss.Serialize(dict));
        }
    }

    /**
  * Provides the hourly weather report for given city and state
  *
  * @param       city_name    (string) it is city name 
  * @param       state_name   (string) it is state name
 
  *
  * @return              json object 
  */
    
    public string getWeather_hourly(string city_name, string state_name, Boolean hourly) 
    {
        if (hourly) 
        {
            string output;
            using (WebClient client = new WebClient())
            {

                string input = "http://api.wunderground.com/api/" + key + "/hourly/q/" + state_name + "/" + city_name + ".json";
                output = client.DownloadString(input);




                //JsonValue value = JsonValue.Parse(output);
                var jss = new JavaScriptSerializer();
                var dict = jss.Deserialize<Dictionary<string, dynamic>>(output);
                return (jss.Serialize(dict));
            }
        }
        return null;
    }

    /**
     * Provides the  10 days weather report for given city and state
     *
     * @param       city_name    (string) it is city name 
     * @param       state_name   (string) it is state name
 
     *
     * @return              json object 
     */
    

    public string getWeather_tenDays(string city_name, string state_name, Boolean tenday)
    {
        if (tenday) 
        {
            string output;
            using (WebClient client = new WebClient())
            {

                string input = "http://api.wunderground.com/api/" + key + "/forecast10day/q/" + state_name + "/" + city_name + ".json";
                output = client.DownloadString(input);




                //JsonValue value = JsonValue.Parse(output);
                var jss = new JavaScriptSerializer();
                var dict = jss.Deserialize<Dictionary<string, dynamic>>(output);
                return (jss.Serialize(dict));
            }
        }
        return null;
    } 
	
}
