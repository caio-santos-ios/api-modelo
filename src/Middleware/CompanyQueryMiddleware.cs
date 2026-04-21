using System.Text;
using System.Text.Json;
using api_infor_cell.src.Models.Base;
using Microsoft.Extensions.Primitives;

public class CompanyQueryMiddleware(RequestDelegate _next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            string path = context.Request.Path;
            string method = context.Request.Method;
            string? companyId = context.User.FindFirst("companyId")?.Value;
            string? master = context.User.FindFirst("master")?.Value;
            string? userId = context.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if(!new List<string>() {"notifications"}.Contains(path.Split("/")[2])) 
            {
                if(method == HttpMethods.Put)
                {
                    if(context.Request.ContentType?.Contains("application/json") == true)
                    {
                        context.Request.EnableBuffering();

                        using (var reader = new StreamReader(context.Request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true))
                        {
                            var body = await reader.ReadToEndAsync();
                            
                            if (!string.IsNullOrEmpty(body))
                            {
                                var jsonDoc = JsonSerializer.Deserialize<Dictionary<string, object>>(body);
                                if (jsonDoc != null)
                                {
                                    jsonDoc["updatedBy"] = userId!;

                                    var modifiedBody = JsonSerializer.Serialize(jsonDoc);
                                    var bytes = Encoding.UTF8.GetBytes(modifiedBody);

                                    context.Request.Body = new MemoryStream(bytes);
                                    context.Request.ContentLength = bytes.Length;
                                }
                            }
                        }
                    }
                } 

                if(method == HttpMethods.Post)
                {
                    if(context.Request.ContentType?.Contains("application/json") == true) 
                    {
                        context.Request.EnableBuffering();

                        using (var reader = new StreamReader(context.Request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true))
                        {
                            var body = await reader.ReadToEndAsync();
                            
                            if (!string.IsNullOrEmpty(body))
                            {
                                var jsonDoc = JsonSerializer.Deserialize<Dictionary<string, object>>(body);
                                if (jsonDoc != null)
                                {
                                    jsonDoc["companyId"] = companyId!;
                                    jsonDoc["createdBy"] = userId!;

                                    var modifiedBody = JsonSerializer.Serialize(jsonDoc);
                                    var bytes = Encoding.UTF8.GetBytes(modifiedBody);

                                    context.Request.Body = new MemoryStream(bytes);
                                    context.Request.ContentLength = bytes.Length;
                                }
                            }
                        }
                    }
                    else
                    {
                        var formFields = new List<KeyValuePair<string, string>>();

                        foreach (var key in context.Request.Form.Keys)
                        {
                            formFields.Add(new KeyValuePair<string, string>(key, context.Request.Form[key]!));
                        }

                        formFields.RemoveAll(x => x.Key == "plan" || x.Key == "company" || x.Key == "store" || x.Key == "createdBy");
                        formFields.Add(new KeyValuePair<string, string>("companyId", companyId!));
                        formFields.Add(new KeyValuePair<string, string>("createdBy", userId!));

                        context.Request.Form = new FormCollection(
                            formFields.GroupBy(x => x.Key).ToDictionary(g => g.Key, g => new StringValues(g.Select(x => x.Value).ToArray())),
                            context.Request.Form.Files 
                        );
                    }
                }            
                
                if(master == "False")
                {
                    if(method == HttpMethods.Get) 
                    {
                        try 
                        {
                            var queryItems = context.Request.Query.ToDictionary(x => x.Key, x => x.Value);
                            
                            queryItems["companyId"] = companyId;

                            context.Request.Query = new QueryCollection(queryItems);
                        }
                        catch (JsonException) {}
                    }
                }
            }
            else 
            {                
                if(method == HttpMethods.Post && context.Request.ContentType?.Contains("application/json") == true)
                {
                    context.Request.EnableBuffering();

                    using (var reader = new StreamReader(context.Request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true))
                    {
                        var body = await reader.ReadToEndAsync();
                        
                        if (!string.IsNullOrEmpty(body))
                        {
                            var jsonDoc = JsonSerializer.Deserialize<Dictionary<string, object>>(body);
                            if (jsonDoc != null)
                            {
                                jsonDoc["companyId"] = companyId!;

                                var modifiedBody = JsonSerializer.Serialize(jsonDoc);
                                var bytes = Encoding.UTF8.GetBytes(modifiedBody);

                                context.Request.Body = new MemoryStream(bytes);
                                context.Request.ContentLength = bytes.Length;
                            }
                        }
                    }
                }
            }
        }

        await _next(context);
    }
}