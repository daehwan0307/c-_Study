using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

class Test
{
    static void Main(string[] args)
    {

        Console.WriteLine("dk");
        bringpnum();
       
      
    }

    static string bringpnum()
    {
        Console.Write("url입력해주세요:");
        string EmrServerUrl =   Console.In.ReadLine();
        WebRequest request = WebRequest.Create(EmrServerUrl); // 호출할 url =  https://apiv1.mevitz.com/test/getPhoneNumber

        request.Method = "Post";
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);

        string responseFromServer = reader.ReadToEnd();

        JObject obj = JObject.Parse(responseFromServer);
        string pnum = (string)obj["patient_phone"];
       


        reader.Close();
        dataStream.Close();
        response.Close();

        Console.WriteLine(pnum);
        return pnum;
    }
}
