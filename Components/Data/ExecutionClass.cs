using Lims.Components.Model;
using LIMS.Model;
using Syncfusion.Blazor.RichTextEditor;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.NetworkInformation;
using System.Net.Security;
using Syncfusion.Pdf;
using Newtonsoft.Json;
namespace Lims.Components.Data
{
    public class ExecutionClass
    {
        private readonly HttpClient http;
        private readonly AppSettings appSettings;
        public ExecutionClass(HttpClient _http, AppSettings _app)
        {
            http = _http;
            appSettings = _app;
        }

        public async Task<(bool low, bool high, bool normal)> CheckNormal(string type, Double fn, Double tn, double result)
        {
            bool low = false;
            bool high = false;
            bool normal = false;
            if(type=="-")
            {
                if(fn>result)
                {
                    low = true;
                }else if(tn<result)
                {
                    high = true;
                }
                else { normal = true; }
            }else if(type==">" || type==">=" || type=="Less than" || type=="Upto")
            {
                if((tn+fn)>result)
                {
                    normal = true;
                }
                else
                {
                    high = true;
                }
            }
            else if (type == "<" || type == "<=" || type == "More than")
            {
                if ((tn + fn) < result)
                {
                    normal = true;
                }
                else
                {
                    low = true;
                }
            }

            return (low, high, normal);
        }
        public List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Bold },
        new ToolbarItemModel() { Command = ToolbarCommand.Italic },
        new ToolbarItemModel() { Command = ToolbarCommand.Underline },
        new ToolbarItemModel() { Command = ToolbarCommand.StrikeThrough },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.FontColor },
        new ToolbarItemModel() { Command = ToolbarCommand.BackgroundColor },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Formats },
        new ToolbarItemModel() { Command = ToolbarCommand.Alignments },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.OrderedList },
        new ToolbarItemModel() { Command = ToolbarCommand.UnorderedList },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Outdent },
        new ToolbarItemModel() { Command = ToolbarCommand.Indent },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateLink },
        new ToolbarItemModel() { Command = ToolbarCommand.Image },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateTable },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Undo },
        new ToolbarItemModel() { Command = ToolbarCommand.Redo },
        new ToolbarItemModel() { Command = ToolbarCommand.FontSize },
        new ToolbarItemModel() { Command = ToolbarCommand.FontName }
    };
        public async Task<int> GetRandomNo(int digits)
        {
            Random rnd = new Random();

            int min = (int)Math.Pow(10, digits - 1); // e.g. 100000 for 6 digits
            int max = (int)Math.Pow(10, digits);     // e.g. 1000000 for 6 digits

            int randomNumber = rnd.Next(min, max);
            return randomNumber;
        }

     
        public async Task<String> SendEmail(string email, String _filename, byte[] _file,ViewBills details, Branch_Master bm)
        {
            try
            {
                http.DefaultRequestHeaders.Clear();
                http.DefaultRequestHeaders.Add("X-Tenant-ID", appSettings.ClientId);
                IList<eMailSetup> uemail = await http.GetFromJsonAsync<IList<eMailSetup>>($"{appSettings.BaseUrl}Masters/emaildetails");

                if (uemail != null & uemail.Count > 0)
                {
                   

                    var mailaddress = uemail[0].MailAddress;
                    var hostaddress = uemail[0].HostAddress;
                    var port = uemail[0].Port;
                    var Mailpassword = uemail[0].MailPassword;
                    var ssl = uemail[0].enableSSL;

                    //string html = System.IO.File.ReadAllText(@"wwwroot\\EmailTemplate.html"); // or the HTML string above
                    string html = await http.GetStringAsync("https://demo.iscansoft.com/images/metaomics/EmailTemplate.html");

                    html = html.Replace("{{PatientName}}", details.Name )
                               .Replace("{{PatientID}}", details.CUSTCode)
                               .Replace("{{ReportDate}}", DateTime.Now.ToString("dd MMM yyyy"))
                               .Replace("{{DoctorName}}", details.DOCTOR)
                               .Replace("{{Department}}", "Laboratory")                             
                               .Replace("{{supportemail}}", bm.Email??"")                           
                               .Replace("{{mobileno}}", bm.Mobile + " " + bm.Phone)                           
                               
                               .Replace("{{Year}}", DateTime.Now.Year.ToString())
                               .Replace("{{LabName}}", bm.Name)
                               .Replace("{{LabAddress}}", bm.Address + ", " + bm.City + ","+ bm.State + "," + bm.Country.ToUpper() + " - " + bm.Pincode);

                    MailMessage message = new MailMessage();

                    message.From = new MailAddress(mailaddress);
                    message.Subject = _filename + "-Reg.";
                    message.IsBodyHtml = true;
                    message.Body = html;
                    AlternateView view = AlternateView.CreateAlternateViewFromString(message.Body, message.BodyEncoding, MediaTypeNames.Text.Html);
                    LinkedResource resource = new LinkedResource($"{System.IO.Directory.GetCurrentDirectory()}{@"\wwwroot\images\logo.png"}");
                    resource.ContentId = "id1";
                    message.AlternateViews.Add(view);


                    message.Attachments.Add(new Attachment(new MemoryStream(_file), _filename + ".Pdf"));

                    if (!string.IsNullOrWhiteSpace(uemail[0].bcc))
                    {
                        try
                        {
                            var validAddress = new MailAddress(uemail[0].bcc); // will throw if invalid
                            message.Bcc.Add(validAddress);
                        }
                        catch (FormatException)
                        {
                            // invalid email format — skip or log it
                        }
                    }
                    foreach (var it in email.Split(';'))
                    {
                        var trimmed = it.Trim();
                        if (string.IsNullOrWhiteSpace(trimmed)) continue;

                        try
                        {
                            message.To.Add(new MailAddress(trimmed));
                        }
                        catch (FormatException)
                        {
                            // Invalid email format, ignore or log
                        }
                    }
                    //message.To.Add(new MailAddress(email));
                    SmtpClient client1 = new SmtpClient();
                    client1.Host = hostaddress;
                    client1.EnableSsl = true;
                    NetworkCredential credential = new NetworkCredential()
                    {
                        UserName = mailaddress,
                        Password = Mailpassword
                    };

                    client1.UseDefaultCredentials = false;
                    client1.Credentials = credential;
                    client1.Port = port;

                    message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                    message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    await Task.Run(() => client1.Send(message));


                    _file = null;
                    //fs.Dispose();
                    return "1";
                }
                return "0";
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();

            }
        }
        
        public async Task<string> GetReport<T>(T dyn, string client, bool letterhead, string reportname = "RoutineReport")
        {
            try
            {
                dynamic args = dyn;
            


                RoutineReportDto parameters = new();
                parameters.ClientID = appSettings.ClientId;
                parameters.DataSource = "DataSet1";
                parameters.ReportName =reportname;
                parameters.RequestGUID = Convert.ToString(args.RequestGUID);
                parameters.TCode = Convert.ToString(args.TCode);
                List<ReportParameterDto> parameter = new List<ReportParameterDto>();



                parameter.Add(new ReportParameterDto() { Name = "TCode", Values = new List<string>() { Convert.ToString(args.TCode) } });
                parameter.Add(new ReportParameterDto() { Name = "IsLetterHead", Values = new List<string>() { Convert.ToString(letterhead) } });
                parameters.Parameters = parameter;

                var tt = JsonConvert.SerializeObject(parameters);
                http.DefaultRequestHeaders.Clear();
                http.DefaultRequestHeaders.Add("X-Tenant-ID", appSettings.ClientId);
                var res = await http.PostAsJsonAsync($"{appSettings.BaseUrl}Genetics/GetPreNatalReport", parameters);
                if (res.IsSuccessStatusCode)
                {

                    string report1 = res.Content.ReadAsStringAsync().Result;

                    if (args.FilePath1.Length > 0)
                    {
                        var result1 = await http.GetAsync($"{appSettings.BaseUrl}files/download/{args.FilePath1.ToString()}?client={client}");
                        byte[] filestring = null;
                        if (result1.IsSuccessStatusCode)
                        {
                            var result = await result1.Content.ReadFromJsonAsync<FileDownloadResult>();
                            // Convert Base64 back to byte[]
                            filestring = (result.Base64);
                            byte[] report = Convert.FromBase64String(report1);

                            PdfDocument finalDoc = new PdfDocument();
                            MemoryStream ms1 = new MemoryStream(report);
                            MemoryStream ms2 = new MemoryStream(filestring);

                            //Creates a PDF stream for merging.
                            Stream[] streams = { ms1, ms2 };
                            //Merges PDFDocument.
                            PdfDocumentBase.Merge(finalDoc, streams);

                            //Save the document into stream.
                            MemoryStream stream = new MemoryStream();
                            finalDoc.Save(stream);
                            string reportstring = Convert.ToBase64String(stream.ToArray());
                            //await rpt.LoadAsync("data:application/pdf;base64, " + reportstring, null);

                            return reportstring;
                        }
                    }
                    else
                    {
                        return report1;
                    }

                        return "";
                }
                return "";
            }
            catch (Exception ex)
            {
                var msf = ex.Message.ToString();
                return "";
            }
        }





        public async Task<string> GetStatement(RoutineReportDto parameters, string api)
        {
            try
            {
                               

                var tt = JsonConvert.SerializeObject(parameters);
                http.DefaultRequestHeaders.Clear();
                http.DefaultRequestHeaders.Add("X-Tenant-ID", appSettings.ClientId);
                var res = await http.PostAsJsonAsync($"{appSettings.BaseUrl}{api}", parameters);
                if (res.IsSuccessStatusCode)
                {
                    string statement = res.Content.ReadAsStringAsync().Result; 
                    return statement;
                }
                return "";
            }
            catch (Exception ex)
            {
                var msf = ex.Message.ToString();
                return "";
            }
        }

        public PreNatalRequest MapNewBornToPreNatal(NewBornRequest newBorn)
        {
            return new PreNatalRequest
            {
                RequestGUID = newBorn.RequestGUID,
                RequestSno = newBorn.RequestSno,
                RequestSnoPrint = newBorn.RequestSnoPrint ?? "",
                RequestDateTime = newBorn.RequestDateTime,
                PatientName = newBorn.PatientName ?? "",
                Age = newBorn.Age ?? "",
                Gender = newBorn.Gender ?? "",
                MobileNo = newBorn.MobileNo ?? "",
                EmailID = newBorn.EmailID ?? "",
                DoctorFullName = newBorn.DoctorFullName ?? "",
                DCode = newBorn.DCode,
                SecondDoctorName = newBorn.SecondDoctorName ?? "",
                SecondDCode = newBorn.SecondDCode,
                TestName = newBorn.TestName ?? "",
                TCode = newBorn.TCode,
                SkyCode = newBorn.SkyCode ?? "",

                // PreNatal specific default value
                RequestStatus = "New",

                EnteredBy = newBorn.EnteredBy,
                ApprovedBy = newBorn.ApprovedBy,
                AuthorizedBy = newBorn.AuthorizedBy,

                FilePath1 = newBorn.FilePath1,
                FilePath2 = newBorn.FilePath2,
                FilePath3 = newBorn.FilePath3
            };
        }

    }
}
