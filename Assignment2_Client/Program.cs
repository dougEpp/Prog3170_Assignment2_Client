using RestSharp;
using System;

namespace Assignment2_Client
{
    class Program
    {
        const string BASE_ADDRESS = "http://localhost:49899";
        const string APPLICATION_PATH = "/API/Song";
        static void Main(string[] args)
        {
            const string ID_PARAMETER_NAME = "id";
            const string ID_PARAMETER_VALUE = "7";

            const string NAME_PARAMETER_NAME = "name";
            const string NAME_PARAMETER_VALUE = "Everest";

            const string TYPE_PARAMETER_NAME = "type";
            const string TYPE_PARAMETER_VALUE_CORRECT = "Husky";
            const string TYPE_PARAMETER_VALUE_INCORRECT = "Musky";

            const string PATH_INFO = APPLICATION_PATH + "/" + ID_PARAMETER_VALUE;

            RestClient tempRestClient = new RestClient(BASE_ADDRESS);

            RestRequest tempRestRequest = new RestRequest(APPLICATION_PATH, Method.GET);
            IRestResponse tempRestResponse = tempRestClient.Execute(tempRestRequest);
            Console.WriteLine(tempRestResponse.Content);
            Console.ReadLine();

            //tempRestRequest = new RestRequest(APPLICATION_PATH, Method.POST);
            //tempRestRequest.AddParameter(ID_PARAMETER_NAME, ID_PARAMETER_VALUE);
            //tempRestRequest.AddParameter(NAME_PARAMETER_NAME, NAME_PARAMETER_VALUE);
            //tempRestRequest.AddParameter(TYPE_PARAMETER_NAME, TYPE_PARAMETER_VALUE_INCORRECT);
            //tempRestResponse = tempRestClient.Execute(tempRestRequest);
            //Console.WriteLine(tempRestResponse.Content);
            //Console.ReadLine();
            
            tempRestRequest = new RestRequest(PATH_INFO, Method.GET);
            tempRestResponse = tempRestClient.Execute(tempRestRequest);
            Console.WriteLine(tempRestResponse.Content);
            Console.ReadLine();

            //tempRestRequest = new RestRequest(PATH_INFO, Method.PUT);
            //tempRestRequest.AddParameter(NAME_PARAMETER_NAME, NAME_PARAMETER_VALUE);
            //tempRestRequest.AddParameter(TYPE_PARAMETER_NAME, TYPE_PARAMETER_VALUE_CORRECT);
            //tempRestResponse = tempRestClient.Execute(tempRestRequest);
            //Console.WriteLine(tempRestResponse.Content);
            //Console.ReadLine();

            //tempRestRequest = new RestRequest(PATH_INFO, Method.GET);
            //tempRestResponse = tempRestClient.Execute(tempRestRequest);
            //Console.WriteLine(tempRestResponse.Content);
            //Console.ReadLine();

            //tempRestRequest = new RestRequest(PATH_INFO, Method.DELETE);
            //tempRestResponse = tempRestClient.Execute(tempRestRequest);
            //Console.WriteLine(tempRestResponse.Content);
            //Console.ReadLine();

            //tempRestRequest = new RestRequest(APPLICATION_PATH, Method.GET);
            //tempRestResponse = tempRestClient.Execute(tempRestRequest);
            //Console.WriteLine(tempRestResponse.Content);
            //Console.ReadLine();
        }
    }
}
