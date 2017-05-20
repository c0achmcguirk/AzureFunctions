using System.Net;

public static HttpResponseMessage Run(HttpRequestMessage req, TraceWriter log)
{    
    log.Info("Update for stage environment");

    string inputStrings = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "list", true) == 0)
        .Value;

    var individualStrings = inputStrings.Split(',').ToList<string>();
    individualStrings.Sort();
    
    return req.CreateResponse(HttpStatusCode.OK, "staging: " + string.Join(",", individualStrings));
}