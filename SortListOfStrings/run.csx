using System.Net;

public static HttpResponseMessage Run(HttpRequestMessage req, TraceWriter log)
{    
    log.Info("C# HTTP trigger function processed a request. Master branch (prod). Edit 4");

    string inputStrings = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "list", true) == 0)
        .Value;

    var individualStrings = inputStrings.Split(',').ToList<string>();
    individualStrings.Sort();
    
    return req.CreateResponse(HttpStatusCode.OK, "master: " + string.Join(",", individualStrings));
}