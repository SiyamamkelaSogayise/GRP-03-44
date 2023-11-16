//using Microsoft.AspNetCore.Mvc;
//using Microsoft.PowerBI.Api;
//using Microsoft.Rest;

//namespace GeeksProject02.Controllers
//{
//    public class PowerBIController1 : Controller
//    {
//        public IActionResult EmbedReport()
//        {
//            var tokenCredentials = new TokenCredentials("your-access-token", "Bearer");
//            using var client = new PowerBIClient(tokenCredentials);

//            var workspaceId = "your-workspace-id";
//            var reportId = "your-report-id";

//            var embedToken = client.Reports.GenerateTokenInGroup(workspaceId, reportId);

//            var embedUrl = $"https://app.powerbi.com/reportEmbed?reportId={reportId}&groupId={workspaceId}";

//            return View(new EmbedConfig
//            {
//                EmbedToken = embedToken.Token,
//                EmbedUrl = embedUrl,
//                Id = reportId,
//            });
//        }
//}
