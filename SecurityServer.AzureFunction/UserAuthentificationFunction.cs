using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SecurityServer.Data;
using SecurityServer.Service;
using SecurityServer.Entities.DtoDown;
using SecurityServer.Entities.DtoUp;
using SecurityServer.Service.Interface;
using System.Net;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Web.Http;
using SecurityServer.Entities;
using Nest;

namespace SecurityServer.AzureFunction
{
    public class UserAuthentificationFunction
    {
        private IUserService _userService;
        private IApplicationService _applicationService;

        public UserAuthentificationFunction(IUserService userService, IApplicationService applicationService)
        {
            this._userService = userService;
            this._applicationService = applicationService;
        }

        [FunctionName("UserAuthentificationFunction")]
        public  async Task<IActionResult> Authentification(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "auth")] UserDtoUp user)
        {
            
            bool userAuth = _userService.GetUser(user.email, user.password);
            var redirecteUri = _applicationService.GetApplication(user.clientId);

            if (userAuth)
            {
                string codeGrant = _userService.GetCodeGrant();
                string url = redirecteUri.Url + "&code=" + codeGrant; 
                return new RedirectResult(url);
            }
            else
            {
                return new BadRequestErrorMessageResult("Login or Password not correct");
            }               
            
        }

        [FunctionName("getTokenFunction")]
        public async Task<IActionResult> getToken(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "GetAcces")] HttpRequest req)
        {
            string codeGrant = req.Query["codeGrant"];

            string requestBody = String.Empty;
            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                requestBody = await streamReader.ReadToEndAsync();
            }
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            codeGrant = codeGrant ?? data?.codeGrant;

            var token = _userService.GetToken(codeGrant);

            return new OkObjectResult(token);

        }

        [FunctionName(nameof(GetData))]
        public static async Task<IActionResult> GetData(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "data")] HttpRequest req)
        {
            // Check if we have authentication info.
            ValidateJWTService auth = new ValidateJWTService(req);
            if (!auth.IsValid)
            {
                return new UnauthorizedResult(); // No authentication info.
            }
            string postData = await req.ReadAsStringAsync();
            return new OkObjectResult($"{postData}");
        }
    }

    public class UserCredentials
    {
        public string User
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
    }
}
