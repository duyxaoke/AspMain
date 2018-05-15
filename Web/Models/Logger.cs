using log4net;
using System.Web;

namespace AspMain.Web.Models
{
    public class Logger
    {
        private static ILog log { get; set; }
        static Logger()
        {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        public static void WriteLog(string Type, string UserId, object msg, string browser = "", float? XRB = 0, float? TotalAmount = 0, int? TypeLog = 0, float? PriceXRB = 0)
        {
            log4net.LogicalThreadContext.Properties["UserId"] = UserId;
            log4net.LogicalThreadContext.Properties["IP"] = System.Web.HttpContext.Current.Request.UserHostAddress;
            log4net.LogicalThreadContext.Properties["Browser"] = browser;
            log4net.LogicalThreadContext.Properties["XRB"] = XRB;
            log4net.LogicalThreadContext.Properties["PriceXRB"] = PriceXRB;
            log4net.LogicalThreadContext.Properties["TotalAmount"] = TotalAmount;
            log4net.LogicalThreadContext.Properties["Type"] = TypeLog;
            switch (Type)
            {
                case "ERROR":
                    log.Error(msg);
                    break;
                case "INFO":
                    log.Info(msg);
                    break;
                case "WARNING":
                    log.Warn(msg);
                    break;
                default:
                    log.Info(msg);
                    break;

            }
        }
    }
}